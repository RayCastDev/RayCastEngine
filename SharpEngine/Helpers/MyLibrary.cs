using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.Helpers
{
    public class MyLibrary
    {
        public static Matrix4 LookAt(Vector3 position, Vector3 target, Vector3 up)
        {
            Vector3 directionView = Vector3.Normalize((position - target));
            Vector3 right = Vector3.Normalize(Vector3.Cross(up, directionView));
            Vector3 cameraUp = Vector3.Cross(directionView, right);

            Matrix4 matrix1 = Matrix4.Identity;
            matrix1[0, 0] = right.X;
            matrix1[0, 1] = right.Y;
            matrix1[0, 2] = right.Z;
            matrix1[1, 0] = cameraUp.X;
            matrix1[1, 1] = cameraUp.Y;
            matrix1[1, 2] = cameraUp.Z;
            matrix1[2, 0] = directionView.X;
            matrix1[2, 1] = directionView.Y;
            matrix1[2, 2] = directionView.Z;

            Matrix4 matrix2 = Matrix4.Identity;
            matrix1[0, 3] = -position.X;
            matrix1[1, 3] = -position.Y;
            matrix1[2, 3] = -position.Z;

            
            return matrix1 * matrix2;
        }
    }
}
