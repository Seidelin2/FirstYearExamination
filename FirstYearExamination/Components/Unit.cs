using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstYearExamination.ObjectPool;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FirstYearExamination.Components
{
	public class Unit : Component
	{
		private float speed;
		private Vector2 velocity;

		public Unit(float speed, Vector2 velocity)
		{
			this.speed = speed;
			this.velocity = velocity;
		}

		public override void Awake()
		{
			GameObject.Tag = "Unit";
		}

		public override void Update(GameTime gameTime)
		{
			Move();
			CheckBounds();
		}

		public override void Destroy()
		{

		}

		private void Move()
		{
			GameObject.Transform.Translate(velocity * speed * GameWorld.DeltaTime);
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
