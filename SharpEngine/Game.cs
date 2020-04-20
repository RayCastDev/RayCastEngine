using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.ES20;
using OpenTK.Input;
using SharpEngine.Components;
using SharpEngine.GameObjects;
using SharpEngine.Helpers;
using SharpEngine.Render;
using SharpEngine.Scripts;
using SharpEngine.Utils;
using BufferTarget = OpenTK.Graphics.OpenGL4.BufferTarget;
using ClearBufferMask = OpenTK.Graphics.OpenGL4.ClearBufferMask;
using ColorMaterialFace = OpenTK.Graphics.ES11.ColorMaterialFace;
using EnableCap = OpenTK.Graphics.OpenGL4.EnableCap;
using GL = OpenTK.Graphics.OpenGL4.GL;

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
            GL.ClearColor(0.3f, 0.3f, 0.3f, 1.0f);
            GL.Enable(EnableCap.DepthTest);

            InitScene();

            CursorVisible = false;
            base.OnLoad(e);
        }

        private void InitScene()
        {
            Scene = new Scene();

            var stallTexture = new Texture("Resources/Textures/house.png");
            var stallTextureSnow = new Texture("Resources/Textures/checker.jpg");

            Shader = new Shader("Shaders/shader.vert", "Shaders/newShader.frag");
            var stallMaterial = new MaterialModel(Shader, new[] { stallTexture })
            {
                Ambient = new Vector3(0.3f, 0.5f, 0.31f),
                Diffuse = new Vector3(0.3f, 0.5f, 0.31f),
                Specular = new Vector3(0.5f, 0.5f, 0.5f),
                Shininess = 32f
            };
            var stallMaterialSnow = new MaterialModel(Shader, new[] { stallTextureSnow })
            {
                Ambient = new Vector3(0.3f, 0.5f, 0.31f),
                Diffuse = new Vector3(0.3f, 0.5f, 0.31f),
                Specular = new Vector3(0.5f, 0.5f, 0.5f),
                Shininess = 32f,
            };

            LampShader = new Shader("Shaders/shader.vert", "Shaders/lamp.frag");
            var cubeMat = new ColorMaterial(LampShader, new Vector3(0.3f, 0.3f, 0.8f));

            var pointLight = new Light(LampShader,LightType.PointLight,new Vector3(0.3f,0.3f,0.8f), new Vector3(1,1,1), 0.032f,0.09f, 1);
            Camera = new Camera(Width / (float) Height, true, 3.5f, 3);

            Mesh meshCube = MeshCreator.CreateMesh("Resources/cubeN.obj");
            Mesh meshGround = MeshCreator.CreateMesh("Resources/ground.obj");
            Mesh meshHouse = MeshCreator.CreateMesh("Resources/houseTest.obj");
            Mesh meshStall = MeshCreator.CreateMesh("Resources/stallTest.obj");

            GameObject cameraGameObject = new GameObject(new Transform(new Vector3(0, 2, 6), new Vector3(0, -90, 0), Vector3.One));
            cameraGameObject.AddComponent(Camera);
            cameraGameObject.AddComponent(new CameraMovement());

            GameObject cubeGameObject = new GameObject(new Transform(new Vector3(2, 1.5f, -2), Vector3.Zero, new Vector3(0.5f, 0.5f, 0.5f)));
            cubeGameObject.AddComponent(new MeshRenderer(meshCube, cubeMat));
            cubeGameObject.AddComponent(new HouseMovement());
            cubeGameObject.AddComponent(pointLight);

            GameObject groundGameObject = new GameObject();
            groundGameObject.AddComponent(new MeshRenderer(meshGround, stallMaterial));

            GameObject houseGameObject = new GameObject(new Transform(new Vector3(6, 0, 0),Vector3.Zero,Vector3.One));
            houseGameObject.AddComponent(new MeshRenderer(meshHouse, stallMaterial));

            GameObject house2GameObject = new GameObject(new Transform(new Vector3(15, 0, 0), new Vector3(0, 90, 0), Vector3.One));
            house2GameObject.AddComponent(new MeshRenderer(meshHouse, stallMaterialSnow));
            house2GameObject.AddComponent(new ChangeTextureScript());

            GameObject stallGameObject = new GameObject();
            stallGameObject.AddComponent(new MeshRenderer(meshStall, stallMaterial));

            GameObject stall2GameObject = new GameObject(new Transform(new Vector3(-4, 0, 0), new Vector3(0, 45, 0), Vector3.One));
            stall2GameObject.AddComponent(new MeshRenderer(meshStall, stallMaterial));



            Scene.AddGameObject(cubeGameObject);
            Scene.AddGameObject(groundGameObject);
            Scene.AddGameObject(houseGameObject);
            Scene.AddGameObject(house2GameObject);
            Scene.AddGameObject(stallGameObject);
            Scene.AddGameObject(stall2GameObject);
            Scene.AddGameObject(cameraGameObject);

            Scene.StartComponents();
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

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
