using OpenTK;
using OpenTK.Graphics.OpenGL4;
using SharpEngine.Abstracts;

namespace SharpEngine.Architect
{
    public class Material : Component
    {
        public Vector3 Ambient;

        public float Constant;
        public Vector3 Diffuse;

        public Vector3 LightAmbient;
        public Vector3 LightDiffuse;
        public Vector3 LightDirection;
        public Vector3 LightSpecular;
        public float Linear;
        public float Quadratic;


        public Shader Shader;
        public float Shininess;
        public Vector3 Specular;
        public Texture[] Textures;

        public Material(Shader shader)
        {
            this.Shader = shader;
        }

        public Material(Shader shader, Texture[] textures) : this(shader)
        {
            this.Textures = textures;
        }


        public void SetMaterialParams()
        {
            if (Ambient == Vector3.Zero || Specular == Vector3.Zero || Diffuse == Vector3.Zero || Shininess == 0 ||
                LightAmbient == Vector3.Zero || LightDiffuse == Vector3.Zero || LightSpecular == Vector3.Zero ||
                LightDirection == Vector3.Zero || Constant == 0 || Linear == 0 || Quadratic == 0) return;

            Shader.SetVector3("material.ambient", Ambient);
            Shader.SetVector3("material.specular", Specular);
            Shader.SetVector3("material.diffuse", Diffuse);
            Shader.SetFloat("material.shininess", Shininess);

            Shader.SetVector3("light.diffuse", LightDiffuse);
            Shader.SetVector3("light.specular", LightSpecular);
            Shader.SetVector3("light.ambient", LightAmbient);
            Shader.SetVector3("light.direction", LightDirection);

            Shader.SetFloat("light.constant", Constant);
            Shader.SetFloat("light.linear", Linear);
            Shader.SetFloat("light.quadratic", Quadratic);
        }

        public void SetTextures()
        {
            if (Textures == null) return;

            Shader.SetInt("material.diffuse", 0);
            Shader.SetInt("material.specular", 1);
        }

        public void BindTexture()
        {
            if (Textures == null) return;
            GL.BindTexture(TextureTarget.Texture2D, 0);
            var x = 33984;
            foreach (var text in Textures)
            {
                text.Use((TextureUnit) x);
                x++;
            }
        }

        public void DeleteTextures()
        {
            if (Textures == null) return;
            foreach (var text in Textures)
                if (text != null)
                    GL.DeleteTexture(text.Handle);
        }
    }
}