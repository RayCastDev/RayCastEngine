using OpenTK;
using SharpEngine.Abstracts;
using SharpEngine.Buffers;
using SharpEngine.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.Architect
{
    public class Mesh : Component
    {
        public VertexArrayBuffer VAO;
        VertexBuffer VBO;
        public VertexElementBuffer EBO;
        VertexUVBuffer UV_VBO;

        public Mesh(string path, Shader shader ,params VertexAttribute[] attributes)
        {
            CreateVAO();
            CreateBuffers(path, shader, attributes);
        }

        void CreateVAO()
        {
            VAO = new VertexArrayBuffer();
            VAO.Bind();
        }

        void CreateBuffers(string path, Shader shader, VertexAttribute[] attributes)
        {
            List<Vector3> vertices = new List<Vector3>();
            List<Vector2> uvs = new List<Vector2>();
            ObjectLoader.LoadObject(path, vertices, uvs);

            List<uint> indices = new List<uint>();
            List<Vector3> indexed_vertices = new List<Vector3>();
            List<Vector2> indexed_uvs = new List<Vector2>();
            VboIndexer.IndexVBOFast(vertices, uvs, indices, indexed_vertices, indexed_uvs);

            VBO = new VertexBuffer(indexed_vertices.ToArray());
            VBO.BindBuffer();
            VBO.BufferData();
            attributes[0].Set(shader);

            UV_VBO = new VertexUVBuffer(indexed_uvs.ToArray());
            UV_VBO.BindBuffer();
            UV_VBO.BufferData();
            attributes[1].Set(shader);

            EBO = new VertexElementBuffer(indices.ToArray());
            EBO.BindBuffer();
            EBO.BufferData();
        }

        public void ClearHandles()
        {
            VAO.CrealHandle();
            VBO.CrealHandle();
            EBO.CrealHandle();
            UV_VBO.CrealHandle();
        }
    }
}
