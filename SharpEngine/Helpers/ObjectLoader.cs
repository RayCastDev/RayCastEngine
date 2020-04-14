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


        public static bool LoadObject(string path, List<Vector3> out_vertices, List<Vector2> out_uvs, List<Vector3> out_normals)
        {
            List<uint> vertexIndices, uvIndices, normalIndicies;
            vertexIndices = new List<uint>();
            uvIndices = new List<uint>();
            normalIndicies = new List<uint>();

            List<Vector3> temp_vertices = new List<Vector3>();
            List<Vector2> temp_uvs = new List<Vector2>();
            List<Vector3> temp_normals = new List<Vector3>();

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
                            normalIndicies.Add(uint.Parse(indices[2]));
                        }                        
                        break;
                    case "vn":
                        temp_normals.Add(new Vector3(float.Parse(line_elements[1]),
                                                     float.Parse(line_elements[2]),
                                                     float.Parse(line_elements[3])));
                        break;
                }
               
            }

            for (int i = 0; i < vertexIndices.Count; i++)
            {
                uint vertexIndex = vertexIndices[i];
                uint uvIndex = uvIndices[i];
                uint normalIndex = normalIndicies[i];

                Vector3 vertex = temp_vertices[(int)vertexIndex - 1];
                Vector2 uv = temp_uvs[(int)uvIndex - 1];
                Vector3 normal = temp_normals[(int)normalIndex - 1];

                out_vertices.Add(vertex);
                out_uvs.Add(uv);
                out_normals.Add(normal);
            }         

            return true;
        }     
    }

}
