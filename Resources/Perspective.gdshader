// "Perspective" shader, used in Clickteam's Mobile and Console FNaF ports

shader_type canvas_item;

uniform float zoom = 200;		 // The zoom level for the texture
uniform bool isVertical = false; // Whether the texture should be rendered vertically
uniform bool noWrap = true;		 // Whether the texture should wrap or not

uniform sampler2D SCREEN_TEXTURE : hint_screen_texture, filter_linear_mipmap;

void fragment()
{
	const float MIN_OFFSET_FACTOR = 0.05;

	vec2 scaleFactor;
	vec2 offsetFactor;
	vec2 textureCoordinates;

	if(isVertical)
	{
		// Calculate the scale factor and offset factor for vertical texture
		scaleFactor = vec2(1.0 - (zoom * SCREEN_PIXEL_SIZE.x), 1.0);
		offsetFactor =
			vec2(max(MIN_OFFSET_FACTOR, 1.0 + (scaleFactor.x - 1.0) * 4.0 * pow((SCREEN_UV.y - 0.5), 2.0)), 1.0);

		// Calculate the texture coordinates for vertical texture
		textureCoordinates = SCREEN_UV * offsetFactor + vec2((1.0 - offsetFactor.x) / 2.0, 0.0);

		// Check if wrapping is allowed or if the texture coordinates are
		// within bounds
		if(!noWrap || (textureCoordinates.x >= 0.0 && textureCoordinates.x <= 1.0))
		{
			COLOR.rgb = textureLod(SCREEN_TEXTURE, textureCoordinates, 0.0).rgb;
		}
	}
	else
	{
		// Calculate the scale factor and offset factor for horizontal texture
		scaleFactor = vec2(1.0, 1.0 - (zoom * SCREEN_PIXEL_SIZE.y));
		offsetFactor =
			vec2(1.0, max(MIN_OFFSET_FACTOR, 1.0 + (scaleFactor.y - 1.0) * 4.0 * pow((SCREEN_UV.x - 0.5), 2.0)));

		// Calculate the texture coordinates for horizontal texture
		textureCoordinates = SCREEN_UV * offsetFactor + vec2(0.0, (1.0 - offsetFactor.y) / 2.0);

		// Check if wrapping is allowed or if the texture coordinates are
		// within bounds
		if(!noWrap || (textureCoordinates.y >= 0.0 && textureCoordinates.y <= 1.0))
		{
			COLOR.rgb = textureLod(SCREEN_TEXTURE, textureCoordinates, 0.0).rgb;
		}
	}
}