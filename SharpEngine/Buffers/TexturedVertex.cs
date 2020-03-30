using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.Buffers
{
    public struct TexturedVertex
    {
        public const int Size = (3+2)*4;

        private readonly Vector3 vertPosition;
        private readonly Vector2 texturePosition;

        public TexturedVertex (Vector3 vertPosition, Vector2 texturePosition)
        {
            this.vertPosition = vertPosition;
            this.texturePosition = texturePosition;
        }       
        
    }
}
