using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;
using System;
using OpenTK.Mathematics;
using LearnOpenTK.Common;

namespace Mario
{
    static class Constants
    {
        public const string path = "../../../Shaders/";
    }

    class Window : GameWindow
    {
        Environment _environment = new Environment();
        Mario _mario = new Mario();
        Castle _castle = new Castle();
        Toad _toad = new Toad();
        Yoshi _yoshi = new Yoshi();

        Camera _camera;

        double _time;
        bool _firstMove = true;

        Vector2 _lastPos;
        Vector3 _objectPos = new Vector3(0, 0, 0);

        float _rotationSpeed = 0.1f;
        float degr = 0;

        // constructor
        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
            Console.WriteLine("\"Mario Bros\" made by:");
            Console.WriteLine("Wendy S - C14200036");
            Console.WriteLine("Justin A H R - C14200148");
            Console.WriteLine("Jeremy D P - C14200206");
            Console.WriteLine("\nControls:");
            Console.WriteLine("WASD - MOVE CAMERA");
            Console.WriteLine("SPACE - MOVE UP CAMERA");
            Console.WriteLine("LSHIFT - MOVE DOWN CAMERA");
            Console.WriteLine("HOVER MOUSE POINTER - ROTATE CAMERA");
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            // ganti background warna
            GL.ClearColor(0.25f, 0.6f, 1.0f, 1.0f);
            GL.Enable(EnableCap.DepthTest);  // ini buat supaya objeknya nggak transparan 

            _environment.load(Size.X, Size.Y);
            _castle.load(Size.X, Size.Y);
            _mario.load(Size.X, Size.Y);
            _toad.load(Size.X, Size.Y);
            _yoshi.load(Size.X, Size.Y);

            // inisialisasi objek camera
            // paramater 1 = posisi
            // parameter 2 = default ukuran window
            _camera = new Camera(new Vector3(0, 0.5f, 1.5f), Size.X / Size.Y);
            // CursorGrabbed = true; // untuk menghilangkan kursor
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            float time = (float)args.Time;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            var input = KeyboardState;

            _environment.render(args, _camera, input, Size.X, Size.Y);
            _castle.render(args, _camera, input, Size.X, Size.Y);
            _mario.render(args, _camera, input, Size.X, Size.Y);
            _toad.render(args, _camera, input);
            _yoshi.render(args, _camera, input);

            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            float time = (float)args.Time;

            var input = KeyboardState; // menerima input dari keyboard
            var mouse_input = MouseState; // menerima input dari mouse

            // jika user tekan Esc maka akan menutup layar
            if (input.IsKeyDown(Keys.Escape))
            {
                Close();
            }

            // jika user tekan Esc maka akan menutup layar
            float cameraSpeed = 0.5f;
            if (KeyboardState.IsKeyDown(Keys.W))
            {
                _camera.Position += _camera.Front * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.A))
            {
                _camera.Position -= _camera.Right * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.S))
            {
                _camera.Position -= _camera.Front * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.D))
            {
                _camera.Position += _camera.Right * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.Space))
            {
                _camera.Position += _camera.Up * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.LeftShift))
            {
                _camera.Position -= _camera.Up * cameraSpeed * (float)args.Time;
            }

            var mouse = MouseState;
            var sensitivity = 0.15f;

            if (_firstMove)
            {
                _lastPos = new Vector2(mouse.X, mouse.Y);
                _firstMove = false;
            }
            else
            {
                var deltaX = mouse.X - _lastPos.X;
                var deltaY = mouse.Y - _lastPos.Y;
                _lastPos = new Vector2(mouse.X, mouse.Y);
                _camera.Yaw += deltaX * sensitivity;
                _camera.Pitch -= deltaY * sensitivity;
            }
        }

        // function dijalankan ketika window di-resize
        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Size.X, Size.Y);
        }
    }
}
