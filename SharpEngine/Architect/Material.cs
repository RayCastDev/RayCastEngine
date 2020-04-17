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
        public Vector3 ambient;
        public Vector3 diffuse;
        public Vector3 specular;
        public float shininess;

        public Vector3 lightAmbient;
        public Vector3 lightDiffuse;
        public Vector3 lightSpecular;
        public Vector3 lightDirection;

        public float constatnt;
        public float linear;
        public float qudratic;


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


        public void SetMaterialParams()
        {
            if (ambient != Vector3.Zero && 
                specular != Vector3.Zero && 
                diffuse != Vector3.Zero && 
                shininess != 0 &&

                lightAmbient != Vector3.Zero &&
                lightDiffuse != Vector3.Zero &&
                lightSpecular != Vector3.Zero &&
                lightDirection != Vector3.Zero&&

                constatnt != 0 &&
                linear != 0 &&
                qudratic != 0)
            {
                shader.SetVector3("material.ambient", ambient);
                shader.SetVector3("material.specular", specular);
                shader.SetVector3("material.diffuse", diffuse);
                shader.SetFloat("material.shininess", shininess);

                shader.SetVector3("light.diffuse", lightDiffuse);
                shader.SetVector3("light.specular", lightSpecular);
                shader.SetVector3("light.ambient", lightAmbient);
                shader.SetVector3("light.direction", lightDirection);

                shader.SetFloat("light.constant", constatnt);
                shader.SetFloat("light.linear", linear);
                shader.SetFloat("light.quadratic", qudratic);
            }
        }

        public void SetTextures()
        {
            if (textures != null)
            {
                foreach (var text in textures)
                {
                    shader.SetInt("material.diffuse", 0);
                    shader.SetInt("material.specular", 1);
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
