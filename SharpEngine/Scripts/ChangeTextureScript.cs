using OpenTK.Input;
using SharpEngine.Abstracts;
using SharpEngine.Architect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.Scripts
{
    public class ChangeTextureScript : Component
    {
        bool materialChanged = false;
        Texture texture1;
        Texture texture2;
        Material mat;
        public override void Start()
        {
            texture1 = new Texture("Resources/Textures/house.png");
            texture2 = new Texture("Resources/Textures/checker.jpg");
            mat = owner.GetComponent<Material>();
        }
        public override void OnUpdateFrame()
        {
            KeyboardState input = Keyboard.GetState();

            if (input.IsKeyDown(Key.T))
            {
                if (!materialChanged)
                {
                    mat.textures[0] = texture1;
                    materialChanged = true;
                }
            }
            if (input.IsKeyDown(Key.Y))
            {
                if (materialChanged)
                {
                    mat.textures[0] = texture2;
                    materialChanged = false;
                }
            }
        }
    }
}
