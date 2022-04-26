#version 330

out vec4 outputColor;

in vec4 vertexColor;

uniform vec4 ourColor;

void main()
{
	outputColor = ourColor;
}