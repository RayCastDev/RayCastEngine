using OpenTK;
using OpenTK.Graphics.OpenGL4;
using SharpEngine.Cameras;

namespace SharpEngine.Architect
{
    public class RenderManager
    {
        public static void Draw(Model model, Camera camera, Model lightPoint)
        {
            model.Mesh.VertexArrayObject.Bind();

            model.Material.Shader.Use();
            model.Material.Shader.SetVector3("viewPos", camera.transform.Position);
            model.Material.SetMaterialParams();
            model.Material.Shader.SetVector3("light.position", lightPoint.transform.Position);

            model.Material.Shader.SetMatrix4("view", camera.GetViewMatrix());
            model.Material.Shader.SetMatrix4("projection", camera.GetProjectionMatrix());


            Matrix4 modelRender = Matrix4.CreateScale(model.transform.Scaling);

            modelRender *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(model.transform.Rotation.X));
            modelRender *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(model.transform.Rotation.Y));
            modelRender *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(model.transform.Rotation.Z));

            modelRender *= Matrix4.CreateTranslation(model.transform.Position);



           




            model.Material.Shader.SetMatrix4("model", modelRender);


           

            
            model.Material.BindTexture();
            model.Material.SetTextures();

            //GL.DrawElements(PrimitiveType.Triangles, model.Mesh.ElementBufferObject.indicies.Length, DrawElementsType.UnsignedInt, 0);
            GL.DrawElements(PrimitiveType.Triangles, model.Mesh.ElementBufferObject.VertexData.Length, DrawElementsType.UnsignedInt, 0);
        }
    }
}
