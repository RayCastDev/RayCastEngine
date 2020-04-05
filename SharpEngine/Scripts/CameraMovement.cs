using OpenTK;
using OpenTK.Input;
using SharpEngine.Abstracts;
using SharpEngine.Architect;
using SharpEngine.Cameras;
using SharpEngine.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.Scripts
{
    public class CameraMovement: Component
    {
        Transform transform;
        Camera camera;

        bool FirstMove = true;
        Vector2 lastPos;


        public override void OnUpdateFrame()
        {
            KeyboardState input = Keyboard.GetState();

            float Speed = camera.CameraSpeed * Time.deltaTime;

            if (input.IsKeyDown(Key.W))
            {
                transform.Position += camera.Front * Speed;
            }
            if (input.IsKeyDown(Key.S))
            {
                transform.Position -= camera.Front * Speed;
            }
            if (input.IsKeyDown(Key.D))
            {
                transform.Position += camera.Right * Speed;
            }
            if (input.IsKeyDown(Key.A))
            {
                transform.Position -= camera.Right * Speed;
            }
            if (input.IsKeyDown(Key.Q))
            {
                transform.Position += camera.Up * Speed;
            }
            if (input.IsKeyDown(Key.E))
            {
                transform.Position -= camera.Up * Speed;
            }

            if (!camera.CanFly)
                transform.Position.Y = 0.0f;
        }

        public override void OnMouseMove()
        {
            var mouse = Mouse.GetState();

            if (FirstMove)
            {
                lastPos = new Vector2(mouse.X, mouse.Y);
                FirstMove = false;
            }

            float deltaX = mouse.X - lastPos.X;
            float deltaY = mouse.Y - lastPos.Y;
            lastPos = new Vector2(mouse.X, mouse.Y);

            camera.ProcessLooking(deltaX, deltaY, Time.deltaTime);
        }

        public override void Start()
        {
            camera = owner as Camera;
            transform = owner.GetComponent<Transform>();
            Console.WriteLine("Camera Loaded");
        }
    }
}
