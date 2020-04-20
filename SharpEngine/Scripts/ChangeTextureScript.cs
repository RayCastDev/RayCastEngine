using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpEngine.Components;
using SharpEngine.Components.Base;
using SharpEngine.Render;

namespace SharpEngine.Scripts
{
    public class ChangeTextureScript : Component
    {
        bool materialChanged = false;
        Texture texture1;
        Texture texture2;
        MaterialModel mat;
        public override void Start()
        {
            texture1 = new Texture("Resources/Textures/house.png");
            texture2 = new Texture("Resources/Textures/checker.jpg");
            mat = owner.GetComponent<MeshRenderer>().Material as MaterialModel;
        }
        public override void OnUpdateFrame()
        {
            KeyboardState input = Keyboard.GetState();

            if (input.IsKeyDown(Key.T))
            {
                if (!materialChanged)
                {
                    mat.Textures[0] = texture1;
                    materialChanged = true;
                }
            }
            if (input.IsKeyDown(Key.Y))
            {
                if (materialChanged)
                {
                    mat.Textures[0] = texture2;
                    materialChanged = false;
                }
            }
        }
    }
}
