using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace FirstYearExamination.Components
{
	public class Player : Component
	{
		public Player()
		{

		}

		public override void Awake()
		{
			GameObject.Transform.Position = new Vector2(GameWorld.Instance.GraphicsDevice.Viewport.Width / 2,
			GameWorld.Instance.GraphicsDevice.Viewport.Height / 2);
		}

		public override void Start()
		{

		}

		public override string ToString()
		{
			return "Player";
		}
	}
}
