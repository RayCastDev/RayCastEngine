using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.Buffers
{
    public class VertexArray
    {
        public readonly int Handle;
        public VertexBuffer VertexBuffer;

        Texture[] Textures;

        public VertexArray(VertexBuffer vertexBuffer, Shader shader,Texture[] textures ,params VertexAttribute[] attributes)
        {
            GL.GenVertexArrays(1, out Handle);           
            VertexBuffer = vertexBuffer;
            this.Textures = textures;
            Bind();
            VertexBuffer.BindBuffer();
            VertexBuffer.BufferData();
            foreach(var attribute in attributes)
            {
                attribute.Set(shader);
            }

            foreach(var text in textures)
            {
                shader.SetInt("texture1", 0);
                shader.SetInt("texture2", 1);
            }

            GL.BindVertexArray(0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        public void Bind()
        {
            GL.BindTexture(TextureTarget.Texture2D, 0);
            int x = 33984;
            GL.BindVertexArray(Handle);
            foreach (Texture text in Textures)
            {
                text.Use((TextureUnit)x);
                x++;
            }
        }

        public void Draw()
        {
            VertexBuffer.Draw();
        }

        public void ClearHandls()
        {
            foreach (Texture text in Textures)
            {
                GL.DeleteTexture(text.Handle);
            }
            GL.DeleteBuffer(VertexBuffer.Handle);
            GL.DeleteBuffer(Handle);
        }

    }
}
