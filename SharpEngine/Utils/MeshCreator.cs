using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLoader.Factories;
using OpenTK;
using SharpEngine.Components;
using SharpEngine.Render;

namespace SharpEngine.Utils
{
    static class MeshCreator
    {
        public static Mesh CreateMesh(string pathToMesh)
        {
            var modelLoader = LoaderFactory.GetModelLoader(pathToMesh);
            var indices = new List<uint>();
            var indexedVertices = new List<Vector3>();
            var indexedUvs = new List<Vector2>();
            var indexedNormals = new List<Vector3>();
            modelLoader.LoadModel(pathToMesh, indices, indexedVertices, indexedUvs, indexedNormals);

            return new Mesh(indexedVertices,indexedUvs,indexedNormals,indices);
        }
    }
}
