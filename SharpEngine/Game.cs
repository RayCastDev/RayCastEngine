using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using SharpEngine.Architect;
using SharpEngine.Buffers;
using SharpEngine.Cameras;
using SharpEngine.Helpers;
using SharpEngine.Scripts;

namespace SharpEngine
{
    public class Game : GameWindow
    {

        public Scene Scene;

        public Camera Camera;
        public Shader Shader;
        public Shader LampShader;


 
        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            GL.Enable(EnableCap.DepthTest);

            InitScene();

            CursorVisible = false;
            base.OnLoad(e);
        }

        private void InitScene()
        {

            //string fileToRead = Environment.CurrentDirectory;
            Scene = new Scene();

            Camera = new Camera(new Transform(new Vector3(0,2,6), new Vector3(0,-90,0), Vector3.One), Width / (float)Height, true, 3.5f, 3);
            Camera.AddComponent(new CameraMovement());

            #region lightCube
            Shader = new Shader("Shaders/shader.vert", "Shaders/newShader.frag");
            LampShader = new Shader("Shaders/shader.vert", "Shaders/lamp.frag");

            // Texture boxTexture = new Texture("Resources/Textures/cubeText.png");
            // Texture boxTexture2 = new Texture("Resources/Textures/cubeSpec.png");

            // Material cubeMat = new Material(shader, new Texture[] { boxTexture , boxTexture2});
            // cubeMat.ambient = new Vector3(0.3f,0.5f,0.31f);
            // cubeMat.diffuse = new Vector3(0.3f, 0.5f, 0.31f);
            // cubeMat.specular = new Vector3(0.5f, 0.5f, 0.5f);
            // cubeMat.shininess = 32f;

            // cubeMat.lightAmbient = new Vector3(0.2f, 0.2f, 0.2f);
            // cubeMat.lightDiffuse = new Vector3(0.5f, 0.5f, 0.5f);
            // cubeMat.lightSpecular = new Vector3(1.0f, 1.0f, 1.0f);
            // cubeMat.lightDirection = new Vector3(0.5f, -0.5f, 0.5f);

            // cubeMat.linear = 0.09f;
            // cubeMat.constatnt = 1f;
            // cubeMat.qudratic = 0.032f;

             var lampMat = new Material(LampShader);

            var meshCube = new Mesh("Resources/cubeN.obj", Shader);

            // Model cube = new Model(cubeMat, meshCube);
            // Model cube2 = new Model(cubeMat, meshCube, new Transform(new Vector3(-5, 0, 0), new Vector3(0, 45, 30), new Vector3(1, 1, 1)));
            // Model cube3 = new Model(cubeMat, meshCube, new Transform(new Vector3(-2, 1, 1), new Vector3(0, 90, 50), new Vector3(1, 1, 1)));
            // Model cube4 = new Model(cubeMat, meshCube, new Transform(new Vector3(-7, -4, 3), new Vector3(45, 45, 45), new Vector3(1, 1, 1)));
            var lampModel = new Model(lampMat, meshCube, new Transform(new Vector3(2, 1.5f, -2), Vector3.Zero, new Vector3(0.5f, 0.5f, 0.5f)));


             lampModel.AddComponent(new HouseMovement());
            //// cube.AddComponent(new HouseMovement());

            // scene.SetCamera(camera);
             Scene.SetLight(lampModel);

            // scene.AddModel(cube);
            // scene.AddModel(cube2);
            // scene.AddModel(cube3);
            // scene.AddModel(cube4);
             Scene.AddModel(lampModel);
            #endregion


            #region BaseScene
            ////shader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");
            var stallTexture = new Texture("Resources/Textures/house.png");
            var stallTextureSnow = new Texture("Resources/Textures/checker.jpg");

            var stallMaterial = new Material(Shader, new[] {stallTexture})
            {
                Ambient = new Vector3(0.3f, 0.5f, 0.31f),
                Diffuse = new Vector3(0.3f, 0.5f, 0.31f),
                Specular = new Vector3(0.5f, 0.5f, 0.5f),
                Shininess = 32f,
                LightAmbient = new Vector3(0.2f, 0.2f, 0.2f),
                LightDiffuse = new Vector3(0.5f, 0.5f, 0.5f),
                LightSpecular = new Vector3(1.0f, 1.0f, 1.0f),
                LightDirection = new Vector3(0.5f, -0.5f, 0.5f),
                Linear = 0.09f,
                Constant = 1f,
                Quadratic = 0.032f
            };


            var stallMaterialSnow = new Material(Shader, new[] {stallTextureSnow})
            {
                Ambient = new Vector3(0.3f, 0.5f, 0.31f),
                Diffuse = new Vector3(0.3f, 0.5f, 0.31f),
                Specular = new Vector3(0.5f, 0.5f, 0.5f),
                Shininess = 32f,
                LightAmbient = new Vector3(0.2f, 0.2f, 0.2f),
                LightDiffuse = new Vector3(0.5f, 0.5f, 0.5f),
                LightSpecular = new Vector3(1.0f, 1.0f, 1.0f),
                LightDirection = new Vector3(0.5f, -0.5f, 0.5f),
                Linear = 0.09f,
                Constant = 1f,
                Quadratic = 0.032f
            };




            var meshStall = new Mesh("Resources/stallTest.obj", Shader);

            var meshHouse = new Mesh("Resources/houseTest.obj", Shader);

            var meshGround = new Mesh("Resources/ground.obj", Shader);

            var stall = new Model(stallMaterial, meshStall, new Transform(Vector3.Zero, Vector3.Zero, new Vector3(1, 1, 1)));
            var ground = new Model(stallMaterial, meshGround, new Transform(Vector3.Zero, Vector3.Zero, new Vector3(1, 1, 1)));
            var stall2 = new Model(stallMaterial, meshStall, new Transform(new Vector3(-4, 0, 0), Vector3.Zero, new Vector3(1, 1, 1)));
            var house = new Model(stallMaterial, meshHouse, new Transform(new Vector3(6, 0, 0), Vector3.Zero, new Vector3(1, 1, 1)));
            var house2 = new Model(stallMaterialSnow, meshHouse, new Transform(new Vector3(15, 0, 0), new Vector3(0, 90, 0), new Vector3(1.3f, 1.3f, 1.3f)));

            //house2.AddComponent(new HouseMovement() { gameObject = stall2 });
            //house.AddComponent(new HouseMovement());
            house2.AddComponent(new ChangeTextureScript());

            Scene.SetCamera(Camera);
            Scene.AddModel(stall);
            Scene.AddModel(stall2);
            Scene.AddModel(house);
            Scene.AddModel(house2);
            Scene.AddModel(ground);
            #endregion


            Scene.StartComponents();
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

           // Console.WriteLine(Time.deltaTime);

            Scene.DrawScene();
          
            GL.BindVertexArray(0);

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }

       
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            Scene.OnUpdateFrameComponents();

            Time.deltaTime = (float)e.Time;
            if (!Focused) 
            {
                return;
            }


            var state = Keyboard.GetState();

               

            if (state.IsKeyDown(Key.Escape))
            {
                Exit();
            }
         
            base.OnUpdateFrame(e);
        }

        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            Scene.OnMouseMoveComponents();
            if (Focused)
            {
                Mouse.SetPosition(X + Width / 2f, Y + Height / 2f);
            }

           

            base.OnMouseMove(e);
        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            Camera.FOV -= e.DeltaPrecise;
            base.OnMouseWheel(e);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            Camera.AspectRatio = Width / (float)Height;
            base.OnResize(e);
        }

        protected override void OnUnload(EventArgs e)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);

            Scene.ClearHandles();

            Shader?.Dispose();
            LampShader?.Dispose();

            base.OnUnload(e);
        }
    }
}
