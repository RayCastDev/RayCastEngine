using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using SharpEngine.Components;
using SharpEngine.Render.Base;

namespace SharpEngine.Render
{
    public class MaterialModel : Material
    {
        public Vector3 Ambient;
        public Vector3 Diffuse;
        public Vector3 Specular;

        public float Shininess;

        public Texture[] Textures;

        public MaterialModel(Shader shader, Texture[] textures)
        {
            Shader = shader;
            Textures = textures;
        }

        public override void SetMaterialParams(Camera camera, List<Light> lights, Transform modelTransform)
        {
            Shader.Use();
            Shader.SetVector3("material.ambient", Ambient);
            Shader.SetVector3("material.specular", Specular);
            Shader.SetVector3("material.diffuse", Diffuse);
            Shader.SetFloat("material.shininess", Shininess);

            SetLight(lights);

            BindTexture();
            SetTextures();
            SetupViewPosition(camera.owner.Transform.Position);


            base.SetMaterialParams(camera,lights,modelTransform);
        }

        public void SetLight(List<Light> lights)
        {
            int pointLightsCount = 0;
            for (int i = 0; i < lights.Count; i++)
            {
                if (lights[i].LightType == LightType.PointLight)
                {
                    SetPointLight(lights[i], i);
                    pointLightsCount++;
                }
                if (lights[i].LightType == LightType.DirectionalLight)
                {
                    SetDirectionalLight(lights[i]);
                }
            }
            Shader.SetInt("pointLightCount", pointLightsCount);
        }

        private void SetDirectionalLight(Light light)
        {
            float pitch = MathHelper.DegreesToRadians(light.owner.Transform.Rotation.X);
            float yaw = MathHelper.DegreesToRadians(light.owner.Transform.Rotation.Y);
            Vector3 direction;
            direction.X = (float)Math.Cos(pitch) * (float)Math.Cos(yaw);
            direction.Y = (float)Math.Sin(pitch);
            direction.Z = (float)Math.Cos(pitch) * (float)Math.Sin(yaw);

            direction = direction.Normalized();

            Shader.SetVector3("dirLight.direction", direction);

            Shader.SetVector3("dirLight.diffuse", light.LightColor);
            Shader.SetVector3("dirLight.ambient", light.LightColor);
            Shader.SetVector3("dirLight.specular", light.LightSpecular);
        }

        private void SetPointLight(Light light, int index)
        {
            Shader.SetVector3($"pointLights[{index}].diffuse", light.LightColor);
            Shader.SetVector3($"pointLights[{index}].ambient", light.LightColor);
            Shader.SetVector3($"pointLights[{index}].specular", light.LightSpecular);

            Shader.SetVector3($"pointLights[{index}].position", light.owner.Transform.Position);
            //Shader.SetVector3($"pointLights[{index}].direction", light.owner.Transform.Rotation);

            Shader.SetFloat($"pointLights[{index}].constant", light.Constant);
            Shader.SetFloat($"pointLights[{index}].linear", light.Linear);
            Shader.SetFloat($"pointLights[{index}].quadratic", light.Quadratic);
        }


        public void SetupViewPosition(Vector3 viewPosition) => Shader.SetVector3("viewPos", viewPosition);

        public void SetTextures()
        {
            if (Textures == null) return;

            Shader.SetInt("material.diffuse", 0);
            Shader.SetInt("material.specular", 1);
        }

        public void BindTexture()
        {
            if (Textures == null) return;
            GL.BindTexture(TextureTarget.Texture2D, 0);
            var x = 33984;
            foreach (var text in Textures)
            {
                text.Use((TextureUnit) x);
                x++;
            }
        }

        public override void ClearHandles()
        {
            if (Textures == null) return;
            foreach (var text in Textures)
                if (text != null)
                    GL.DeleteTexture(text.Handle);
        }
    }
}