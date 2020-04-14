using OpenTK;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.Buffers
{
    class VertexNormalBuffer
    {
        public int Handle;
        private Vector3[] normals;

        public VertexNormalBuffer(Vector3[] normals)
        {
            this.Handle = GL.GenBuffer();
            this.normals = normals;
        }

        public void BindBuffer()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, Handle);
        }

        public void BufferData()
        {
            GL.BufferData(BufferTarget.ArrayBuffer, normals.Length * 3 * sizeof(float), normals, BufferUsageHint.StaticDraw);
        }

        public void CrealHandle()
        {
            GL.DeleteBuffer(Handle);
        }

    }
}
