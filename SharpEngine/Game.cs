using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using SharpEngine.Abstracts;
using SharpEngine.Architect;
using SharpEngine.Buffers;
using SharpEngine.Cameras;
using SharpEngine.Helpers;
using SharpEngine.Scripts;

namespace SharpEngine
{
    public class Game : GameWindow
    {     
        Scene scene;
        Camera camera;
        //float deltaTime;
        Shader shader;
        Shader lampShader;

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
            //Console.WriteLine(fileToRead);
            scene = new Scene();

            camera = new Camera(new Transform(new Vector3(0,2,6), new Vector3(0,-90,0), Vector3.One), Width / (float)Height, true, 3.5f, 3);
            camera.AddComponent(new CameraMovement());

            #region lightCube
            shader = new Shader("Shaders/shader.vert", "Shaders/newShader.frag");
            lampShader = new Shader("Shaders/shader.vert", "Shaders/lamp.frag");

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

             Material lampMat = new Material(lampShader);

            Mesh meshCube = new Mesh("Resources/cubeN.obj", shader,
               new VertexAttribute("aPosition", 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0),
               new VertexAttribute("aTexCoord", 2, VertexAttribPointerType.Float, false, 2 * sizeof(float), 0),
               new VertexAttribute("aNormal", 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0));

            // Model cube = new Model(cubeMat, meshCube);
            // Model cube2 = new Model(cubeMat, meshCube, new Transform(new Vector3(-5, 0, 0), new Vector3(0, 45, 30), new Vector3(1, 1, 1)));
            // Model cube3 = new Model(cubeMat, meshCube, new Transform(new Vector3(-2, 1, 1), new Vector3(0, 90, 50), new Vector3(1, 1, 1)));
            // Model cube4 = new Model(cubeMat, meshCube, new Transform(new Vector3(-7, -4, 3), new Vector3(45, 45, 45), new Vector3(1, 1, 1)));
            Model lampModel = new Model(lampMat, meshCube, new Transform(new Vector3(2, 1.5f, -2), Vector3.Zero, new Vector3(0.5f, 0.5f, 0.5f)));


             lampModel.AddComponent(new HouseMovement());
            //// cube.AddComponent(new HouseMovement());

            // scene.SetCamera(camera);
             scene.SetLight(lampModel);

            // scene.AddModel(cube);
            // scene.AddModel(cube2);
            // scene.AddModel(cube3);
            // scene.AddModel(cube4);
             scene.AddModel(lampModel);
            #endregion


            #region BaseScene
            ////shader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");
            Texture stallTexture = new Texture("Resources/Textures/house.png");
            Texture stallTextureSnow = new Texture("Resources/Textures/checker.jpg");

            Material stallMaterial = new Material(shader, new Texture[] { stallTexture });

            stallMaterial.ambient = new Vector3(0.3f, 0.5f, 0.31f);
            stallMaterial.diffuse = new Vector3(0.3f, 0.5f, 0.31f);
            stallMaterial.specular = new Vector3(0.5f, 0.5f, 0.5f);
            stallMaterial.shininess = 32f;

            stallMaterial.lightAmbient = new Vector3(0.2f, 0.2f, 0.2f);
            stallMaterial.lightDiffuse = new Vector3(0.5f, 0.5f, 0.5f);
            stallMaterial.lightSpecular = new Vector3(1.0f, 1.0f, 1.0f);
            stallMaterial.lightDirection = new Vector3(0.5f, -0.5f, 0.5f);

            stallMaterial.linear = 0.09f;
            stallMaterial.constatnt = 1f;
            stallMaterial.qudratic = 0.032f;

            Material stallMaterialSnow = new Material(shader, new Texture[] { stallTextureSnow });

            stallMaterialSnow.ambient = new Vector3(0.3f, 0.5f, 0.31f);
            stallMaterialSnow.diffuse = new Vector3(0.3f, 0.5f, 0.31f);
            stallMaterialSnow.specular = new Vector3(0.5f, 0.5f, 0.5f);
            stallMaterialSnow.shininess = 32f;

