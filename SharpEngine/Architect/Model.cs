using OpenTK;
using SharpEngine.Buffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.Architect
{
    public class Model: GameObject
    {

        public Mesh mesh;//Mesh
        public Material material;

        public Model(Material m, Mesh mesh, Transform transform = null) : base (transform)
        {
            material = m;
            this.mesh = mesh;
            AddComponent(m);
            AddComponent(mesh);
        }

    }
}
