using OpenTK.Input;
using SharpEngine.Abstracts;
using SharpEngine.Architect;
using SharpEngine.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.Scripts
{
    public class HouseMovement : Component
    {
        Transform transform;
        public override void OnUpdateFrame()
        {
            KeyboardState input = Keyboard.GetState();

            if(input.IsKeyDown(Key.Up))
            {
                transform.Position.Z += 2 * Time.deltaTime;
            }
            if (input.IsKeyDown(Key.Down))
            {
                transform.Position.Z -= 2 * Time.deltaTime;
            }
        }

        public  override void Start()
        {
            transform = owner.GetComponent<Transform>();
            Console.WriteLine("House Loaded");
        }

    }
}
