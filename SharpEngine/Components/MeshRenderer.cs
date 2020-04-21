using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using SharpEngine.Buffers;
using SharpEngine.Components.Base;
using SharpEngine.GameObjects;
using SharpEngine.Render;
using SharpEngine.Render.Base;

namespace SharpEngine.Components
{
    public class MeshRenderer : Component
    {
        public Mesh Mesh;
        public Material Material;

        private readonly VertexArrayObject vertexArrayObject;
        private VertexBufferObject<uint> elementBufferObject;
        private VertexBufferObject<Vector3> vertexPositions;
        private VertexBufferObject<Vector2> vertexUVs;
        private VertexBufferObject<Vector3> vertexNormals;

        public MeshRenderer(Mesh mesh, Material material)
        {
            Mesh = mesh;
            Material = material;

            vertexArrayObject = new VertexArrayObject();
            CreateBuffers();
        }

        private void CreateBuffers()
        {
            vertexArrayObject.Bind();

            vertexPositions = new VertexBufferObject<Vector3>(Mesh.Vertices.ToArray(), 3, BufferTarget.ArrayBuffer, BufferUsageHint.StaticDraw);
            var vertexAttribute = new VertexAttribute("aPosition", 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            vertexAttribute.Set(Material.Shader);

            vertexUVs = new VertexBufferObject<Vector2>(Mesh.Uvs.ToArray(), 2, BufferTarget.ArrayBuffer, BufferUsageHint.StaticDraw);
            vertexAttribute = new VertexAttribute("aTexCoord", 2, VertexAttribPointerType.Float, false, 2 * sizeof(float), 0);
            vertexAttribute.Set(Material.Shader);

            vertexNormals = new VertexBufferObject<Vector3>(Mesh.Normals.ToArray(), 3, BufferTarget.ArrayBuffer, BufferUsageHint.StaticDraw);
            vertexAttribute = new VertexAttribute("aNormal", 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            vertexAttribute.Set(Material.Shader);

            elementBufferObject = new VertexBufferObject<uint>(Mesh.Indices.ToArray(), 1, BufferTarget.ElementArrayBuffer, BufferUsageHint.StaticDraw);

        }

        public void RenderMesh(Camera camera, List<Light> lights)
        {
            vertexArrayObject.Bind();
            Material.SetMaterialParams(camera,lights, owner.Transform);
            GL.DrawElements(PrimitiveType.Triangles, elementBufferObject.VertexData.Length, DrawElementsType.UnsignedInt, 0);
        }

        public void ClearHandles()
        {
            Material.ClearHandles();
            vertexArrayObject.ClearHandle();
            vertexPositions.ClearHandle();
            vertexNormals.ClearHandle();
            vertexUVs.ClearHandle();
            elementBufferObject.ClearHandle();
        }
    }
}
