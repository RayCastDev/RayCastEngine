using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using SharpEngine.Abstracts;

namespace SharpEngine.Architect
{
    public class Material : Component
    {
        public Shader shader;
        public Texture[] textures;

        public Material(Shader shader, Texture[] textures)
        {
            this.shader = shader;
            this.textures = textures;
        }

        public void SetTextures()
        {
            foreach (var text in textures)
            {
                shader.SetInt("texture1", 0);
                shader.SetInt("texture2", 1);
            }
        }

        public void BindTexture()
        {
            GL.BindTexture(TextureTarget.Texture2D, 0);
            int x = 33984;
            foreach (Texture text in textures)
            {
                text.Use((TextureUnit)x);
                x++;
            }
        }

        public void DeleteTextures()
        {
            foreach (Texture text in textures)
            {
                if (text != null)
                {
                    GL.DeleteTexture(text.Handle);                 
                }
            }
        }
    }
}
