using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstYearExamination.Static_Components
{
	public class TextureHelper
	{
		public static Texture2D CreateTexture(GraphicsDevice device, int width, int height, Func<int, Color> paint)
		{
			//initialize a texture
			Texture2D texture = new Texture2D(device, width, height);

			//the array holds the color for each pixel in the texture
			Color[] data = new Color[width * height];
			for (int pixel = 0; pixel < data.Count(); pixel++)
			{
				//the function applies the color according to the specified pixel
				data[pixel] = paint(pixel);
			}

			//set the color
			texture.SetData(data);

			return texture;
		}
	}
}
