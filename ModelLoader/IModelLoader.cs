using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace ModelLoader
{
    public interface IModelLoader
    {
        bool LoadModel(string pathToModel, List<uint> outIndices, List<Vector3> outIndexedVertices, List<Vector2> outIndexedUvs, List<Vector3> outIndexedNormals);
    }
}
