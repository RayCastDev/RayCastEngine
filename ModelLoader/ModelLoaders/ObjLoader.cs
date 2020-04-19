using System;
using System.Collections.Generic;
using System.IO;
using ModelLoader.Utils;
using OpenTK;

namespace ModelLoader.ModelLoaders
{
    internal class ObjLoader : IModelLoader
    {
        public bool LoadModel(string pathToModel, List<uint> outIndices, List<Vector3> outIndexedVertices, List<Vector2> outIndexedUvs, List<Vector3> outIndexedNormals)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            var vertexIndices = new List<uint>();
            var uvIndices = new List<uint>();
            var normalIndices = new List<uint>();

            var tempVertices = new List<Vector3>();
            var tempUvs = new List<Vector2>();
            var tempNormals = new List<Vector3>();

            var outVertices = new List<Vector3>();
            var outUvs = new List<Vector2>();
            var outNormals = new List<Vector3>();

            string line;
            var sr = new StreamReader(pathToModel);
            while ((line = sr.ReadLine()) != null)
            {
                var lineElements = line.Split(' ');
                switch (lineElements[0])
                {
                    case "v":
                        tempVertices.Add(new Vector3(float.Parse(lineElements[1]),
                            float.Parse(lineElements[2]),
                            float.Parse(lineElements[3])));
                        break;
                    case "vt":
                        tempUvs.Add(new Vector2(float.Parse(lineElements[1]),
                            float.Parse(lineElements[2])));
                        break;
                    case "f":
                        {
                            for (var i = 1; i < lineElements.Length; i++)
                            {
                                var indices = lineElements[i].Split('/');
                                vertexIndices.Add(uint.Parse(indices[0]));
                                uvIndices.Add(uint.Parse(indices[1]));
                                normalIndices.Add(uint.Parse(indices[2]));
                            }

                            break;
                        }

                    case "vn":
                        tempNormals.Add(new Vector3(float.Parse(lineElements[1]),
                            float.Parse(lineElements[2]),
                            float.Parse(lineElements[3])));
                        break;
                }
            }

            for (var i = 0; i < vertexIndices.Count; i++)
            {
                var vertexIndex = vertexIndices[i];
                var uvIndex = uvIndices[i];
                var normalIndex = normalIndices[i];

                var vertex = tempVertices[(int)vertexIndex - 1];
                var uv = tempUvs[(int)uvIndex - 1];
                var normal = tempNormals[(int)normalIndex - 1];

                outVertices.Add(vertex);
                outUvs.Add(uv);
                outNormals.Add(normal);
            }

            VboIndexer.IndexVboFast(outVertices, outUvs, outNormals, outIndices, outIndexedVertices,outIndexedUvs,outIndexedNormals);

            watch.Stop();
            Console.WriteLine($"Obj Loaded! Loading time: {watch.ElapsedMilliseconds} ms");
            
            return true;
        }
    }
}
