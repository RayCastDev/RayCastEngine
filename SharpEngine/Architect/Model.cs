namespace SharpEngine.Architect
{
    public class Model: GameObject
    {

        public Mesh Mesh;
        public Material Material;

        public Model(Material m, Mesh mesh, Transform transform = null) : base (transform)
        {
            Material = m;
            this.Mesh = mesh;
            AddComponent(m);
            AddComponent(mesh);
        }

    }
}
