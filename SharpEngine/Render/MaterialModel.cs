using OpenTK;
using OpenTK.Graphics.OpenGL4;
using SharpEngine.Components;
using SharpEngine.Render.Base;

namespace SharpEngine.Render
{
    public class MaterialModel : Material
    {
        public Vector3 Ambient;
        public Vector3 Diffuse;
        public Vector3 Specular;

        public float Shininess;

        public Texture[] Textures;

        public MaterialModel(Shader shader, Texture[] textures)
        {
            Shader = shader;
            Textures = textures;
        }

        public override void SetMaterialParams(Camera camera, Light light, Transform modelTransform)
        {
            Shader.Use();
            Shader.SetVector3("material.ambient", Ambient);
            Shader.SetVector3("material.specular", Specular);
            Shader.SetVector3("material.diffuse", Diffuse);
            Shader.SetFloat("material.shininess", Shininess);

            SetLight(light);

            BindTexture();
            SetTextures();
            SetupViewPosition(camera.owner.Transform.Position);


            base.SetMaterialParams(camera,light,modelTransform);
        }

        public void SetLight(Light light)
        {
            Shader.SetVector3("light.diffuse", light.LightColor);
            Shader.SetVector3("light.ambient", light.LightColor);
            Shader.SetVector3("light.specular", light.LightSpecular);

            Shader.SetVector3("light.position", light.owner.Transform.Position);
            Shader.SetVector3("light.direction", light.owner.Transform.Rotation);

            Shader.SetFloat("light.constant", light.Constant);
            Shader.SetFloat("light.linear", light.Linear);
            Shader.SetFloat("light.quadratic", light.Quadratic);
        }


        public void SetupViewPosition(Vector3 viewPosition) => Shader.SetVector3("viewPos", viewPosition);

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

        public override void ClearHandles()
        {
            if (Textures == null) return;
            foreach (var text in Textures)
                if (text != null)
                    GL.DeleteTexture(text.Handle);
        }
    }
}