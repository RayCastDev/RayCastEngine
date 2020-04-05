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
            Matrix4 model_render = Matrix4.CreateTranslation(model.transform.Position);
            model.material.shader.SetMatrix4("model", model_render);

            model.material.BindTexture();
            model.material.SetTextures();

            GL.DrawElements(PrimitiveType.Triangles, model.mesh.EBO.indicies.Length, DrawElementsType.UnsignedInt, 0);
        }
    }
}
