using OpenTK;
using SharpEngine.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.Architect
{
    public class GameObject
    {
        public Transform transform;

        public List<Component> components;

        public GameObject(Transform trans = null)
        {
            components = new List<Component>();
            if (trans != null)
                this.transform = trans;
            else
                this.transform = new Transform(Vector3.Zero,Vector3.Zero,Vector3.One);

            components.Add(transform);
        }

        public void AddComponent(Component component)
        {
            component.owner = this;
            components.Add(component);
        }

        public T GetComponent<T>() where T : Component
        {
            return components.Find(x => typeof(T) == x.GetType()) as T;
            //foreach(Component component in components)
            //{
            //    if(typeof(T) == component.GetType())
            //    {
            //        return component as T;
            //    }
            //}
            //return null;
        }

        public void StartComponents()
        {
            foreach (Component component in components)
            {
                component.Start();
            }
        }

        public void OnUpdateFrameComponents()
        {
            foreach (Component component in components)
            {
                component.OnUpdateFrame();
            }
        }

        public void OnMouseMoveComponents()
        {
            foreach (Component component in components)
            {
                component.OnMouseMove();
            }
        }
    }
}
