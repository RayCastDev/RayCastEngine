using OpenTK;
using OpenTK.Input;
using SharpEngine.Helpers;
using System;
using SharpEngine.Components;
using SharpEngine.Components.Base;

namespace SharpEngine.Scripts
{
    public class CameraMovement: Component
    {
        private Transform transform;
        private Camera camera;

        private bool firstMove = true;
        private Vector2 lastPos;


        public override void OnUpdateFrame()
        {
            KeyboardState input = Keyboard.GetState();

            float speed = camera.CameraSpeed * Time.deltaTime;

            if (input.IsKeyDown(Key.W))
            {
                transform.Position += camera.Front * speed;
            }
            if (input.IsKeyDown(Key.S))
            {
                transform.Position -= camera.Front * speed;
            }
            if (input.IsKeyDown(Key.D))
            {
                transform.Position += camera.Right * speed;
            }
            if (input.IsKeyDown(Key.A))
            {
                transform.Position -= camera.Right * speed;
            }
            if (input.IsKeyDown(Key.Q))
            {
                transform.Position += camera.Up * speed;
            }
            if (input.IsKeyDown(Key.E))
            {
                transform.Position -= camera.Up * speed;
            }

            if (!camera.CanFly)
                transform.Position.Y = 0.0f;
        }

        public override void OnMouseMove()
        {
            var mouse = Mouse.GetState();

            if (firstMove)
            {
                lastPos = new Vector2(mouse.X, mouse.Y);
                firstMove = false;
            }

            float deltaX = mouse.X - lastPos.X;
            float deltaY = mouse.Y - lastPos.Y;
            lastPos = new Vector2(mouse.X, mouse.Y);

            camera.ProcessLooking(deltaX, deltaY, Time.deltaTime);
        }

        public override void Start()
        {
            camera = owner.GetComponent<Camera>();
            transform = owner.Transform;
            Console.WriteLine("Camera Loaded");
        }
    }
}
