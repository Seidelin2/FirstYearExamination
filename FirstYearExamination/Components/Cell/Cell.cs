using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstYearExamination.Components.A_Star
{
	public class Cell
	{
		private Texture2D cellTexture;
		private Vector2 worldPos;
		private Point gridPos;

		public Cell(Point _gridPos)
		{
			this.gridPos = _gridPos;
		}

		public void LoadContent(ContentManager content)
		{
			cellTexture = content.Load<Texture2D>("Sprites/Map/Cell_Texture");

			worldPos = new Vector2(gridPos.X * cellTexture.Width, gridPos.Y * cellTexture.Height);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(cellTexture, worldPos, null, Color.White);
		}
	}
}
