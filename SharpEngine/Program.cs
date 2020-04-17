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
            

            using (Game game = new Game(960, 540, "SharpEngine"))
            {
                game.VSync = OpenTK.VSyncMode.Off;
                game.Run(120);
            }
        }
    }
}
