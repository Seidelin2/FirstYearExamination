using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstYearExamination.Components
{
	public abstract class Component
	{
		public bool IsEnabled { get; set; } = true;
		public GameObject GameObject { get; set; }

		public virtual void Awake()
		{

		}

		public virtual void Start()
		{

		}

		public virtual void Update(GameTime gameTime)
		{

		}

		public virtual void Draw(SpriteBatch spriteBatch)
		{

		}
		public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{

		}

		public virtual void Destroy()
		{

		}
	}
}
