using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;

namespace SharpEngine.Buffers
{
    internal class VertexArrayObject
    {
        private readonly int handle;

        public VertexArrayObject()
        {
            handle = GL.GenVertexArray();
        }

        public void Bind()
        {
            GL.BindVertexArray(handle);
        }

        public void ClearHandle()
        {
            GL.DeleteVertexArray(handle);
        }
    }
}
