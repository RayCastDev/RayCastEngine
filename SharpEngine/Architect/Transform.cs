using OpenTK;
using SharpEngine.Abstracts;

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
