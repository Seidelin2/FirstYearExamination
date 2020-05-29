using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstYearExamination.ObjectPool;
using FirstYearExamination.Static_Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FirstYearExamination.Components
{
	public class Unit : Component
	{
		protected float speed;
		protected Vector2 velocity;
		private Cell currentCell;
		private Texture2D fgSprite { get; set; }
		private Texture2D bgSprite { get; set; }
		private Vector2 fgHealthOrigin;
		private Vector2 bgHealthOrigin;

		protected int maxHealth = 30;
		protected int unitHealth = 30;
		protected float healthPercentage { get { return (float)unitHealth / (float)maxHealth; } }
		private int unitDamage = 10;
		private int moneyDrop = 5;

		public Unit(float _speed)
		{
			this.speed = _speed;
			bgSprite = TextureHelper.CreateTexture(GameWorld.Instance.GraphicsDevice, 1, 1, pixel => Color.Black);
			fgSprite = TextureHelper.CreateTexture(GameWorld.Instance.GraphicsDevice, 1, 1, pixel => Color.Lime);
			bgHealthOrigin = new Vector2(healthPercentage / 2, healthPercentage / 2);
			fgHealthOrigin = new Vector2(healthPercentage / 2, healthPercentage / 2 + 0.125f);
		}

		public override void Awake()
		{
			GameObject.Tag = "Unit";
			//Map_01 Spawn Position
			GameObject.Transform.Position = new Vector2(-64, 64);
			//Map_02 Spawn Position
			//GameObject.Transform.Position = new Vector2(64, -64);
			//Map_03 Spawn Position
			//GameObject.Transform.Position = new Vector2(832, -64);
		}

		public override void Update(GameTime gameTime)
		{
			Move();
			CheckBounds();
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(bgSprite, new Rectangle((int)GameObject.Transform.Position.X + 32,
				(int)GameObject.Transform.Position.Y + 8, 48, 8), null, Color.White, 0, 
				bgHealthOrigin, SpriteEffects.None, 0.9f);
			spriteBatch.Draw(fgSprite, new Rectangle((int)GameObject.Transform.Position.X + 32,
				(int)GameObject.Transform.Position.Y + 9, (int)(healthPercentage * 46), 6), null, Color.White, 0,
				fgHealthOrigin, SpriteEffects.None, 0.95f);
		}

		public override void Destroy()
		{
			if(unitHealth >= 0)
			{
				UnitPool.Instance.ReleaseObject(GameObject);
			}
		}

		public override string ToString()
		{
			return "Unit";
		}

		public void SetWaypoint(Cell _distination)
		{
			currentCell = _distination;

			velocity = currentCell.WorldPos - GameObject.Transform.Position;
			velocity = Vector2.Normalize(velocity);
		}

		private void Move()
		{
			if(Vector2.Distance(GameObject.Transform.Position, currentCell.WorldPos) > 1)
			{
				GameObject.Transform.Translate(velocity * speed * GameWorld.DeltaTime);
			}
			else if (currentCell.Neighbour != null)
			{
				SetWaypoint(currentCell.Neighbour);
			}
		}

		private void CheckBounds()
		{
			if(GameObject.Transform.Position.X > GameWorld.Instance.GraphicsDevice.Viewport.Width
				&& GameObject.Transform.Position.Y > GameWorld.Instance.GraphicsDevice.Viewport.Height)
			{
				UnitPool.Instance.ReleaseObject(GameObject);
			}
		}
	}
}
