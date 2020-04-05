﻿using System;
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

        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            GL.Enable(EnableCap.DepthTest);

            InitScene();

            CursorVisible = false;
            base.OnLoad(e);
        }

        private void InitScene()
        {
            scene = new Scene();

            camera = new Camera(Vector3.UnitZ * 3, Width / (float)Height, true, 3.5f, 3);
            shader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");
            Texture stallTexture = new Texture("Resources/Textures/house.png");
            Texture stallTextureSnow = new Texture("Resources/Textures/checker.jpg");

            Material stallMaterial = new Material(shader, new Texture[] { stallTexture });
            Material stallMaterialSnow = new Material(shader, new Texture[] { stallTextureSnow });

            Mesh meshStall = new Mesh("Resources/stall.obj", shader,
               new VertexAttribute("aPosition", 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0),
               new VertexAttribute("aTexCoord", 2, VertexAttribPointerType.Float, false, 2 * sizeof(float), 0));

            Mesh meshhouse = new Mesh("Resources/house2.obj", shader,
              new VertexAttribute("aPosition", 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0),
              new VertexAttribute("aTexCoord", 2, VertexAttribPointerType.Float, false, 2 * sizeof(float), 0));

            Model stall = new Model(stallMaterial, meshStall, new Transform(Vector3.Zero, Vector3.Zero, Vector3.Zero));
            Model stall2 = new Model(stallMaterial, meshStall, new Transform(new Vector3(-4, 0, 0), Vector3.Zero, Vector3.Zero));
            Model house = new Model(stallMaterial, meshhouse, new Transform(new Vector3(6, 0, 0), Vector3.Zero, Vector3.Zero));
            Model house2 = new Model(stallMaterialSnow, meshhouse, new Transform(new Vector3(15, 0, 0), Vector3.Zero, Vector3.Zero));

            house2.AddComponent(new HouseMovement());
            house.AddComponent(new HouseMovement());

            scene.SetCamera(camera);
            scene.AddModel(stall);
            scene.AddModel(stall2);
            scene.AddModel(house);
            scene.AddModel(house2);

            scene.StartComponents();
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
       
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

            camera.ProcessMovement(state, Time.deltaTime);
        

            if (state.IsKeyDown(Key.Escape))
            {
                Exit();
            }
         
            base.OnUpdateFrame(e);
        }

        bool FirstMove = true;
        Vector2 lastPos;
        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            if(Focused)
            {
                Mouse.SetPosition(X + Width / 2f, Y + Height / 2f);
            }

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

            shader.Dispose();

            base.OnUnload(e);
        }
    }
}
