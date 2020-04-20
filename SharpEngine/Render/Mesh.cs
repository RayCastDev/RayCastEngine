using System.Collections.Generic;
using OpenTK;

namespace SharpEngine.Render
{
    public class Mesh
    {
        public List<uint> Indices;
        public List<Vector3> Vertices;
        public List<Vector2> Uvs;
        public List<Vector3> Normals;

        public Mesh(List<Vector3> vertices, List<Vector2> uvs, List<Vector3> normals, List<uint> indices)
        {
            Vertices = vertices;
            Uvs = uvs;
            Normals = normals;
            Indices = indices;
        }
    }
}
