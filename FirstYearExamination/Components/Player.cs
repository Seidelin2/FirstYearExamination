using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstYearExamination.Observer;
using Microsoft.Xna.Framework;

namespace FirstYearExamination.Components
{
	public class Player : Component, IGameListener
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

		public override void Destroy()
		{
			GameWorld.Instance.Colliders.Remove((Collider)GameObject.GetComponent("Collider"));
		}

		public void Notify(GameEvent gameEvent, Component other)
		{
			if (gameEvent.Title == "Collider" && other.GameObject.Tag == "Friend")
			{
				other.GameObject.Destroy();
			}
		}
	}
}
