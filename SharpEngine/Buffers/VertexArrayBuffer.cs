using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;

namespace SharpEngine.Buffers
{
    public class VertexArrayBuffer
    {
        private int Handle;

        public VertexArrayBuffer()
        {
            Handle = GL.GenVertexArray();
        }

        public void Bind()
        {
            GL.BindVertexArray(Handle);
        }

        public void CrealHandle()
        {
            GL.DeleteVertexArray(Handle);
        }
    }
}
