﻿using OpenTK;
using SharpEngine.Buffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.Mesh
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
    }
}