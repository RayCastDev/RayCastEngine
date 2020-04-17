using SharpEngine.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            

            using (Game game = new Game(1280, 720, "SharpEngine"))
            {
                game.VSync = OpenTK.VSyncMode.On;
                game.Run(60);
            }
        }
    }
}
