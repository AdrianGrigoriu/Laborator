/*
 Grigoriu Adrian
 Grupa 3132B
 Laborator 4
 */


using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Grigoriu
{
    class Program
    { 
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("\n ==========================");
            Console.WriteLine(" S - schimba culoarea  ");
            Console.WriteLine(" ===========================");
            using (Window3D example = new Window3D())
            {
                example.Run(30.0, 0.0);
            }
        }



    }
}
