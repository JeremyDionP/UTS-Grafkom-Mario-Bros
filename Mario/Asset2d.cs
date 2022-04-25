using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario
{
    internal class Asset2d
    {
        // array untuk menampung titik-titik
        float[] _vertices =
        {

        };

        uint[] _indices =
        {

        };

        private Matrix4 model = Matrix4.Identity;   // Model Matrix      ==> Matrix ini yang akan berubah saat terjadi transformasi
        private Matrix4 view;                       // View Matrix       ==> Matrix ini menentukan arah pandang 'kamera'
        private Matrix4 projection;                 // Projection Matrix ==> Matrix ini menentukan jenis projection, kamera game cenderung menggunakan kamera perspective.

        int _vertexBufferObject;
        int _elementBufferObject;
        int _vertexArrayObject;

        Shader _shader;

        int indexs;
        int[] _pascal;
        Vector3 color; // Warna objek, dikirim ke shader lewat uniform.

        // constructor
        public Asset2d(Vector3 color, float[] vertices, uint[] indices)
        {
            _vertices = vertices;
            _indices = indices;
            indexs = 0;
            this.color = color;
        }
        public void load(string shadervert, string shaderfrag, int sizeX, int sizeY)
        {
            // inisialisasi
            _vertexBufferObject = GL.GenBuffer();

            // menentukan target dan handle objek - objek 
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);
            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);

            /*
                parameter 1 = variabel _vertices disimpan di shader index ke berapa
                parameter 2 = jumlah vertex di dalam _vertices
                parameter 3 = jenis vertex yang dikirim (tipe data)
                parameter 4 = data perlu dinormalisasikan atau tidak
                parameter 5 = dalam 1 vertex mengandung berapa titik (x, y, z)
                parameter 6 = data yang diolah mulai dari index vertex (_vertices) ke berapa
             */
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            //GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
            //GL.EnableVertexAttribArray(1);

            // apabila varibel _indices ada isinya (sudah diinisialisasi) maka baru create element buffer obejct
            if (_indices.Length > 0)
            {
                _elementBufferObject = GL.GenBuffer();
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
                GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Length * sizeof(uint), _indices, BufferUsageHint.StaticDraw);
            }

            view = Matrix4.CreateTranslation(0, 0, -8.0f);
            projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), sizeX / (float)sizeY, 0.01f, 100f);

            _shader = new Shader(shadervert, shaderfrag);
            _shader.Use();
        }

        public void render(int pilihan, Matrix4 camera_view, Matrix4 camera_projection)
        {
            _shader.Use();
            _shader.SetVector3("objColor", color);

            _shader.SetMatrix4("model", model);
            _shader.SetMatrix4("view", camera_view);
            _shader.SetMatrix4("projection", camera_projection);

            GL.BindVertexArray(_vertexArrayObject);
            if (_indices.Length > 0)
            {
                GL.DrawElements(PrimitiveType.Triangles, _indices.Length,
                    DrawElementsType.UnsignedInt, 0);
            }
            else
            {
                if (pilihan == 0)
                {
                    GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
                }
                else if (pilihan == 1)
                {
                    GL.DrawArrays(PrimitiveType.TriangleFan, 0, (_vertices.Length + 1) / 3);
                }
                else if (pilihan == 2)
                {
                    GL.DrawArrays(PrimitiveType.LineStrip, 0, indexs);
                }
                else if (pilihan == 3)
                {
                    GL.DrawArrays(PrimitiveType.LineStrip, 0, (_vertices.Length + 1) / 3);
                }
            }
        }

        // fungsi untuk membentuk lingkaran
        public void createCircle(float center_x, float center_y, float radius)
        {
            _vertices = new float[1080];
            for (int i = 0; i < 360; i++)
            {
                double degInRad = i * Math.PI / 180;

                //x
                _vertices[i * 3] = radius * (float)Math.Cos(degInRad);

                //y
                _vertices[i * 3 + 1] = radius * (float)Math.Sin(degInRad);

                //z
                _vertices[i * 3 + 2] = 0;
            }
        }

        // fungsi untuk membentuk ellips
        public void createEllips(float center_x, float center_y, float radiusX, float radiusY)
        {
            _vertices = new float[1080];
            for (int i = 0; i < 360; i++)
            {
                double degInRad = i * Math.PI / 180;

                //x
                _vertices[i * 3] = radiusX * (float)Math.Cos(degInRad) + center_x;

                //y
                _vertices[i * 3 + 1] = radiusY * (float)Math.Sin(degInRad) + center_y;

                //z
                _vertices[i * 3 + 2] = 0;
            }
        }

        public void updateMousePos(float _x, float _y)
        {
            _vertices[indexs * 3] = _x;
            _vertices[indexs * 3 + 1] = _y;
            _vertices[indexs * 3 + 2] = 1;

            indexs++;

            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float),
                _vertices, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float,
                false, 3 * sizeof(float), 0);
        }

        public List<int> getRow(int rowIndex)
        {
            List<int> currow = new List<int>();

            currow.Add(1);
            if (rowIndex <= -1)
            {
                return currow;
            }

            List<int> prev = getRow(rowIndex - 1);
            for (int i = 1; i < prev.Count; i++)
            {
                int curr = prev[i - 1] + prev[i];
                currow.Add(curr);
            }
            currow.Add(1);
            return currow;
        }

        public List<float> createCurveBezier(float z)
        {
            List<float> _vertices_bezier = new List<float>();
            List<int> pascal = getRow(indexs - 1);
            _pascal = pascal.ToArray();
            for (float t = 0; t <= 1.0f; t += 0.01f)
            {
                Vector2 p = getP(indexs, t);
                _vertices_bezier.Add(p.X);
                _vertices_bezier.Add(p.Y);
                _vertices_bezier.Add(z);
            }
            return _vertices_bezier;
        }

        public Vector2 getP(int n, float t)
        {
            Vector2 p = new Vector2(0, 0);
            float k;
            for (int i = 0; i < n; i++)
            {
                k = (float)Math.Pow((1 - t), n - 1 - i) * (float)Math.Pow(t, i) * _pascal[i];
                p.X += k * _vertices[i * 3];
                p.Y += k * _vertices[i * 3 + 1];
            }
            return p;
        }

        public bool getVerticesLength()
        {
            if (_vertices[0] == 0)
            {
                return false;
            }
            if ((_vertices.Length + 1) / 3 > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void setVertices(float[] _temp)
        {
            _vertices = _temp;
        }

    }
}
