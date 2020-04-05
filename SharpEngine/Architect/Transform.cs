using OpenTK;
using SharpEngine.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.Architect
{
    public class Transform : Component
    {
        public Vector3 Position;
        public Vector3 Rotation;
        public Vector3 Scaling;

        public Transform(Vector3 position, Vector3 rotation, Vector3 scaling)
        {
            Position = position;
            Rotation = rotation;
            Scaling = scaling;
        }

    }
}
