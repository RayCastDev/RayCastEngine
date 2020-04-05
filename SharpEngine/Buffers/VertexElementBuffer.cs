using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;

namespace SharpEngine.Buffers
{
    public class VertexElementBuffer
    {
        private int Handle;
        public  uint[] indicies;

        public VertexElementBuffer(uint[] indicies)
        {
            Handle = GL.GenBuffer();
            this.indicies = indicies;
        }

        public void BindBuffer()
        {
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, Handle);
        }


        public void BufferData()
        {
            GL.BufferData(BufferTarget.ElementArrayBuffer, indicies.Length * sizeof(uint), indicies, BufferUsageHint.StaticDraw);
        }

        public void CrealHandle()
        {
            GL.DeleteBuffer(Handle);
        }
    }
}
