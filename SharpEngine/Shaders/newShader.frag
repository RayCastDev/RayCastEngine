#version 420 core

in vec3 normal;
in vec3 FragPos;
in vec2 texCoord;
out vec4 color;

uniform int pointLightCount;
//uniform vec3 lightColor;
uniform vec3 viewPos;

struct DirLight{
	vec3 direction;
	vec3 ambient;
	vec3 diffuse;
	vec3 specular;
};

struct PointLight{
	vec3 position;

	float constant;
	float linear;
	float quadratic;

	vec3 ambient;
	vec3 diffuse;
	vec3 specular;
};
#define NR_POINT_LIGHT 25
uniform PointLight pointLights[NR_POINT_LIGHT];
uniform DirLight dirLight;

struct Material
{
	sampler2D diffuse;
	sampler2D specular;
	float shininess;
};

//struct Light {
//    vec3 position;
//	//vec3 direction;
//
//    vec3 ambient;
//    vec3 diffuse;
//    vec3 specular;
//
//
//	float constant;
//	float linear;
//	float quadratic;
//};
//
//uniform Light light;  

uniform Material material;

vec3 CalcDirLight(DirLight light, vec3 normal, vec3 viewDir);
vec3 CalcPointLight(PointLight light, vec3 normal, vec3 fragPos, vec3 viewDir);

void main()
{
	vec3 norm = normalize(normal);
	vec3 viewDir = normalize(viewPos - FragPos);

	vec3 result = CalcDirLight(dirLight, norm, viewDir);

	for(int i = 0; i < pointLightCount; i++)
	{
		result += CalcPointLight(pointLights[i],norm,FragPos,viewDir);
	}

	color = vec4(result, 1.0);

//	//ambient
//	vec3 ambient = light.ambient * vec3(texture(material.diffuse, texCoord));
//
//	//diffuse
//	vec3 norm = normalize(normal);
//	vec3 lightDir = normalize(light.position - FragPos);
//	//vec3 lightDir = normalize(-light.direction);
//	float diff = max(dot(norm, lightDir),0.0);
//	vec3 diffuse = light.diffuse * diff * vec3(texture(material.diffuse,texCoord));
//
//	//specular
//	vec3 viewDir = normalize(viewPos - FragPos);
//	vec3 reflectDir = reflect(-lightDir, norm);
//	float spec = pow(max(dot(viewDir,reflectDir),0.0),material.shininess);
//	vec3 specular = light.specular * spec * vec3(texture(material.specular, texCoord));
//
//	float distance = length(light.position - FragPos);
//	float attenuation = 1.0 / (light.constant + light.linear * distance + light.quadratic * (distance * distance));
//
//	ambient *= attenuation;
//	diffuse *= attenuation;
//	specular *= attenuation;
//
//	vec3 result = ambient + diffuse + specular;
//	color = vec4(result,1.0);
}

vec3 CalcDirLight(DirLight light, vec3 normal, vec3 viewDir)
{
	vec3 lightDir = normalize(-light.direction);

	//diffuse
	float diff = max(dot(normal,lightDir),0.0);
	//specular
	vec3 reflectDir = reflect(-lightDir, normal);
	float spec = pow(max(dot(viewDir,reflectDir),0.0),material.shininess);

	//combine
	vec3 ambient = light.ambient * vec3(texture(material.diffuse, texCoord));
	vec3 diffuse = light.diffuse * diff * vec3(texture(material.diffuse, texCoord));
	vec3 specular = light.specular * spec * vec3(texture(material.specular, texCoord));

	return (ambient+diffuse+specular);
}

vec3 CalcPointLight(PointLight light, vec3 normal, vec3 fragPos, vec3 viewDir)
{
	vec3 lightDir = normalize(light.position - fragPos);

	//diffuse
	float diff = max(dot(normal, lightDir), 0.0);

	//specular
	vec3 reflectDir = reflect(-lightDir, normal);
	float spec = pow(max(dot(viewDir,reflectDir),0.0), material.shininess);

	//attenuation
	float distance = length(light.position - fragPos);
	float attenuation = 1.0 / (light.constant + light.linear * distance + light.quadratic * (distance * distance));

	//combine
	vec3 ambient = light.ambient * vec3(texture(material.diffuse, texCoord));
	vec3 diffuse = light.diffuse * diff * vec3(texture(material.diffuse, texCoord));
	vec3 specular = light.specular * spec * vec3(texture(material.specular, texCoord));

	ambient *= attenuation;
	diffuse *= attenuation;
	specular *= attenuation;

	return (ambient + diffuse + specular);
}