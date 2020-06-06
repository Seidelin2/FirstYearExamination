using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstYearExamination.Towers
{
    public class Tower
    {
		public float fireRate;
		public float currentFireRate;

		public float range = 300;

		public Vector2 myTarget;

		public Tower_Projectile myProjectile;

		public Towers(Texture2D _sprite, Vector2 _position, Vector2 _scale, float _layerDepth,
			OriginPositionEnum _originPositionEnum, float _speed, float _fireRate)
		{
			this.sprite = _sprite;
			this.Transform.Position = _position;
			this.Transform.Scale = _scale;
			this.LayerDepth = _layerDepth;
			this.OriginPositionEnum = _originPositionEnum;
			this.speed = _speed;
			this.fireRate = _fireRate;
		}

		public Towers()
		{

		}

		public virtual void Projectile()
		{
			currentFireRate = fireRate;
		}

		public void MouseInput()
		{
			velocity = Vector2.Zero;

			if (Vector2.Distance(transform.Position, myTarget) <= range)
			{
				//Checks and updates based on the Right Button
				if (currentFireRate <= 0)
				{
					Projectile();
				}
			}
		}

		public void FindTarget()
		{
			MouseState state = Mouse.GetState();

			var mouseX = state.Position.X;
			var mouseY = state.Position.Y;

			Vector2 newPosition = new Vector2(mouseX, mouseY);

			Vector2 worldPosition = Vector2.Transform(newPosition, Matrix.Invert(SceneController.Camera.Transform));

			myTarget = worldPosition;
		}

		public override void Awake()
		{
			base.Awake();
		}

		public override void Start()
		{
			base.Start();
		}

		public override void Update()
		{
			MouseInput();

			FindTarget();

			if (currentFireRate > 0)
			{
				currentFireRate -= (float)Time.deltaTime;
			}

			base.Update();
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			Texture2D _sprite = sprite;
			Color _color = Color;

			spriteBatch.Draw(
				//Texture
				_sprite,

				//Position
				this.transform.Position,

				//Sprite Rectangle
				null,

				//Colour
				Color,

				//Rotation
				MathHelper.ToRadians(this.transform.Rotation),

				//Origin
				this.transform.Origin,

				//Scale
				this.transform.Scale,

				//Sprite Effect
				this.spriteEffects,

				//Layer Depth
				this.LayerDepth
				);
		}
	}
}
