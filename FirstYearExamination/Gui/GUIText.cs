using FirstYearExamination.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstYearExamination.GUI
{
	/// <summary>
	/// Lavet af Marius Rysgaard
	/// </summary>
	public class GUIText : Component
	{
		private SpriteFont font;

		public Color PenColour { get; set; }
		public Vector2 Position { get; set; }
		public string Text { get; set; }
		public Rectangle Rectangle
		{
			get
			{
				return new Rectangle((int)Position.X, (int)Position.Y, 100, 0);
			}
		}

		public GUIText(SpriteFont _font)
		{
			font = _font;
			PenColour = Color.Black;
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			if(!string.IsNullOrEmpty(Text))
			{
				var x = (Rectangle.X + (Rectangle.Width / 2)) - (font.MeasureString(Text).X / 2);
				var y = (Rectangle.Y + (Rectangle.Width / 2)) - (font.MeasureString(Text).Y / 2 - 35);

				spriteBatch.DrawString(font, Text, new Vector2(x, y), PenColour);
			}
		}
	}
}
