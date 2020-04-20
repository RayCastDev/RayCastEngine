using System.Collections.Generic;
using OpenTK;
using SharpEngine.Components;
using SharpEngine.Components.Base;

namespace SharpEngine.GameObjects
{
    public class GameObject
    {
        public Transform Transform;
        public Transform LocalTransform;

        public List<Component> Components;

        public GameObject Parent;
        public List<GameObject> Children;


        public GameObject(Transform trans = null, Transform localTransform = null)
        {
            Components = new List<Component>();
            Children = new List<GameObject>();

            this.Transform = trans ?? new Transform(Vector3.Zero,Vector3.Zero,Vector3.One);
            this.LocalTransform = localTransform ?? new Transform(Vector3.Zero,Vector3.Zero,Vector3.One);
        }

        public void AddComponent(Component component)
        {
            component.owner = this;
            Components.Add(component);
        }

        public void AddChild(GameObject gameObject)
        {
            gameObject.Parent = this;
            Children.Add(gameObject);
        }

        public void RemoveComponent(Component component)
        {
            component.owner = null;
            Components.Remove(component);
        }

        public T GetComponent<T>() where T : Component
        {
            return Components.Find(x => typeof(T) == x.GetType()) as T;
        }

        public void StartComponents()
        {
            foreach (Component component in Components)
            {
                component.Start();
            }
        }

        public void OnUpdateFrameComponents()
        {
            foreach (var child in Children)
            {
                child.Transform.Position = Transform.Position + child.LocalTransform.Position;
            }

            foreach (Component component in Components)
            {
                component.OnUpdateFrame();
            }
        }

        public void OnMouseMoveComponents()
        {
            foreach (Component component in Components)
            {
                component.OnMouseMove();
            }
        }
    }
}
