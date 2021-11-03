using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace Grigoriu
{
    class Axe
    {
        private bool myVisibility;

        private const int AXIS_LENGTH = 75;
        public Axe()
        {
            myVisibility = true;
        }
        public void DrawAxe()
        {
            if (myVisibility)
            {
                GL.LineWidth(1.0f);
                // Axele de coordonate desenate folosind un singur apel GL.Begin().
                GL.Begin(PrimitiveType.Lines);
                GL.Color3(Color.Red);
                GL.Vertex3(5, 5, 5);
                GL.Vertex3(AXIS_LENGTH, 5, 5);

                GL.Color3(Color.ForestGreen);
                GL.Vertex3(5, 5, 5);
                GL.Vertex3(5, AXIS_LENGTH, 5);

                GL.Color3(Color.RoyalBlue);
                GL.Vertex3(5, 5, 5);
                GL.Vertex3(5, 5, AXIS_LENGTH);
                GL.End();
            }
        }

        public void Show()
        {
            myVisibility = true;
        }

        public void Hide()
        {
            myVisibility = false;
        }

        public void ToggleVisibility()
        {
            myVisibility = !myVisibility;
        }
    }
}

