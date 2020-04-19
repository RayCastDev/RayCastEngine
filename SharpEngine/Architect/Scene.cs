using System.Collections.Generic;
using SharpEngine.Cameras;

namespace SharpEngine.Architect
{
    public class Scene
    {
        private readonly List<Model> models;
        public Camera Camera;
        public Model LightPoint;

        public Scene()
        {
            models = new List<Model>();
        }

        public void AddModel(Model model)
        {
            models.Add(model);
        }

        public void SetCamera(Camera camera)
        {
            Camera = camera;
        }

        public void SetLight(Model light)
        {
            LightPoint = light;
        }

        public void DrawScene()
        {
            foreach(var model in models)
            {
                RenderManager.Draw(model,Camera, LightPoint);
            }
        }

        public void StartComponents()
        {
            Camera.StartComponents();
            foreach (var model in models)
            {
                model.StartComponents();
            }
        }

        public void OnUpdateFrameComponents()
        {
            Camera.OnUpdateFrameComponents();
            foreach (var model in models)
            {
                model.OnUpdateFrameComponents();
            }
        }

        public void OnMouseMoveComponents()
        {
            Camera.OnMouseMoveComponents();
            foreach (var model in models)
            {            
                model.OnMouseMoveComponents();
            }
        }

        public void ClearHandles()
        {
            foreach(var model in models)
            {
                model.Mesh.ClearHandles();
                model.Material.DeleteTextures();
            }
        }
    }
}
