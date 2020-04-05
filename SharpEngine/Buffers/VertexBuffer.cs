using OpenTK;
using OpenTK.Graphics.OpenGL4;
using SharpEngine.Helpers;
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
        private Vector3[] vertices;


        public VertexBuffer(Vector3[] vertices)
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
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * 3 * sizeof(float), vertices, BufferUsageHint.StaticDraw);

        }

        public void CrealHandle()
        {
            GL.DeleteBuffer(Handle);
        }

        //public void Draw()
        //{
        //    //if (indicies != null)
        //    //{
        //    //    GL.DrawElements(PrimitiveType.Triangles, indicies.Length, DrawElementsType.UnsignedInt, 0);
        //    //}
        //    //else
        //    //{
        //        GL.DrawArrays(PrimitiveType.Triangles, 0, vertices.Length * 3);
        //    //}
        //}

    }
}
