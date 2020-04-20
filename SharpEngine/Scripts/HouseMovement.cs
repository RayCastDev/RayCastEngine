using OpenTK.Input;
using SharpEngine.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpEngine.Components;
using SharpEngine.Components.Base;
using SharpEngine.GameObjects;

namespace SharpEngine.Scripts
{
    public class HouseMovement : Component
    {
        public GameObject gameObject;
        Transform transform;
        public override void OnUpdateFrame()
        {
            KeyboardState input = Keyboard.GetState();

            if(input.IsKeyDown(Key.Up))
            {
                if (gameObject != null)
                {
                    gameObject.Transform.Position.Z += 2 * Time.deltaTime;
                }

                transform.Position.Z += 2 * Time.deltaTime;
            }
            if (input.IsKeyDown(Key.Down))
            {
                transform.Position.Z -= 2 * Time.deltaTime;
            }

            if (input.IsKeyDown(Key.Left))
            {
                transform.Position.X -= 2 * Time.deltaTime;
            }
            if (input.IsKeyDown(Key.Right))
            {
                transform.Position.X += 2 * Time.deltaTime;
            }


            if (input.IsKeyDown(Key.X))
            {
                transform.Rotation.Y -= 5 * Time.deltaTime;
            }
            if (input.IsKeyDown(Key.C))
            {
                transform.Rotation.Y += 5 * Time.deltaTime;
            }
        }

        public  override void Start()
        {
            transform = owner.Transform;
            Console.WriteLine("House Loaded");
        }

    }
}
