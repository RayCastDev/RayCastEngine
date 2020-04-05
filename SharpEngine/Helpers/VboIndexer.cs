using OpenTK;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.Helpers
{
    public class VboIndexer
    {
        public void IndexVBO(List<Vector3> in_vertices, 
                             List<Vector2> in_uvs, 
                             List<uint> out_indices, 
                             List<Vector3> out_vertices, 
                             List<Vector2> out_uvs)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for(int i = 0; i<in_vertices.Count;i++)
            {
                uint index;
                bool found = getSimilarVertexIndex_Slow(in_vertices[i], in_uvs[i], out_vertices, out_uvs, out index);

                if(found)
                {
                    out_indices.Add(index);
                }
                else
                {
                    out_vertices.Add(in_vertices[i]);
                    out_uvs.Add(in_uvs[i]);
                    out_indices.Add((uint)out_vertices.Count - 1);
                }
            }
            watch.Stop();
            Console.WriteLine($"Time execution slow: {watch.ElapsedMilliseconds} ms" );
        }

        bool getSimilarVertexIndex_Slow(Vector3 in_vertices, 
                                        Vector2 in_uvs, 
                                        List<Vector3> out_vertices, 
                                        List<Vector2> out_uvs, 
                                        out uint result)
        {
            for (int i = 0; i < out_vertices.Count; i++)
            {
                if (isNear(in_vertices.X, out_vertices[i].X) &&
                    isNear(in_vertices.Y, out_vertices[i].Y) &&
                    isNear(in_vertices.Z, out_vertices[i].Z) &&
                    isNear(in_uvs.X, out_uvs[i].X) &&
                    isNear(in_uvs.Y, out_uvs[i].Y))
                {
                    result = (uint)i;
                    return true;
                }

            }
            result = 0;
            return false;
        }
        bool isNear(float a1, float a2)
        {
            return Math.Abs(a1 - a2) < 0.01f;
        }


       

        public static void  IndexVBOFast(List<Vector3> in_vertices,
                            List<Vector2> in_uvs,
                            List<uint> out_indices,
                            List<Vector3> out_vertices,
                            List<Vector2> out_uvs)
        {
            Dictionary<VertexData, uint> ht = new Dictionary<VertexData, uint>();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < in_vertices.Count; i++)
            {
                VertexData vertexData = new VertexData(in_vertices[i], in_uvs[i]);

                uint index;
                bool found = getSimilarVertexIndex_Fast(vertexData, ht, out index);

                if (found)
                {
                    out_indices.Add(index);
                }
                else
                {
                    out_vertices.Add(in_vertices[i]);
                    out_uvs.Add(in_uvs[i]);
                    uint newIndex = (uint)out_vertices.Count - 1;
                    out_indices.Add(newIndex);
                    ht[vertexData] = newIndex;
                }
            }
            watch.Stop();
            Console.WriteLine($"Time execution fast: {watch.ElapsedMilliseconds} ms");
        }

        static bool getSimilarVertexIndex_Fast(VertexData vertexData,
                                       Dictionary<VertexData, uint> dictionary,
                                       out uint result)
        {
            if(dictionary.TryGetValue(vertexData, out result))
            {
                return true;
            }
            return false;
        }

        struct VertexData
        {
            Vector3 vertice;
            Vector2 uv;

            public VertexData(Vector3 vertice, Vector2 uv)
            {
                this.vertice = vertice;
                this.uv = uv;
            }
        }
    }
}
