using SharpEngine.Cameras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.Architect
{
    public class Scene
    {
        List<Model> models;
        Camera camera;

        public Scene()
        {
            this.models = new List<Model>();
        }

        public void AddModel(Model model)
        {
            models.Add(model);
        }

        public void SetCamera(Camera camera)
        {
            this.camera = camera;
        }

        public void DrawScene()
        {
            foreach(Model model in models)
            {
                RenderManager.Draw(model,camera);
            }
        }

        public void StartComponents()
        {
            foreach (Model model in models)
            {
                model.StartComponents();
            }
        }

        public void OnUpdateFrameComponents()
        {
            foreach (Model model in models)
            {
                model.OnUpdateFrameComponents();
            }
        }

        public void ClearHandles()
        {
            foreach(Model model in models)
            {
                model.mesh.ClearHandles();
                model.material.DeleteTextures();
            }
        }
    }
}
