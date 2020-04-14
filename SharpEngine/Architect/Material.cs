using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using SharpEngine.Abstracts;

namespace SharpEngine.Architect
{
    public class Material : Component
    {
        public Vector3 objectColor;
        public Vector3 lightColor;

        public Shader shader;
        public Texture[] textures;

        public Material(Shader shader)
        {
            this.shader = shader;
        }

        public Material(Shader shader, Texture[] textures): this(shader)
        {
            this.textures = textures;
        }

        public Material(Vector3 baseColor, Vector3 lightColor, Shader shader):this(shader)
        {
            this.objectColor = baseColor;
            this.lightColor = lightColor;
        }


        public void SetColors()
        {
            if (objectColor != Vector3.Zero && lightColor != Vector3.Zero)
            {
                shader.SetVector3("objectColor", objectColor);
                shader.SetVector3("lightColor", lightColor);
            }
        }

        public void SetTextures()
        {
            if (textures != null)
            {
                foreach (var text in textures)
                {
                    shader.SetInt("texture1", 0);
                    shader.SetInt("texture2", 1);
                }
            }
        }

        public void BindTexture()
        {
            if (textures != null)
            {
                GL.BindTexture(TextureTarget.Texture2D, 0);
                int x = 33984;
                foreach (Texture text in textures)
                {
                    text.Use((TextureUnit)x);
                    x++;
                }
            }
        }

        public void DeleteTextures()
        {
            if (textures != null)
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
}
