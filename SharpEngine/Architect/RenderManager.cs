using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using SharpEngine.Cameras;

namespace SharpEngine.Architect
{
    class RenderManager
    {
        public static void Draw(Model model, Camera camera)
        {
            model.mesh.VAO.Bind();

            model.material.shader.Use();
            model.material.shader.SetMatrix4("view", camera.GetViewMatrix());
            model.material.shader.SetMatrix4("projection", camera.GetProjectionMatrix());


            Matrix4 model_render = Matrix4.CreateScale(model.transform.Scaling);

            model_render *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(model.transform.Rotation.X));
            model_render *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(model.transform.Rotation.Y));
            model_render *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(model.transform.Rotation.Z));

            model_render *= Matrix4.CreateTranslation(model.transform.Position);








            model.material.shader.SetMatrix4("model", model_render);

            model.material.BindTexture();
            model.material.SetTextures();

            GL.DrawElements(PrimitiveType.Triangles, model.mesh.EBO.indicies.Length, DrawElementsType.UnsignedInt, 0);
        }
    }
}
