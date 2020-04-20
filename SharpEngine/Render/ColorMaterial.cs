using OpenTK;
using SharpEngine.Components;
using SharpEngine.Render.Base;

namespace SharpEngine.Render
{
    public class ColorMaterial : Material
    {
        public Vector3 Color;

        public ColorMaterial(Shader shader, Vector3 color)
        {
            Shader = shader;
            this.Color = color;
        }

        public override void SetMaterialParams(Camera camera, Light light, Transform modelTransform)
        {
            Shader.Use();
            Shader.SetVector3("lightColor", Color);

            base.SetMaterialParams(camera,light,modelTransform);
        }

        public override void ClearHandles()
        {

        }
    }
}
