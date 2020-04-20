using OpenTK;
using SharpEngine.Components;

namespace SharpEngine.Render.Base
{
    public abstract class Material
    {
        public Shader Shader;

        protected void SetModel(Transform modelTransform)
        {
            Matrix4 modelRender = Matrix4.CreateScale(modelTransform.Scaling);
            modelRender *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(modelTransform.Rotation.X));
            modelRender *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(modelTransform.Rotation.Y));
            modelRender *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(modelTransform.Rotation.Z));
            modelRender *= Matrix4.CreateTranslation(modelTransform.Position);
            Shader.SetMatrix4("model", modelRender);
        }

        protected void SetProjection(Camera camera)
        {
            Shader.SetMatrix4("projection", camera.GetProjectionMatrix());
        }

        protected void SetView(Camera camera)
        {
            Shader.SetMatrix4("view", camera.GetViewMatrix());
        }

        public virtual void SetMaterialParams(Camera camera, Light light, Transform modelTransform)
        {
            SetModel(modelTransform);
            SetProjection(camera);
            SetView(camera);
        }
        public abstract void ClearHandles();
    }
}
