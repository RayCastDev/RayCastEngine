using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.Buffers
{
    public class VertexAttribute
    {
        private readonly string name;
        private readonly int size;
        private readonly VertexAttribPointerType type;
        private readonly bool normalized;
        private readonly int stride;
        private readonly int offset;

        public VertexAttribute(string name, int size, VertexAttribPointerType type, bool normalized, int stride, int offset)
        {
            this.name = name;
            this.size = size;
            this.type = type;
            this.stride = stride;
            this.offset = offset;
            this.normalized = normalized;
        }

        public void Set(Shader shader)
        {
            var index = shader.GetAttributeLocation(name);
            GL.EnableVertexAttribArray(index);
            GL.VertexAttribPointer(index, size, type, normalized, stride, offset);
            GL.EnableVertexAttribArray(0);
        }
    }
}
