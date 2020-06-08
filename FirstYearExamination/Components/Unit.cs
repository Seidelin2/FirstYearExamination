using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstYearExamination.ObjectPool;
using FirstYearExamination.Observer;
using FirstYearExamination.SQLite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FirstYearExamination.Components
{
	public class Unit : Component, IGameListener
	{
		protected float speed;
		protected Vector2 velocity;
		private Cell currentCell;
		private Texture2D fgSprite { get; set; }
		private Texture2D bgSprite { get; set; }
		private Vector2 fgHealthOrigin;
		private Vector2 bgHealthOrigin;

		protected int maxHealth = 30;
		public int unitHealth = 30;
		protected int goldAmount = 10;
		protected float healthPercentage { get { return (float)unitHealth / (float)maxHealth; } }

		public GoldUpdater goldUpdater { get; set; }

		public Unit(float _speed)
		{
			this.speed = _speed;
			bgSprite = Helper.CreateTexture(GameWorld.Instance.GraphicsDevice, 1, 1, pixel => Color.Black);
			fgSprite = Helper.CreateTexture(GameWorld.Instance.GraphicsDevice, 1, 1, pixel => Color.Lime);
		}

		public override void Awake()
		{
			GameObject.Tag = "Unit";
		}

		public override void Update(GameTime gameTime)
		{
			Move();
			CheckBounds();
			Destroy();
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			//Background linje for Health
			spriteBatch.Draw(bgSprite, new Rectangle((int)GameObject.Transform.Position.X + 8,
				(int)GameObject.Transform.Position.Y + 8, 48, 8), null, Color.White, 0, 
				bgHealthOrigin, SpriteEffects.None, 0.9f);
			//Foreground linje for Health som ændres baseret på hvor meget Health der er
			spriteBatch.Draw(fgSprite, new Rectangle((int)GameObject.Transform.Position.X + 9,
				(int)GameObject.Transform.Position.Y + 9, (int)(healthPercentage * 46), 6), null, Color.White, 0,
				fgHealthOrigin, SpriteEffects.None, 0.95f);
		}

		public override void Destroy()
		{
			if(unitHealth <= 0)
			{
				goldUpdater.UpdateGold(goldAmount);
				UnitPool.Instance.ReleaseObject(GameObject);
			}
			else if (currentCell.Neighbour == null)
			{
				UnitPool.Instance.ReleaseObject(GameObject);
			}
		}

		public void TakeDamage (int damage)
        {
			unitHealth -= damage;
			if (unitHealth <= 0)
            {
				GameWorld.Instance.RemoveGameObject(GameObject);
				GameObject.Transform.Position = new Vector2(-100, -100);
			}
	    }


		public override string ToString()
		{
			return "Unit";
		}

		public void SetWaypoint(Cell _destination)
		{
			currentCell = _destination;

			velocity = currentCell.WorldPos - GameObject.Transform.Position;
			velocity = Vector2.Normalize(velocity);
		}

		private void Move()
		{
			//Bevæger Unit baseret på positionen af Unit og den destination den skal hen mod
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

        public void Notify(GameEvent gameEvent, Component component)
        {
            
        }
    }
}
