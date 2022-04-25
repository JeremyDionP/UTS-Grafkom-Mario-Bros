using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;


namespace Mario
{
    internal class Toad
    {
        List<List<Asset3d>> toad = new List<List<Asset3d>>();

        List<Asset3d> kepala = new List<Asset3d>();
        List<Asset3d> tangan_kanan = new List<Asset3d>();
        List<Asset3d> tangan_kiri = new List<Asset3d>();
        List<Asset3d> _badan = new List<Asset3d>();
        List<Asset3d> kaki_kanan = new List<Asset3d>();
        List<Asset3d> kaki_kiri = new List<Asset3d>();

        float count = 0;
        float count2 = 0;
        int cnt = 0;
        int cnt2 = 0;
        bool cek = true;

        // constructor
        public Toad()
        {

        }

        // fungsi untuk load objek-objek
        public void load(int x, int y)
        {
            // ===== INITIALIZATION =====
            // Jamur
            var jamur = new Asset3d(new Vector3(1.0f, 1.0f, 1.0f));
            var jamur2 = new Asset3d(new Vector3(1.0f, 1.0f, 1.0f));
            var jamur3 = new Asset3d(new Vector3(1.0f, 0, 0));
            var jamur4 = new Asset3d(new Vector3(1.0f, 0, 0));
            var jamur5 = new Asset3d(new Vector3(1.0f, 0, 0));
            var jamur6 = new Asset3d(new Vector3(1.0f, 0, 0));

            // Kepala
            var head = new Asset3d(new Vector3(1.0f, 0.85f, 0.67f));

            // Mata
            var eye = new Asset3d(new Vector3(0f, 0f, 0f));
            var eye2 = new Asset3d(new Vector3(0f, 0f, 0f));
            var pupil = new Asset3d(new Vector3(1.0f, 1.0f, 1.0f));
            var pupil2 = new Asset3d(new Vector3(1.0f, 1.0f, 1.0f));

            // Mulut
            var mulut = new Asset3d(new Vector3(0.0f, 0.0f, 0.0f));

            // Badan
            var badan = new Asset3d(new Vector3(1.0f, 0.85f, 0.67f));
            var badan2 = new Asset3d(new Vector3(1.0f, 1.0f, 1.0f));

            // Tangan
            var tangan = new Asset3d(new Vector3(1.0f, 0.85f, 0.67f));
            var tangan2 = new Asset3d(new Vector3(1.0f, 0.85f, 0.67f));
            var tangan3 = new Asset3d(new Vector3(1.0f, 0.85f, 0.67f));
            var tangan4 = new Asset3d(new Vector3(1.0f, 0.85f, 0.67f));
            var jari = new Asset3d(new Vector3(1.0f, 0.85f, 0.67f));
            var jari2 = new Asset3d(new Vector3(1.0f, 0.85f, 0.67f));

            // Kaki
            var kaki = new Asset3d(new Vector3(0.54f, 0.27f, 0.07f));
            var kaki2 = new Asset3d(new Vector3(0.54f, 0.27f, 0.07f));

            // ===== CREATE OBJECT =====
            // Jamur
            jamur.createTorus(0f, 0.07f, 0.4f, 0.02f, 0.01f, 100.0f, 100.0f);
            jamur2.createEllipsoid(0f, 0.075f, 0.4f, 0.027f, 0.01f, 0.027f, 100.0f, 100.0f);
            jamur3.createEllipsoid(0f, 0.071f, 0.422f, 0.017f, 0.008f, 0.01f, 100.0f, 100.0f);
            jamur4.createEllipsoid(0f, 0.071f, 0.378f, 0.017f, 0.008f, 0.01f, 100.0f, 100.0f);
            jamur5.createEllipsoid(0.017f, 0.071f, 0.4f, 0.015f, 0.009f, 0.017f, 100.0f, 100.0f);
            jamur6.createEllipsoid(-0.017f, 0.071f, 0.4f, 0.015f, 0.009f, 0.017f, 100.0f, 100.0f);
            jamur3.scale(0.88f, 1.0f, 1.0f);
            jamur4.scale(0.88f, 1.0f, 1.0f);
            jamur5.scale(1.0f, 1.0f, 0.88f);
            jamur6.scale(1.0f, 1.0f, 0.88f);

            // Kepala
            head.createEllipsoid(0, 0.05f, 0.4f, 0.02f, 0.02f, 0.02f, 100.0f, 100.0f);

            // Mata
            eye.createEllipsoid(0.005f, 0.05f, 0.418f, 0.0025f, 0.0037f, 0.0025f, 100.0f, 100.0f);
            eye2.createEllipsoid(-0.005f, 0.05f, 0.418f, 0.0025f, 0.0037f, 0.0025f, 100.0f, 100.0f);
            pupil.createEllipsoid(0.0053f, 0.052f, 0.42f, 0.0007f, 0.0012f, 0.0007f, 100.0f, 100.0f);
            pupil2.createEllipsoid(-0.0053f, 0.052f, 0.42f, 0.0007f, 0.0012f, 0.0007f, 100.0f, 100.0f);

            // Mulut
            mulut.createHyperboloid1(0f, 0.04f, 0.41f, 0.0025f, 0.0037f, 0.0025f, 100.0f, 100.0f);
            mulut.rotate(mulut.objectCenter, Vector3.UnitX, 90);

            // Badan
            badan.createEllipsoid(0, 0.017f, 0.4f, 0.02f, 0.015f, 0.02f, 100.0f, 100.0f);
            badan2.createEllipsoid(0, 0.013f, 0.4f, 0.02f, 0.015f, 0.02f, 100.0f, 100.0f);

            // Tangan
            tangan.createCylinder(0.0215f, 0.0177f, 0.4f, 0.005f, 0.007f, 0.005f, 100.0f, 100.0f);
            tangan.rotate(tangan.objectCenter, Vector3.UnitZ, -120);
            tangan2.createCylinder(-0.0215f, 0.0177f, 0.4f, 0.005f, 0.007f, 0.005f, 100.0f, 100.0f);
            tangan2.rotate(tangan2.objectCenter, Vector3.UnitZ, 120);
            tangan3.createEllipsoid(0.03f, 0.013f, 0.4f, 0.005f, 0.007f, 0.005f, 100.0f, 100.0f);
            tangan4.createEllipsoid(-0.03f, 0.013f, 0.4f, 0.005f, 0.007f, 0.005f, 100.0f, 100.0f);
            jari.createEllipticParaboloid(0.031f, 0.023f, 0.4f, 0.002f, 0.003f, 0.003f, 100.0f, 100.0f);
            jari.rotate(jari.objectCenter, Vector3.UnitX, 90);
            jari2.createEllipticParaboloid(-0.031f, 0.023f, 0.4f, 0.002f, 0.003f, 0.003f, 100.0f, 100.0f);
            jari2.rotate(jari2.objectCenter, Vector3.UnitX, 90);

            // Kaki
            kaki.createEllipsoid(0.01f, 0.0f, 0.4f, 0.01f, 0.009f, 0.017f, 100.0f, 100.0f);
            kaki2.createEllipsoid(-0.01f, 0.0f, 0.4f, 0.01f, 0.009f, 0.017f, 100.0f, 100.0f);

            // ===== ADD OBJECT =====
            // Jamur
            kepala.Add(jamur);
            jamur.child.Add(jamur2);
            jamur.child.Add(jamur3);
            jamur.child.Add(jamur4);
            jamur.child.Add(jamur5);
            jamur.child.Add(jamur6);
            //toad.Add(jamur2);
            //toad.Add(jamur3);
            //toad.Add(jamur4);
            //toad.Add(jamur5);
            //toad.Add(jamur6);

            // Kepala
            //toad.Add(head);
            jamur.child.Add(head);

            // Mata
            //toad.Add(eye);
            //toad.Add(eye2);
            //toad.Add(pupil);
            //toad.Add(pupil2);
            jamur.child.Add(eye);
            jamur.child.Add(eye2);
            jamur.child.Add(pupil);
            jamur.child.Add(pupil2);

            // Mulut
            //toad.Add(mulut);
            jamur.child.Add(mulut);

            // Badan
            //toad.Add(badan);
            //toad.Add(badan2);
            _badan.Add(badan);
            jamur.child.Add(badan);
            jamur.child.Add(badan2);

            // Tangan
            //toad.Add(tangan);
            //toad.Add(tangan2);
            //toad.Add(tangan3);
            //toad.Add(tangan4);
            //toad.Add(jari);
            //toad.Add(jari2);
            tangan_kanan.Add(tangan);
            jamur.child.Add(tangan);
            tangan_kiri.Add(tangan2);
            jamur.child.Add(tangan2);
            jamur.child.Add(tangan3);
            jamur.child.Add(tangan4);
            jamur.child.Add(jari);
            jamur.child.Add(jari2);

            // Kaki
            //toad.Add(kaki);
            //toad.Add(kaki2);
            kaki_kanan.Add(kaki);
            jamur.child.Add(kaki);
            kaki_kiri.Add(kaki2);
            jamur.child.Add(kaki2);

            toad.Add(kepala);
            toad.Add(_badan);
            toad.Add(tangan_kanan);
            toad.Add(tangan_kiri);
            toad.Add(kaki_kanan);
            toad.Add(kaki_kiri);

            foreach (Asset3d i in kepala)
            {
                i.translate(0.12f, -0.01f, 0.18f);
                i.load(x, y);
            }
        }

