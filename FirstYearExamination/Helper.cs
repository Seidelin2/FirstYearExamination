using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstYearExamination
{
    public static class Helper
    {
		// all this is a math helper, witch is here to ensure that projectile are turned towards the enemy
        public static Texture2D CreateTexture(GraphicsDevice device, int width, int height, Func<int, Color> paint)
        {
            Texture2D texture = new Texture2D(device, width, height);
            Color[] data = new Color[width * height];
            for (int pixel = 0; pixel < data.Length; pixel++)
            {
                data[pixel] = paint(pixel);
            }
            texture.SetData(data);
            return texture;
        }

		public static Random random = new Random();

		/// <summary>
		/// Calculate a random number between the minValue and the maxValue.
		/// </summary>
		/// <param name="minValue">minValue</param>
		/// <param name="maxValue">maxValue</param>
		/// <returns></returns>
		public static int GetRandomValue(int minValue, int maxValue)
		{
			return random.Next(minValue, maxValue);
		}

		/// <summary>
		/// Calculate a random number between 0 and the value.
		/// </summary>
		/// <param name="value">maxValue</param>
		/// <returns></returns>
		public static int GetRandomValue(int value)
		{
			return GetRandomValue(0, value);
		}

		/// <summary>
		/// Calculate Sine 
		/// </summary>
		/// <param name="degrees"></param>
		/// <returns></returns>
		public static float Sin(float degrees)
		{
			return (float)Math.Sin(degrees / 180f * Math.PI);
		}

		/// <summary>
		/// Calculate cosine 
		/// </summary>
		/// <param name="degrees"></param>
		/// <returns></returns>
		public static float Cos(float degrees)
		{
			return (float)Math.Cos(degrees / 180f * Math.PI);
		}

		public static float CalculateAngleBetweenPositions(Vector2 fromPosition, Vector2 toPosition)
		{
			// Calculate position distance in Vector2
			Vector2 vectorTowardsToVector = toPosition - fromPosition;

			// Distance from toPosition.
			float distance = vectorTowardsToVector.Length();

			// Only do calculate if distance is greater than 0.
			if (distance > 0)
			{
				float dot = Vector2.Dot
				(
					// Vector point right.
					new Vector2(1, 0),
					// Vector pointing towards destination.
					Vector2.Normalize(vectorTowardsToVector)
				);

				// Calculate degrees.
				float degrees = MathHelper.ToDegrees((float)Math.Acos(dot));

				// TODO : donno what to write here
				if (vectorTowardsToVector.Y < 0)
				{
					degrees = 360 - degrees;
				}

				return degrees;
			}
			else
			{
				return 0;
			}
		}


	}
}
