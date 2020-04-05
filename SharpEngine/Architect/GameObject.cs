using OpenTK;
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

        public GameObject(Transform trans = null)
        {
            if (trans != null)
                this.transform = trans;
            else
                this.transform = new Transform(Vector3.Zero, Vector3.Zero, Vector3.Zero);
        }
    }
}
