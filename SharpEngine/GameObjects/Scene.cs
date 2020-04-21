using System.Collections.Generic;
using SharpEngine.Components;

namespace SharpEngine.GameObjects
{
    public class Scene
    {
        private readonly List<GameObject> gameObjects;
        private readonly List<MeshRenderer> meshRenderers;

        public Camera MainCamera;
        public List<Light> Lights;

        public Scene()
        {
            gameObjects = new List<GameObject>();
            meshRenderers = new List<MeshRenderer>();
            Lights = new List<Light>();
        }

        public void AddGameObject(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
            MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderers.Add(meshRenderer);
            }

            Light light = gameObject.GetComponent<Light>();
            if (light != null)
            {
                Lights.Add(light);
            }

            Camera camera = gameObject.GetComponent<Camera>();
            if (camera != null)
            {
                MainCamera = camera;
            }
        }

        public void DrawScene()
        {
            foreach(var meshRenderer in meshRenderers)
            {
                meshRenderer.RenderMesh(MainCamera, Lights);
            }
        }

        public void StartComponents()
        {
            foreach (var gameObject in gameObjects)
            {
                gameObject.StartComponents();
            }
        }

        public void OnUpdateFrameComponents()
        {
            foreach (var gameObject in gameObjects)
            {
                gameObject.OnUpdateFrameComponents();
            }
        }

        public void OnMouseMoveComponents()
        {
            foreach (var gameObject in gameObjects)
            {
                gameObject.OnMouseMoveComponents();
            }
        }

        public void ClearHandles()
        {
            foreach (var meshRenderer in meshRenderers)
            {
               meshRenderer.ClearHandles();
            }
        }
    }
}
