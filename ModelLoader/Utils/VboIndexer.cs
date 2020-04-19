using System;
using System.Collections.Generic;
using OpenTK;

namespace ModelLoader.Utils
{
    internal class VboIndexer
    {
        public static void IndexVboFast(List<Vector3> inVertices,
            List<Vector2> inUvs,
            List<Vector3> inNormals,
            List<uint> outIndices,
            List<Vector3> outVertices,
            List<Vector2> outUvs,
            List<Vector3> outNormals)
        {
            var ht = new Dictionary<VertexData, uint>();

            for (var i = 0; i < inVertices.Count; i++)
            {
                var vertexData = new VertexData(inVertices[i], inUvs[i], inNormals[i]);

                bool found = getSimilarVertexIndex_Fast(vertexData, ht, out var index);

                if (found)
                {
                    outIndices.Add(index);
                }
                else
                {
                    outVertices.Add(inVertices[i]);
                    outUvs.Add(inUvs[i]);
                    outNormals.Add(inNormals[i]);
                    var newIndex = (uint) outVertices.Count - 1;
                    outIndices.Add(newIndex);
                    ht[vertexData] = newIndex;
                }
            }
        }

        private static bool getSimilarVertexIndex_Fast(VertexData vertexData,
            Dictionary<VertexData, uint> dictionary, out uint result)
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));

            return dictionary.TryGetValue(vertexData, out result);
        }

        private struct VertexData
        {
            private readonly Vector3 vertex;
            private readonly Vector2 uv;
            private readonly Vector3 normal;

            public VertexData(Vector3 vertex, Vector2 uv, Vector3 normal)
            {
                this.vertex = vertex;
                this.uv = uv;
                this.normal = normal;
            }
        }
    }
}