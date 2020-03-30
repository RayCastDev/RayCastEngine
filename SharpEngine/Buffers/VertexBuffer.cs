using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.Buffers
{
    public class VertexBuffer
    {
        public int Handle;
        private float[] vertices;

        public VertexBuffer(float[] vertices)
        {
            this.Handle = GL.GenBuffer();
            this.vertices = vertices;
        }

        public void AddVertices(float[] v)
        {
            vertices = v;
        }

        public void BindBuffer()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, Handle);
        }

        public void BufferData()
        {
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
        }

        public void Draw()
        {
            GL.DrawArrays(PrimitiveType.Triangles, 0, vertices.Length);
        }
    }
}
