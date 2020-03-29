using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using SharpEngine.Abstracts;
using SharpEngine.Cameras;
using SharpEngine.Inputs;
using SharpEngine.Mesh;

namespace SharpEngine
{
    public class Game : GameWindow
    {
        IInputHandler inputHandler;

        //------------------------------------Buffers
        int[] VertexBufferObjects = new int[2];
        int ElementBufferObject;
        int[] VertexArrayObjects = new int[2];

        //------------------------------------Shaders
        private Shader _shader;

        //------------------------------------Textures
        private Texture _texture;
        private Texture _texture2;

        //------------------------------------Cameras
        private Camera _camera;



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
            //Получаем уникальный идентификатор
            GL.GenBuffers(2, VertexBufferObjects);
            GL.GenVertexArrays(2, VertexArrayObjects);

            _shader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");
            _shader.Use();

            _texture = new Texture("Resources/Textures/container.png");

            _texture2 = new Texture("Resources/Textures/awesomeface.png");

         

            _shader.SetInt("texture1", 0);
            _shader.SetInt("texture2", 1);

            GL.BindVertexArray(VertexArrayObjects[0]);
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObjects[0]);
            GL.BufferData(BufferTarget.ArrayBuffer, Box.vertices.Length * sizeof(float), Box.vertices, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(_shader.GetAttributeLocation("aPosition"), 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);

            //ElementBufferObject = GL.GenBuffer();
            //GL.BindBuffer(BufferTarget.ElementArrayBuffer, ElementBufferObject);
            //GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);

            int texCoordLocation = _shader.GetAttributeLocation("aTexCoord");
            GL.EnableVertexAttribArray(texCoordLocation);
            GL.VertexAttribPointer(texCoordLocation, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));

            GL.EnableVertexAttribArray(0);
            GL.BindVertexArray(0);


            //shader2.Use();
            //GL.BindVertexArray(VertexArrayObjects[1]);
            //GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObjects[1]);
            //GL.BufferData(BufferTarget.ArrayBuffer, secondTriangle.Length * sizeof(float), secondTriangle, BufferUsageHint.StaticDraw);
            //GL.VertexAttribPointer(shader2.GetAttributeLocation("aPosition"), 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);

            //int texCoordLocation2 = shader.GetAttributeLocation("aTexCoord");
            //GL.EnableVertexAttribArray(texCoordLocation2);
            //GL.VertexAttribPointer(texCoordLocation2, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));

            GL.EnableVertexAttribArray(0);
            GL.BindVertexArray(0);


          
            //transform *= Matrix4.CreateScale(0.5f);
            //transform *= Matrix4.CreateTranslation(0.0f, 0.0f, 0.0f);

            model = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(-55.0f));
            //view = Matrix4.CreateTranslation(0.0f, 0.0f, -3.0f);


            //GL.BindBuffer(BufferTarget.ElementArrayBuffer, ElementBufferObject);

            //Position = new Vector3(0.0f, 0.0f, 3.0f);
            //cameraTarget = new Vector3(0, 0, 0);
            ////cameraDirection = Vector3.Normalize(Position - cameraTarget);
            //cameraDirection = new Vector3(0.0f, 0.0f, -1.0f);
            //cameraRight = Vector3.Normalize(Vector3.Cross(new Vector3(0, 1, 0), cameraDirection));
            //cameraUp = Vector3.Cross(cameraDirection, cameraRight);

            ////view = Matrix4.LookAt(0.0f, 0.0f, 3.0f,
            //                      0.0f, 0.0f, 0.0f,
            //                      0.0f, 1.0f, 0.0f);
            _camera = new Camera(Vector3.UnitZ * 3, Width / (float)Height,true,1.5f,3);
            CursorVisible = false;
            base.OnLoad(e);
        }

        double time;

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            time += e.Time * 1.0f;
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.BindVertexArray(VertexArrayObjects[0]);

            //transform *= Matrix4.CreateRotationZ((float)e.Time * 0.5f * MathHelper.DegreesToRadians(45.0f));
            //
            //float caxX = (float)Math.Sin(time) * radius;
            //float caxZ = (float)Math.Cos(time) * radius;
         


            //view = Matrix4.LookAt(new Vector3(caxX,0,caxZ), cameraTarget, cameraUp);
          
            //model = Matrix4.CreateRotationY((float)MathHelper.DegreesToRadians(time));
            //model *= Matrix4.CreateRotationX((float)MathHelper.DegreesToRadians(time));            
            _texture.Use(TextureUnit.Texture0);
            _texture2.Use(TextureUnit.Texture1);

            //shader.SetMatrix4("transform", transform);
            _shader.SetMatrix4("model", model);
            _shader.SetMatrix4("view", _camera.GetViewMatrix());
            _shader.SetMatrix4("projection", _camera.GetProjectionMatrix());

            //GL.DrawArrays(PrimitiveType.Triangles,0,3);

            //shader2.Use();
            //shader2.SetMatrix4("transform", transform);
            //GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);
            //GL.BindVertexArray(VertexArrayObjects[1]);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 36);
            GL.BindVertexArray(0);



            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }

  

       
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            deltaTime = (float)e.Time;
            if (!Focused) 
            {
                return;
            }

            inputHandler.ProcessInput();
            _camera.ProcessMovement(inputHandler, deltaTime);
           
            if(inputHandler.Exit)
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

            GL.DeleteBuffers(2, VertexBufferObjects);
            GL.DeleteVertexArrays(2, VertexArrayObjects);

            _shader.Dispose();

            GL.DeleteTexture(_texture.Handle);
            GL.DeleteTexture(_texture2.Handle);

            base.OnUnload(e);
        }
    }
}
