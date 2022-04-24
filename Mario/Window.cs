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
    class Window : GameWindow
    {
        Mario mario_ = new Mario();
        Castle castle_ = new Castle();
        Toad toad_ = new Toad();
        Yoshi yoshi_ = new Yoshi();

        Camera _camera;
        double _time;
        bool _firstMove = true;
        Vector2 _lastPos;
        Vector3 _objectPos = new Vector3(0, 0, 0);
        float _rotationSpeed = 0.1f;
        float degr = 0;

        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {

        }

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.ClearColor(0.1f, 0.6f, 1.0f, 1.0f);
            GL.Enable(EnableCap.DepthTest);

            castle_.load(Size.X, Size.Y);
            mario_.load(Size.X, Size.Y);
            toad_.load(Size.X, Size.Y);
            yoshi_.load(Size.X, Size.Y);

            _camera = new Camera(new Vector3(0, 0f, 0.5f), Size.X / Size.Y);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);


            float time = (float)args.Time;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            var input = KeyboardState;
            


            mario_.render(args ,_camera, input, Size.X, Size.Y);
            castle_.render(args, _camera, input, Size.X, Size.Y);
            toad_.render(args, _camera, input);
            yoshi_.render(args, _camera, input);






            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            float time = (float)args.Time;


            if (!IsFocused)
            {
                return;
            }

            var input = KeyboardState;
            var mouse_input = MouseState;
            float cameraSpeed = 0.5f;

            if (input.IsKeyDown(Keys.Escape))
            {
                Close();
            }

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

      

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Size.X, Size.Y);
        }
    }
}
