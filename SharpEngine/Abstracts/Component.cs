using SharpEngine.Architect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.Abstracts
{
    public class Component
    {
        public GameObject owner;
        public virtual void Start()
        {

        }
        public virtual void Update()
        {

        }
        public virtual void OnMouseMove()
        {

        }
        public virtual void OnUpdateFrame()
        {

        }
    }
}
