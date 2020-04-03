using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using SharpEngine.Abstracts;
using SharpEngine.Buffers;
using SharpEngine.Cameras;
using SharpEngine.Helpers;
using SharpEngine.Inputs;
using SharpEngine.Mesh;

namespace SharpEngine
{
    public class Game : GameWindow
    {
        Vector3[] cubePositions =
        {
            new Vector3(0.0f,0.0f,0.0f),
            new Vector3(-5f,0f,0f),
            new Vector3(2.1f,1.0f,-1.1f),
            new Vector3(0.0f,-1.3f,3.0f),
        };

        Vector3[] pyramidsPositions =
        {
            new Vector3(1.5f,1.5f,1.5f),
            new Vector3(-6.8f,4.0f,-3.0f),
            new Vector3(-2.1f,-5.0f,-3.1f),
            new Vector3(4.0f,-2.3f,1.0f),
        };
        //private VertexBuffer<TexturedVertex> vertexBuffer;
        //private VertexArray<TexturedVertex> vertexArray;

        IInputHandler inputHandler;

        //------------------------------------Buffers
        int[] VertexBufferObjects = new int[2];
        int ElementBufferObject;
        int[] VertexArrayObjects = new int[2];

        //------------------------------------Shaders
        private Shader _shader;

        //------------------------------------Textures
        //private Texture _texture;
        //private Texture _texture2;

        //------------------------------------Cameras
        private Camera _camera;

        VertexArray[] vertexArrays;

        float deltaTime;

        public Game(int width, int height, string title, IInputHandler inputHandler) : base(width, height, GraphicsMode.Default, title)
        {
            this.inputHandler = inputHandler;
        }

        Matrix4 model;
        protected override void OnLoad(EventArgs e)
        {         
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            GL.Enable(EnableCap.DepthTest);

            vertexArrays = new VertexArray[2];

            _shader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");
            _shader.Use();

            List<Vector3> vertices = new List<Vector3>();
            List<Vector2> uvs = new List<Vector2>();

            ObjectLoader loader = new ObjectLoader();
            loader.LoadObject("Resources/stall.obj", vertices, uvs);

            List<uint> indices = new List<uint>();
            List<Vector3> indexed_vertices = new List<Vector3>();
            List<Vector2> indexed_uvs = new List<Vector2>();

            VboIndexer vboIndexer = new VboIndexer();
            vboIndexer.IndexVBOFast(vertices, uvs, indices, indexed_vertices, indexed_uvs);

            VertexBuffer vb1 = new VertexBuffer(indexed_vertices.ToArray(), indices.ToArray());
            VertexUVBuffer uvBuffer = new VertexUVBuffer(indexed_uvs.ToArray());

            vertexArrays[0] = new VertexArray(vb1, uvBuffer, _shader,
                new Texture[] { new Texture("Resources/Textures/house.png"), },
                new VertexAttribute("aPosition", 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0),
                new VertexAttribute("aTexCoord", 2, VertexAttribPointerType.Float, false, 2 * sizeof(float), 0)
                );



            List<Vector3> vertices2 = new List<Vector3>();
            List<Vector2> uvs2 = new List<Vector2>();

            ObjectLoader loader2 = new ObjectLoader();
            loader2.LoadObject("Resources/stall.obj", vertices2, uvs2);

            List<uint> indices2 = new List<uint>();
            List<Vector3> indexed_vertices2 = new List<Vector3>();
            List<Vector2> indexed_uvs2 = new List<Vector2>();

            VboIndexer vboIndexer2 = new VboIndexer();
            vboIndexer2.IndexVBOFast(vertices2, uvs2, indices2, indexed_vertices2, indexed_uvs2);

            VertexBuffer vb2 = new VertexBuffer(indexed_vertices2.ToArray(), indices2.ToArray());
            VertexUVBuffer uvBuffer2 = new VertexUVBuffer(indexed_uvs2.ToArray());

            vertexArrays[1] = new VertexArray(vb2, uvBuffer2, _shader,
               new Texture[] { new Texture("Resources/Textures/house.png"), },
               new VertexAttribute("aPosition", 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0),
               new VertexAttribute("aTexCoord", 2, VertexAttribPointerType.Float, false, 2 * sizeof(float), 0)
               );


            //VertexBuffer vb = new VertexBuffer(TestMeshes.box);
            //vertexArrays[0] = new VertexArray(vb, _shader,
            //    new Texture[] { new Texture("Resources/Textures/container.png"),
            //                    new Texture("Resources/Textures/awesomeface.png") },
            //    new VertexAttribute("aPosition", 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0),
            //    new VertexAttribute("aTexCoord", 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float))
            //    );
            //_texture = new Texture("Resources/Textures/container.png");
            //_texture2 = new Texture("Resources/Textures/awesomeface.png");
            //_shader.SetInt("texture1", 0);
            //_shader.SetInt("texture2", 1);



            //Получаем уникальный идентификатор
            //GL.GenBuffers(2, VertexBufferObjects);
            //GL.GenVertexArrays(2, VertexArrayObjects);

            //_shader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");
            //_shader.Use();

            //_texture = new Texture("Resources/Textures/container.png");

            //_texture2 = new Texture("Resources/Textures/awesomeface.png");

            //_shader.SetInt("texture1", 0);
            //_shader.SetInt("texture2", 1);

            //GL.BindVertexArray(VertexArrayObjects[0]);
            //GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObjects[0]);
            //GL.BufferData(BufferTarget.ArrayBuffer, Box.vertices.Length * sizeof(float), Box.vertices, BufferUsageHint.StaticDraw);
            //GL.VertexAttribPointer(_shader.GetAttributeLocation("aPosition"), 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);

            //int texCoordLocation = _shader.GetAttributeLocation("aTexCoord");
            //GL.EnableVertexAttribArray(texCoordLocation);
            //GL.VertexAttribPointer(texCoordLocation, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));

            //GL.EnableVertexAttribArray(0);
            //GL.BindVertexArray(0);

            _camera = new Camera(Vector3.UnitZ * 3, Width / (float)Height,true,1.5f,3);
            CursorVisible = false;
            base.OnLoad(e);
        }

