using OpenTK;
using SharpEngine.Components.Base;
using SharpEngine.Render;

namespace SharpEngine.Components
{
    public enum LightType
    {
        PointLight,
        DirectionalLight,
        SpotLight
    }

    public class Light : Component
    {
        public Shader LightShader; 
        public LightType LightType;
        public Vector3 LightColor;
        public Vector3 LightSpecular;

        public float Constant;
        public float Linear;
        public float Quadratic;

        public Light(Shader lightShader, LightType lightType, Vector3 lightColor, Vector3 lightSpecular, float quadratic, float linear, float constant) 
        {
            LightShader = lightShader;
            LightType = lightType;
            LightColor = lightColor;
            LightSpecular = lightSpecular;
            Quadratic = quadratic;
            Linear = linear;
            Constant = constant;
        }

        public void SetupLightColor()
        {
            LightShader.SetVector3("lightColor", LightColor);
        }
    }
}
