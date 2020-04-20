using OpenTK;

namespace SharpEngine.Helpers.Meshes
{
    public class TestMeshes
    {
        //public static TexturedVertex[] GetVertices()
        //{
        //    return  new TexturedVertex[] {
        //        new TexturedVertex(new Vector3( -0.5f, -0.5f, -0.5f), new Vector2(0.0f, 0.0f)),
        //        new TexturedVertex(new Vector3(  0.5f, -0.5f, -0.5f), new Vector2(1.0f, 0.0f)),
        //        new TexturedVertex(new Vector3(  0.5f,  0.5f, -0.5f), new Vector2(1.0f, 1.0f)),
        //        new TexturedVertex(new Vector3(  0.5f,  0.5f, -0.5f), new Vector2(1.0f, 1.0f)),
        //        new TexturedVertex(new Vector3( -0.5f,  0.5f, -0.5f), new Vector2(0.0f, 1.0f)),
        //        new TexturedVertex(new Vector3( -0.5f, -0.5f, -0.5f), new Vector2(0.0f, 0.0f)),

        //        new TexturedVertex(new Vector3( -0.5f, -0.5f,  0.5f), new Vector2(0.0f, 0.0f)),
        //        new TexturedVertex(new Vector3(  0.5f, -0.5f,  0.5f), new Vector2(1.0f, 0.0f)),
        //        new TexturedVertex(new Vector3(  0.5f,  0.5f,  0.5f), new Vector2(1.0f, 1.0f)),
        //        new TexturedVertex(new Vector3(  0.5f,  0.5f,  0.5f), new Vector2(1.0f, 1.0f)),
        //        new TexturedVertex(new Vector3( -0.5f,  0.5f,  0.5f), new Vector2(0.0f, 1.0f)),
        //        new TexturedVertex(new Vector3( -0.5f, -0.5f,  0.5f), new Vector2(0.0f, 0.0f)),

        //        new TexturedVertex(new Vector3( -0.5f,  0.5f,  0.5f), new Vector2(1.0f, 0.0f)),
        //        new TexturedVertex(new Vector3( -0.5f,  0.5f, -0.5f), new Vector2(1.0f, 1.0f)),
        //        new TexturedVertex(new Vector3( -0.5f, -0.5f, -0.5f), new Vector2(0.0f, 1.0f)),
        //        new TexturedVertex(new Vector3( -0.5f, -0.5f, -0.5f), new Vector2(0.0f, 1.0f)),
        //        new TexturedVertex(new Vector3( -0.5f, -0.5f,  0.5f), new Vector2(0.0f, 0.0f)),
        //        new TexturedVertex(new Vector3( -0.5f,  0.5f,  0.5f), new Vector2(1.0f, 0.0f)),

        //        new TexturedVertex(new Vector3(  0.5f,  0.5f,  0.5f), new Vector2(1.0f, 0.0f)),
        //        new TexturedVertex(new Vector3(  0.5f,  0.5f, -0.5f), new Vector2(1.0f, 1.0f)),
        //        new TexturedVertex(new Vector3(  0.5f, -0.5f, -0.5f), new Vector2(0.0f, 1.0f)),
        //        new TexturedVertex(new Vector3(  0.5f, -0.5f, -0.5f), new Vector2(0.0f, 1.0f)),
        //        new TexturedVertex(new Vector3(  0.5f, -0.5f,  0.5f), new Vector2(0.0f, 0.0f)),
        //        new TexturedVertex(new Vector3(  0.5f,  0.5f,  0.5f), new Vector2(1.0f, 0.0f)),

        //        new TexturedVertex(new Vector3( -0.5f, -0.5f, -0.5f), new Vector2(0.0f, 1.0f)),
        //        new TexturedVertex(new Vector3(  0.5f, -0.5f, -0.5f), new Vector2(1.0f, 1.0f)),
        //        new TexturedVertex(new Vector3(  0.5f, -0.5f,  0.5f), new Vector2(1.0f, 0.0f)),
        //        new TexturedVertex(new Vector3(  0.5f, -0.5f,  0.5f), new Vector2(1.0f, 0.0f)),
        //        new TexturedVertex(new Vector3( -0.5f, -0.5f,  0.5f), new Vector2(0.0f, 0.0f)),
        //        new TexturedVertex(new Vector3( -0.5f, -0.5f, -0.5f), new Vector2(0.0f, 1.0f)),

        //        new TexturedVertex(new Vector3( -0.5f,  0.5f, -0.5f), new Vector2(0.0f, 1.0f)),
        //        new TexturedVertex(new Vector3(  0.5f,  0.5f, -0.5f), new Vector2(1.0f, 1.0f)),
        //        new TexturedVertex(new Vector3(  0.5f,  0.5f,  0.5f), new Vector2(1.0f, 0.0f)),
        //        new TexturedVertex(new Vector3(  0.5f,  0.5f,  0.5f), new Vector2(1.0f, 0.0f)),
        //        new TexturedVertex(new Vector3( -0.5f,  0.5f,  0.5f), new Vector2(0.0f, 0.0f)),
        //        new TexturedVertex(new Vector3( -0.5f,  0.5f, -0.5f), new Vector2(0.0f, 1.0f)),
        //    };
        //}


