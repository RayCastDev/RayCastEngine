using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.Architect
{
    public class Transform
    {
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public Vector3 Scaling { get; set; }

        public Transform(Vector3 position, Vector3 rotation, Vector3 scaling)
        {
            Position = position;
            Rotation = rotation;
            Scaling = scaling;
        }

    }
}
