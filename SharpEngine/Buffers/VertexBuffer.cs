using OpenTK;
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
        public int HandleEBO;
        private Vector3[] vertices;
        private uint[] indicies;

        public VertexBuffer(Vector3[] vertices, uint[] ind = null)
        {
            this.Handle = GL.GenBuffer();
            this.HandleEBO = GL.GenBuffer();
            this.vertices = vertices;
            this.indicies = ind;
        }

        //public void AddVertices(float[] v)
        //{
        //    vertices = v;
        //}

        public void BindBuffer()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, Handle);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, HandleEBO);
        }

        public void BufferData()
        {
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * 3 * sizeof(float), vertices, BufferUsageHint.StaticDraw);
            if (indicies != null)
            {
                GL.BufferData(BufferTarget.ElementArrayBuffer, indicies.Length * sizeof(uint), indicies, BufferUsageHint.StaticDraw);
            }
        }

        public void Draw()
        {
            if (indicies != null)
            {
                GL.DrawElements(PrimitiveType.Triangles, indicies.Length, DrawElementsType.UnsignedInt, 0);
            }
            else
            {
                GL.DrawArrays(PrimitiveType.Triangles, 0, vertices.Length * 3);
            }
        }

    }
}
