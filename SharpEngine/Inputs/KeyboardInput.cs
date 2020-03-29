using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Input;
using SharpEngine.Abstracts;

namespace SharpEngine.Inputs
{
    public class KeyboardInput : IInputHandler
    {
        public bool MoveForward { get; set; }
        public bool MoveBackward { get; set; }
        public bool MoveLeft { get; set; }
        public bool MoveRight { get; set; }
        public bool MoveUp { get; set; }
        public bool MoveDown { get; set; }
        public bool Exit { get; set; }

        public void ProcessInput()
        {
            KeyboardState input = Keyboard.GetState();
            if (input.IsKeyDown(Key.W))
                MoveForward = true;
            else
                MoveForward = false;

            if (input.IsKeyDown(Key.S))
                MoveBackward = true;
            else
                MoveBackward = false;

            if (input.IsKeyDown(Key.D))
                MoveRight = true;
            else
                MoveRight = false;

            if (input.IsKeyDown(Key.A))
                MoveLeft = true;
            else
                MoveLeft = false;

            if (input.IsKeyDown(Key.Escape))
                Exit = true;
            else
                Exit = false;

            if (input.IsKeyDown(Key.Space))
                MoveUp = true;
            else
                MoveUp = false;

            if (input.IsKeyDown(Key.LAlt))
                MoveDown = true;
            else
                MoveDown = false;
        }
    }
}
