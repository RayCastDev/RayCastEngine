﻿using OpenTK;
using SharpEngine.Components.Base;

namespace SharpEngine.Components
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
