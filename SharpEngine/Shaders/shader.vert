#version 420 core

layout(location = 0) in vec3 aPosition;
layout(location = 1) in vec2 aTexCoord;
layout(location = 2) in vec3 aNormal;

out vec2 texCoord;
out vec3 normal;
out vec3 FragPos;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

//uniform mat4 transform;

void main()
{
//	texCoord = aTexCoord;
	//gl_Position = vec4(aPosition, 1.0);
	//gl_Position = transform * vec4(aPosition, 1.0f);

	FragPos = vec3(vec4(aPosition, 1.0f)* model);
    normal = aNormal * mat3(transpose(inverse(model)));
	texCoord = vec2(aTexCoord.x,aTexCoord.y);
	//gl_Position = vec4(aPosition,1.0f)*model*view*projection;
	gl_Position = vec4(FragPos, 1.0) * view * projection;


}