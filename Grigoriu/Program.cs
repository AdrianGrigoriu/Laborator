/*
 Grigoriu Adrian
 Grupa 3132B
 Laborator 2
 */


using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Grigoriu
{
    class SimpleWindow3D : GameWindow
    {
        private const int XYZ_SIZE = 75;
        private bool axesControl = true;
        const float rotation_speed = 10.0f;
        float angle;
        Randomizer rando;
        bool showCube = true;
        bool showTriangle = true;
        KeyboardState lastKeyPress;
        Color color = Color.LightBlue;
            

        public SimpleWindow3D() : base(800, 600)
        {
            VSync = VSyncMode.On;
            rando = new Randomizer();
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

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 64);
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
                
                color = rando.GetRandomColor();
                
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
                DrawTriangle();
            }

            if (axesControl)
            {
                DrawAxes();
            }
            SwapBuffers();
        }

        // Axele de coordonate desenate folosind un singur apel GL.Begin().
        private void DrawAxes()
        {
            GL.LineWidth(2.0f);
  
            GL.Begin(PrimitiveType.Lines);
            // Desenează axa Ox (cu roșu).
            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(XYZ_SIZE, 0, 0);

            // Desenează axa Oy (cu galben).
            GL.Color3(Color.Yellow);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, XYZ_SIZE, 0); ;

            // Desenează axa Oz (cu verde).
            GL.Color3(Color.Green);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, XYZ_SIZE);
            GL.End();
        }

         private void DrawTriangle()
         {
             GL.Begin(PrimitiveType.TriangleStrip);

             GL.Color3(color);
             GL.Vertex3(2f, 1.0f, 6.0f);
            GL.Vertex3(6f, 1.0f, 2.0f);
            GL.Vertex3(4.0f, 7f, 5.0f);
             GL.End();
         }
        

        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("\n ===================================");
            Console.WriteLine(" S - schimbare culoare triunghiului. ");
            Console.WriteLine(" ===================================");
            using (SimpleWindow3D example = new SimpleWindow3D())
            {
                example.Run(30.0, 0.0);
            }
        }



    }
}
