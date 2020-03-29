using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.Abstracts
{
    public interface IInputHandler
    {
        bool MoveForward { get; set; }
        bool MoveBackward { get; set; }
        bool MoveLeft { get; set; }
        bool MoveRight { get; set; }
        bool MoveUp { get; set; }
        bool MoveDown { get; set; }

        bool Exit { get; set; }



        void ProcessInput();

    }
}