        public static readonly float[] box =
        {
            -0.5f, -0.5f, -0.5f,  0.0f, 0.0f,
             0.5f, -0.5f, -0.5f,  1.0f, 0.0f,
             0.5f,  0.5f, -0.5f,  1.0f, 1.0f,
             0.5f,  0.5f, -0.5f,  1.0f, 1.0f,
            -0.5f,  0.5f, -0.5f,  0.0f, 1.0f,
            -0.5f, -0.5f, -0.5f,  0.0f, 0.0f,

            -0.5f, -0.5f,  0.5f,  0.0f, 0.0f,
             0.5f, -0.5f,  0.5f,  1.0f, 0.0f,
             0.5f,  0.5f,  0.5f,  1.0f, 1.0f,
             0.5f,  0.5f,  0.5f,  1.0f, 1.0f,
            -0.5f,  0.5f,  0.5f,  0.0f, 1.0f,
            -0.5f, -0.5f,  0.5f,  0.0f, 0.0f,

            -0.5f,  0.5f,  0.5f,  1.0f, 0.0f,
            -0.5f,  0.5f, -0.5f,  1.0f, 1.0f,
            -0.5f, -0.5f, -0.5f,  0.0f, 1.0f,
            -0.5f, -0.5f, -0.5f,  0.0f, 1.0f,
            -0.5f, -0.5f,  0.5f,  0.0f, 0.0f,
            -0.5f,  0.5f,  0.5f,  1.0f, 0.0f,

             0.5f,  0.5f,  0.5f,  1.0f, 0.0f,
             0.5f,  0.5f, -0.5f,  1.0f, 1.0f,
             0.5f, -0.5f, -0.5f,  0.0f, 1.0f,
             0.5f, -0.5f, -0.5f,  0.0f, 1.0f,
             0.5f, -0.5f,  0.5f,  0.0f, 0.0f,
             0.5f,  0.5f,  0.5f,  1.0f, 0.0f,

            -0.5f, -0.5f, -0.5f,  0.0f, 1.0f,
             0.5f, -0.5f, -0.5f,  1.0f, 1.0f,
             0.5f, -0.5f,  0.5f,  1.0f, 0.0f,
             0.5f, -0.5f,  0.5f,  1.0f, 0.0f,
            -0.5f, -0.5f,  0.5f,  0.0f, 0.0f,
            -0.5f, -0.5f, -0.5f,  0.0f, 1.0f,

            -0.5f,  0.5f, -0.5f,  0.0f, 1.0f,
             0.5f,  0.5f, -0.5f,  1.0f, 1.0f,
             0.5f,  0.5f,  0.5f,  1.0f, 0.0f,
             0.5f,  0.5f,  0.5f,  1.0f, 0.0f,
            -0.5f,  0.5f,  0.5f,  0.0f, 0.0f,
            -0.5f,  0.5f, -0.5f,  0.0f, 1.0f
        };


        public static readonly float[] triandle =
        {
            -0.9f, -0.5f, 0.0f,       0.0f, 0.0f, // Left 
            -0.0f, -0.5f, 0.0f,       1.0f, 0.0f, // Right
            -0.45f, 0.5f, 0.0f,       0.5f, 1.0f  // Top 
        };

        public static readonly float[] pyramide =
        {
           0,  0.5f, 0,        0.5f, 1,
          -0.5f, -0.5f, 0.5f,        1, 0,
           0.5f, -0.5f, 0.5f,        0, 0,

           0,  0.5f, 0,        0.5f, 1,
          -0.5f, -0.5f, 0.5f,        1, 0,
           0, -0.5f,-0.5f,        0, 0,

           0,  0.5f, 0,        0.5f, 1,
           0, -0.5f,-0.5f,        1, 0,
           0.5f, -0.5f, 0.5f,        0, 0,

          -0.5f, -0.5f, 0.5f,         0.5f, 1,
           0, -0.5f,-0.5f,        1, 0,
           0.5f, -0.5f, 0.5f,         0, 0
        };

        public static readonly float[] pyramide_V =
        {
           0,  0.5f, 0,
          -0.5f, -0.5f, 0.5f,
           0.5f, -0.5f, 0.5f,

           0,  0.5f, 0,
          -0.5f, -0.5f, 0.5f,
           0, -0.5f,-0.5f,

           0,  0.5f, 0,
           0, -0.5f,-0.5f,
           0.5f, -0.5f, 0.5f,

          -0.5f, -0.5f, 0.5f,
           0, -0.5f,-0.5f,
           0.5f, -0.5f, 0.5f
        };



        public static readonly float[] pyramide_UV =
        {
                0.5f, 1,
                 1, 0,
                   0, 0,

                  0.5f, 1,
                  1, 0,
                 0, 0,

                0.5f, 1,
                   1, 0,
                   0, 0,

                   0.5f, 1,
                1, 0,
                  0, 0
        };

        public static readonly Vector3[] pyramide_V3 =
        {
          new Vector3( 0,  0.5f, 0),
           new Vector3(-0.5f, -0.5f, 0.5f),
            new Vector3(0.5f, -0.5f, 0.5f),

           new Vector3( 0,  0.5f, 0),
          new Vector3( -0.5f, -0.5f, 0.5f),
           new Vector3( 0, -0.5f,-0.5f),

           new Vector3( 0,  0.5f, 0),
           new Vector3( 0, -0.5f,-0.5f),
           new Vector3( 0.5f, -0.5f, 0.5f),

           new Vector3(-0.5f, -0.5f, 0.5f),
           new Vector3( 0, -0.5f,-0.5f),
           new Vector3( 0.5f, -0.5f, 0.5f)
        };

        public static readonly Vector2[] pyramide_UV2 =
        {
            new Vector2(0.5f, 1),
            new Vector2( 1, 0),
             new Vector2(  0, 0),

             new Vector2( 0.5f, 1),
             new Vector2( 1, 0),
            new Vector2( 0, 0),

           new Vector2( 0.5f, 1),
            new Vector2(   1, 0),
             new Vector2(  0, 0),

             new Vector2(  0.5f, 1),
           new Vector2( 1, 0),
             new Vector2( 0, 0)
        };
    }
}




    


