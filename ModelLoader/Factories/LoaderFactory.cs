using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLoader.ModelLoaders;

namespace ModelLoader.Factories
{
    public static class LoaderFactory
    {
        public static IModelLoader GetModelLoader(string modelPath)
        {
            IModelLoader modelLoader = null;
            var extension = Path.GetExtension(modelPath);
            switch (extension)
            {
                case ".obj": modelLoader = new ObjLoader();
                    break;
            }
            return modelLoader;
        }
    }
}
