using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using FirstYearExamination.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstYearExamination.Components
{
	/// <summary>
	/// Lavet af Marius Rysgaard
	/// </summary>
	public class Cell
	{
		private Texture2D cellTexture;
		private Vector2 worldPos;
		private Point gridPos;
		private Cell neighbour;

		public Cell Neighbour { get => neighbour; set => neighbour = value; }
		public Vector2 WorldPos { get => worldPos; set => worldPos = value; }
		public Point GridPos { get => gridPos; set => gridPos = value; }

		public Cell(Point _gridPos)
		{
			this.gridPos = _gridPos;
		}

		public void LoadContent(ContentManager content)
		{
			//Uses the texture in the map location to load in
			cellTexture = content.Load<Texture2D>("Sprites/Map/Cell_Texture");

			//Placing the texture in the grid position in the world
			worldPos = new Vector2(gridPos.X * cellTexture.Width, gridPos.Y * cellTexture.Height);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(cellTexture, worldPos, null, Color.White);
		}
	}
}
