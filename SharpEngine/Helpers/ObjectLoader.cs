using OpenTK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.Helpers
{


    public class ObjectLoader
    {


        public bool LoadObject(string path, List<Vector3> out_vertices, List<Vector2> out_uvs)
        {
            List<uint> vertexIndices, uvIndices;
            vertexIndices = new List<uint>();
            uvIndices = new List<uint>();

            List<Vector3> temp_vertices = new List<Vector3>();
            List<Vector2> temp_uvs = new List<Vector2>();


            string line;
            StreamReader sr = new StreamReader(path);
            while ((line = sr.ReadLine()) != null)
            {
                string[] line_elements = line.Split(' ');
                switch(line_elements[0])
                {
                    case "v":
                        temp_vertices.Add(new Vector3(float.Parse(line_elements[1]),
                                                      float.Parse(line_elements[2]), 
                                                      float.Parse(line_elements[3])));
                        break;
                    case "vt":
                        temp_uvs.Add(new Vector2(float.Parse(line_elements[1]),
                                                 float.Parse(line_elements[2])));
                        break;
                    case "f":
                        for (int i = 1; i < line_elements.Length; i++)
                        {
                            string[] indices = line_elements[i].Split('/');
                            vertexIndices.Add(uint.Parse(indices[0]));
                            uvIndices.Add(uint.Parse(indices[1]));
                        }                        
                        break;
                }
               
            }

            for (int i = 0; i < vertexIndices.Count; i++)
            {
                uint vertexIndex = vertexIndices[i];
                uint uvIndex = uvIndices[i];

                Vector3 vertex = temp_vertices[(int)vertexIndex - 1];
                Vector2 uv = temp_uvs[(int)uvIndex - 1];


                out_vertices.Add(vertex);
                out_uvs.Add(uv);
            }


            //for (int i = 0; i < tempVertices.Count; i++)
            //{
            //    //PackedVertex packed = new PackedVertex(tempVertices[i], tempUVs[i]);

            //    uint index;

            //    //bool found = getSimilarVertexIndex_Fast(packed, VertexToOutIndex, ref index);
            //    bool found = getSimilarVertexIndex_Slow(tempVertices[i], in_uvs[i], out_vertices, out_uvs, out index);

            //    if (found)
            //    {
            //        vertexIndices.Add(index);
            //    }
            //    else
            //    {
            //        out_vertices.Add(tempVertices[i]);
            //        out_uvs.Add(in_uvs[i]);
            //        uint newindex = (uint)out_vertices.Count - 1;
            //        vertexIndices.Add(newindex);
            //        //VertexToOutIndex[packed] = newindex;
            //    }
            //}

            //var l = dict.OrderBy(key=>key.Key);
            //dict = l.ToDictionary((keyItem) => keyItem.Key, (valueItem) => valueItem.Value);
            //foreach (KeyValuePair<uint, uint> pair in dict)
            //{
            //    finalUVs.Add(tempUVs[Convert.ToInt32(pair.Value)]);
            //}
            return true;
        }

        //bool getSimilarVertexIndex_Fast(PackedVertex packed,Dictionary<PackedVertex, uint> vertexToOutIndex, ref uint result)
        //{
        //    if(VertexToOutIndex.ContainsKey(packed))
        //    {
        //        result = VertexToOutIndex[packed];
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        

       
    }

}
