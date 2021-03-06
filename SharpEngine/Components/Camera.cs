﻿using System;
using OpenTK;
using SharpEngine.Components.Base;

namespace SharpEngine.Components
{
    public class Camera : Component
    {        
        private Vector3 _front = -Vector3.UnitZ;
        private Vector3 _up = Vector3.UnitY;
        private Vector3 _right = Vector3.UnitX;

        private float _pitch;
        private float _yaw;
        private float _fov = MathHelper.DegreesToRadians(45);

        public Camera(float aspectRatio, bool canFly = true ,float cameraSpeed = 1.5f, float mouseSensitivity = 2.0f)
        {
            AspectRatio = aspectRatio;
            CameraSpeed = cameraSpeed;
            CanFly = canFly;
            MouseSensitivity = mouseSensitivity;
        }

        public override void Start()
        {
            _yaw = MathHelper.DegreesToRadians(owner.Transform.Rotation.Y);
            _pitch = MathHelper.DegreesToRadians(owner.Transform.Rotation.X);
        }

        public float CameraSpeed { get; set; }
        //public Vector3 Position;
        public float AspectRatio {private get; set;}
        public float MouseSensitivity;
        public Vector3 Front => _front;
        public Vector3 Up => _up;
        public Vector3 Right => _right;

        public bool CanFly;

        public float Pitch
        {
            get
            {
               return MathHelper.RadiansToDegrees(_pitch);
            }
            set
            {
                float angle = MathHelper.Clamp(value, -89f, 89f);
                _pitch = MathHelper.DegreesToRadians(angle);
                UpdateCameraViewDirection();
            }
        }

        public float Yaw
        {
            get
            {
                return MathHelper.RadiansToDegrees(_yaw);
            }
            set
            {
                _yaw = MathHelper.DegreesToRadians(value);
                UpdateCameraViewDirection();
            }
        }

        public float FOV
        {
            get
            {
                return MathHelper.RadiansToDegrees(_fov);
            }
            set
            {
                var angle = MathHelper.Clamp(value, 1f, 45f);
                _fov = MathHelper.DegreesToRadians(angle);
            }
        }

        public Matrix4 GetViewMatrix()
        {
            return Matrix4.LookAt(owner.Transform.Position, owner.Transform.Position + _front, _up);
        }

        public Matrix4 GetProjectionMatrix()
        {
            return Matrix4.CreatePerspectiveFieldOfView(_fov, AspectRatio, 0.01f, 100f);
        }

        private void UpdateCameraViewDirection()
        {
            _front.X = (float)Math.Cos(_pitch) * (float)Math.Cos(_yaw);
            _front.Y = (float)Math.Sin(_pitch);           
            _front.Z = (float)Math.Cos(_pitch) * (float)Math.Sin(_yaw);

            _front = _front.Normalized();

            _right = Vector3.Cross(_front, Vector3.UnitY).Normalized();
            _up = Vector3.Cross(_right, _front).Normalized();
        }     

        public void ProcessLooking(float xoffset,float yoffset, float deltaTime)
        {
            Yaw += xoffset * MouseSensitivity * deltaTime;
            Pitch -= yoffset * MouseSensitivity * deltaTime;
        }
    }
}
