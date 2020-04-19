using OpenTK;
using SharpEngine.Abstracts;
using SharpEngine.Buffers;
using System.Collections.Generic;
using ModelLoader.Factories;
using OpenTK.Graphics.OpenGL4;

namespace SharpEngine.Architect
{
    public class Mesh : Component
    {
        internal VertexArrayObject VertexArrayObject;
        internal VertexBufferObject<uint> ElementBufferObject;

        private VertexBufferObject<Vector3> vertexPositions;
        private VertexBufferObject<Vector2> vertexUVs;
        private VertexBufferObject<Vector3> vertexNormals;

        public Mesh(string path, Shader shader)
        {
            CreateVao();
            CreateBuffers(path, shader);
        }

        private void CreateVao()
        {
            VertexArrayObject = new VertexArrayObject();
            VertexArrayObject.Bind();
        }

        public void CreateBuffers(string path, Shader shader)
        {
            var modelLoader = LoaderFactory.GetModelLoader(path);
            var indices = new List<uint>();
            var indexedVertices = new List<Vector3>();
            var indexedUvs = new List<Vector2>();
            var indexedNormals = new List<Vector3>();
            modelLoader.LoadModel(path, indices, indexedVertices, indexedUvs, indexedNormals);

            vertexPositions = new VertexBufferObject<Vector3>(indexedVertices.ToArray(),3,BufferTarget.ArrayBuffer,BufferUsageHint.StaticDraw);
            var vertexAttribute = new VertexAttribute("aPosition", 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            vertexAttribute.Set(shader);

            vertexUVs = new VertexBufferObject<Vector2>(indexedUvs.ToArray(),2, BufferTarget.ArrayBuffer,BufferUsageHint.StaticDraw);
            vertexAttribute = new VertexAttribute("aTexCoord", 2, VertexAttribPointerType.Float, false, 2 * sizeof(float), 0);
            vertexAttribute.Set(shader);

            vertexNormals = new VertexBufferObject<Vector3>(indexedNormals.ToArray(),3, BufferTarget.ArrayBuffer,BufferUsageHint.StaticDraw);
            vertexAttribute = new VertexAttribute("aNormal", 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            vertexAttribute.Set(shader);

            ElementBufferObject = new VertexBufferObject<uint>(indices.ToArray(),1,BufferTarget.ElementArrayBuffer,BufferUsageHint.StaticDraw);
        }

        public void ClearHandles()
        {
            VertexArrayObject.ClearHandle();
            vertexPositions.ClearHandle();
            vertexUVs.ClearHandle();
            vertexNormals.ClearHandle();
            ElementBufferObject.ClearHandle();
        }
    }
}
