using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.Meshes
{
    public class Triangle
    {
        public static readonly float[] vertices =
        {
            -0.9f, -0.5f, 0.0f,       0.0f, 0.0f, // Left 
            -0.0f, -0.5f, 0.0f,       1.0f, 0.0f, // Right
            -0.45f, 0.5f, 0.0f,       0.5f, 1.0f  // Top 
        };
    }
}
