#version 420 core
out vec4 outputColor;
in vec2 texCoord;


uniform sampler2D texture1;
uniform sampler2D texture2;

void main()
{
	//outputColor = texture(texture0,texCoord);
	outputColor = mix(texture(texture1,texCoord),texture(texture2,texCoord),0.2);
}