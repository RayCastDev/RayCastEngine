#version 420 core

layout(location = 0) in vec3 aPosition;

out vec2 texCoord;

uniform mat4 transform;

void main()
{
//	texCoord = aTexCoord;
	//gl_Position = vec4(aPosition, 1.0);
	gl_Position = transform * vec4(aPosition, 1.0f);
}