        // fungsi untuk render objek-objek
        public void render(FrameEventArgs args, Camera _camera, KeyboardState input)
        {
            float time = (float)args.Time; //Deltatime ==> waktu antara frame sebelumnya ke frame berikutnya, gunakan untuk animasi

            foreach (List<Asset3d> i in toad)
            {
                foreach (Asset3d j in i)
                {
                    j.render(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());
                }
                foreach (Asset3d j in kepala)
                {
                    j.translate(0, 0, 0.01f * time);
                    j.rotate(new Vector3(0.12f, 0.06f, 0.58f), Vector3.UnitY, 10 * time);

                    if (cnt == 70)
                    {
                        if (cnt2 == 70)
                        {
                            cek = true;
                            cnt = 0;
                            continue;
                        }
                        cek = false;
                    }
                    else
                    {
                        cnt2 = 0;
                    }

                    if (cnt < 70 && cek)
                    {
                        count = 0.005f;
                        j.child[20].rotate(j.child[20].objectCenter, Vector3.UnitX, -1 * count * 500);
                        j.child[19].rotate(j.child[19].objectCenter, Vector3.UnitX, count * 500);
                        cnt++;
                    }
                    else if (cnt2 < 70 && !cek)
                    {
                        count2 = -0.005f;
                        j.child[20].rotate(j.child[20].objectCenter, Vector3.UnitX, -1 * count2 * 500);
                        j.child[19].rotate(j.child[19].objectCenter, Vector3.UnitX, count2 * 500);
                        cnt2++;
                    }
                }
            }
        }
    }
}
