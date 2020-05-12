using FirstYearExamination.Observer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstYearExamination.Components
{
	public class Collider : Component
	{
		public bool CheckCollisionEvents { get; set; } = true;

		private GameEvent onCollisionEvent = new GameEvent("Collider");

		private Vector2 size;
		private Vector2 origin;
		private Texture2D texture;
		private SpriteRenderer spriteRenderer;

		public Rectangle CollisionBox
		{
			get
			{
				return new Rectangle
				(
					(int)(GameObject.Transform.Position.X - origin.X),
					(int)(GameObject.Transform.Position.Y - origin.Y),
					(int)size.X,
					(int)size.Y
				);
			}
		}

		public Collider(SpriteRenderer spriteRenderer)
		{
			this.origin = spriteRenderer.Origin;
			this.spriteRenderer = spriteRenderer;
			this.size = new Vector2(spriteRenderer.Sprite.Width, spriteRenderer.Sprite.Height);
			texture = GameWorld.Instance.Content.Load<Texture2D>("Sprites/CollisionTexture");
		}

		public Collider(SpriteRenderer spriteRenderer, IGameListener gameListner)
		{
			onCollisionEvent.Attach(gameListner);
			this.origin = spriteRenderer.Origin;
			this.spriteRenderer = spriteRenderer;
			this.size = new Vector2(spriteRenderer.Sprite.Width, spriteRenderer.Sprite.Height);
			texture = GameWorld.Instance.Content.Load<Texture2D>("Sprites/CollisionTexture");
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			Rectangle collisionBox = CollisionBox;
			Rectangle topLine = new Rectangle(collisionBox.X, collisionBox.Y, collisionBox.Width, 1);
			Rectangle bottomLine = new Rectangle(collisionBox.X, collisionBox.Y + collisionBox.Height, collisionBox.Width, 1);
			Rectangle rigthLine = new Rectangle(collisionBox.X + collisionBox.Width, collisionBox.Y, 1, collisionBox.Height);
			Rectangle leftLine = new Rectangle(collisionBox.X, collisionBox.Y, 1, collisionBox.Height);

			spriteBatch.Draw(spriteRenderer.Sprite, topLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
			spriteBatch.Draw(spriteRenderer.Sprite, bottomLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
			spriteBatch.Draw(spriteRenderer.Sprite, rigthLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
			spriteBatch.Draw(spriteRenderer.Sprite, leftLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
		}

		public void OnCollisionEnter(Collider other)
		{
			if (CheckCollisionEvents)
			{
				if (other != this)
				{
					if (CollisionBox.Intersects(other.CollisionBox))
					{
						onCollisionEvent.Notify(other);
					}
				}
			}
		}

		public override string ToString()
		{
			return "Collider";
		}
	}
}
