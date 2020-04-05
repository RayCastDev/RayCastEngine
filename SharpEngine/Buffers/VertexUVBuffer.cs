using OpenTK;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.Buffers
{
    public class VertexUVBuffer
    {
        public int Handle;
        private Vector2[] vertices;

        public VertexUVBuffer(Vector2[] vertices)
        {
            this.Handle = GL.GenBuffer();
            this.vertices = vertices;
        }

        //public void AddVertices(float[] v)
        //{
        //    vertices = v;
        //}

        public void BindBuffer()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, Handle);
        }

        public void BufferData()
        {
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * 2 * sizeof(float), vertices, BufferUsageHint.StaticDraw);
        }

        public void CrealHandle()
        {
            GL.DeleteBuffer(Handle);
        }
        //public void Draw()
        //{
        //    GL.DrawArrays(PrimitiveType.Triangles, 0, vertices.Length * 2);
        //}
    }
}
