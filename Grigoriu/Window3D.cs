using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Drawing;

namespace Grigoriu
{
    class Window3D : GameWindow
    {
            private const int XYZ_SIZE = 75;
            private bool axesControl = true;
            const float rotation_speed = 10.0f;
            bool showTriangle = true;
            KeyboardState lastKeyPress;
            Color color = Color.LightBlue;
            private readonly Axe ax;
            private readonly Object obj;

        public Window3D() : base(800, 600)
            {
                VSync = VSyncMode.On;
                ax = new Axe();
                obj = new Object(Color.DeepPink);
            }

            //Culoare fundal
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);

                GL.ClearColor(Color.MidnightBlue);
                GL.Enable(EnableCap.DepthTest);
                GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
            }

            //Inițierea afișării și setarea viewport-ului
            protected override void OnResize(EventArgs e)
            {
                base.OnResize(e);

                GL.Viewport(0, 0, Width, Height);

                double aspect_ratio = Width / (double)Height;

                Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)this.Width / (float)this.Height, 1, 1024);
                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadMatrix(ref perspective);

                Matrix4 lookat = Matrix4.LookAt(20, 20, 20, 0, 0, 0, 0, 1, 0);
                GL.MatrixMode(MatrixMode.Modelview);
                GL.LoadMatrix(ref lookat);
            }

            protected override void OnUpdateFrame(FrameEventArgs e)
            {
                base.OnUpdateFrame(e);

                Mouse.GetCursorState();
                KeyboardState keyboard = OpenTK.Input.Keyboard.GetState();
                MouseState mouse = OpenTK.Input.Mouse.GetState();

                if (keyboard[Key.Escape])
                {
                    Exit();
                }

                //8. Schimbarea culorii triunghiului prin apasarea tastei S.
                if (keyboard[Key.S] && !lastKeyPress[Key.S])
                {
                    obj.ChColor();
                }

           

            lastKeyPress = keyboard;

            }
            protected override void OnRenderFrame(FrameEventArgs e)
            {
                base.OnRenderFrame(e);

                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);


                // angle = rotation_speed * (float)e.Time;
                //GL.Rotate(angle, 0.0f, 1.0f, 0.0f);

                if (showTriangle == true)
                {
                    obj.DrawObj();
                }

                if (axesControl)
                {
                    ax.DrawAxe();
                }
                SwapBuffers();
            }

            
        }
}