        double time;

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            time += e.Time * 1.0f;
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
         
            //_texture.Use(TextureUnit.Texture0);
            //_texture2.Use(TextureUnit.Texture1);
            vertexArrays[0].Bind();

            _shader.SetMatrix4("view", _camera.GetViewMatrix());
            _shader.SetMatrix4("projection", _camera.GetProjectionMatrix());


            //GL.BindVertexArray(VertexArrayObjects[0]);


            //foreach (Vector3 v in cubePositions)
            //{
            model = Matrix4.CreateTranslation(cubePositions[0]);
            _shader.SetMatrix4("model", model);
                //GL.DrawArrays(PrimitiveType.Triangles, 0, 36);
            vertexArrays[0].Draw();
            //}

            vertexArrays[1].Bind();

            model = Matrix4.CreateTranslation(cubePositions[1]);
            _shader.SetMatrix4("model", model);
            vertexArrays[1].Draw();
            //foreach (Vector3 v in pyramidsPositions)
            //{
            //    model = Matrix4.CreateTranslation(v);
            //    model *= Matrix4.CreateScale(0.7f);
            //    _shader.SetMatrix4("model", model);
            //    //GL.DrawArrays(PrimitiveType.Triangles, 0, 36);
            //    vertexArrays[1].Draw();
            //}

            GL.BindVertexArray(0);



            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }


        float speed = 2;
       
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            deltaTime = (float)e.Time;
            if (!Focused) 
            {
                return;
            }

            inputHandler.ProcessInput();
            _camera.ProcessMovement(inputHandler, deltaTime);

            if (inputHandler.ArrowUp)
            {
                cubePositions[0].Z += 2 * deltaTime;
            }
            if (inputHandler.ArrowDown)
            {
                cubePositions[0].Z -= 2 * deltaTime;
            }
            //_camera.Position = cubePositions[0] + new Vector3(-2, 2, 3);

            //cubePositions[0].Z += speed * deltaTime;
            //if(cubePositions[0].Z >= 3 || cubePositions[0].Z <= -3)
            //{
            //    speed *= -1;
            //}

            if (inputHandler.Exit)
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

            _camera.ProcessLooking(deltaX, deltaY, deltaTime);
            base.OnMouseMove(e);
        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            _camera.FOV -= e.DeltaPrecise;
            base.OnMouseWheel(e);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            _camera.AspectRatio = Width / (float)Height;
            base.OnResize(e);
        }

        protected override void OnUnload(EventArgs e)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);

            foreach (var v in vertexArrays)
            {
            //    v.ClearHandls();
            }

            //GL.DeleteBuffers(2, VertexBufferObjects);
            //GL.DeleteVertexArrays(2, VertexArrayObjects);

            _shader.Dispose();

            //GL.DeleteTexture(_texture.Handle);
            //GL.DeleteTexture(_texture2.Handle);

            base.OnUnload(e);
        }
    }
}
