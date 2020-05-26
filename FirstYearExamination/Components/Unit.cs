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
		protected float speed;
		protected Vector2 velocity;
		private Cell currentCell;

		public Unit(float _speed)
		{
			this.speed = _speed;
		}

		public override void Awake()
		{
			GameObject.Tag = "Unit";
			//Map_01 Spawn Position
			//GameObject.Transform.Position = new Vector2(-64, 64);
			//Map_02 Spawn Position
			//GameObject.Transform.Position = new Vector2(64, -64);
			//Map_03 Spawn Position
			GameObject.Transform.Position = new Vector2(832, -64);
		}

		public override void Update(GameTime gameTime)
		{
			Move();
			CheckBounds();
		}

		public override void Destroy()
		{

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