            stallMaterialSnow.lightAmbient = new Vector3(0.2f, 0.2f, 0.2f);
            stallMaterialSnow.lightDiffuse = new Vector3(0.5f, 0.5f, 0.5f);
            stallMaterialSnow.lightSpecular = new Vector3(1.0f, 1.0f, 1.0f);
            stallMaterialSnow.lightDirection = new Vector3(0.5f, -0.5f, 0.5f);

            stallMaterialSnow.linear = 0.09f;
            stallMaterialSnow.constatnt = 1f;
            stallMaterialSnow.qudratic = 0.032f;

            Mesh meshStall = new Mesh("Resources/stallTest.obj", shader,
               new VertexAttribute("aPosition", 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0),
               new VertexAttribute("aTexCoord", 2, VertexAttribPointerType.Float, false, 2 * sizeof(float), 0),
               new VertexAttribute("aNormal", 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0));

            Mesh meshhouse = new Mesh("Resources/houseTest.obj", shader,
              new VertexAttribute("aPosition", 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0),
              new VertexAttribute("aTexCoord", 2, VertexAttribPointerType.Float, false, 2 * sizeof(float), 0),
              new VertexAttribute("aNormal", 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0));

            Mesh meshGround = new Mesh("Resources/ground.obj", shader,
             new VertexAttribute("aPosition", 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0),
             new VertexAttribute("aTexCoord", 2, VertexAttribPointerType.Float, false, 2 * sizeof(float), 0),
             new VertexAttribute("aNormal", 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0));

            Model stall = new Model(stallMaterial, meshStall, new Transform(Vector3.Zero, Vector3.Zero, new Vector3(1, 1, 1)));
            Model ground = new Model(stallMaterial, meshGround, new Transform(Vector3.Zero, Vector3.Zero, new Vector3(1, 1, 1)));
            Model stall2 = new Model(stallMaterial, meshStall, new Transform(new Vector3(-4, 0, 0), Vector3.Zero, new Vector3(1, 1, 1)));
            Model house = new Model(stallMaterial, meshhouse, new Transform(new Vector3(6, 0, 0), Vector3.Zero, new Vector3(1, 1, 1)));
            Model house2 = new Model(stallMaterialSnow, meshhouse, new Transform(new Vector3(15, 0, 0), new Vector3(0, 90, 0), new Vector3(1.3f, 1.3f, 1.3f)));

            //house2.AddComponent(new HouseMovement() { gameObject = stall2 });
            //house.AddComponent(new HouseMovement());
            house2.AddComponent(new ChangeTextureScript());

            scene.SetCamera(camera);
            scene.AddModel(stall);
            scene.AddModel(stall2);
            scene.AddModel(house);
            scene.AddModel(house2);
            scene.AddModel(ground);
            #endregion


            scene.StartComponents();
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

           // Console.WriteLine(Time.deltaTime);

            scene.DrawScene();
          
            GL.BindVertexArray(0);

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }

       
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            scene.OnUpdateFrameComponents();

            Time.deltaTime = (float)e.Time;
            if (!Focused) 
            {
                return;
            }


            KeyboardState state = Keyboard.GetState();

               

            if (state.IsKeyDown(Key.Escape))
            {
                Exit();
            }
         
            base.OnUpdateFrame(e);
        }

        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            scene.OnMouseMoveComponents();
            if (Focused)
            {
                Mouse.SetPosition(X + Width / 2f, Y + Height / 2f);
            }

           

            base.OnMouseMove(e);
        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            camera.FOV -= e.DeltaPrecise;
            base.OnMouseWheel(e);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            camera.AspectRatio = Width / (float)Height;
            base.OnResize(e);
        }

        protected override void OnUnload(EventArgs e)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);

            scene.ClearHandles();

            if (shader != null)
                shader.Dispose();
            if(lampShader!=null)
                lampShader.Dispose();

            base.OnUnload(e);
        }
    }
}
