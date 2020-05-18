using FirstYearExamination.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstYearExamination.Factory
{
	class UnitFactory : Factory
	{
		#region INSTANCE
		private static UnitFactory instance;

		public static UnitFactory Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new UnitFactory();
				}
				return instance;
			}
		}
		#endregion

		public override GameObject Create(string type)
		{
			GameObject go = new GameObject();
			SpriteRenderer sr = new SpriteRenderer();
			go.AddComponent(sr);
			go.Tag = "Unit";

			switch (type)
			{
				case "Unit":
					sr.SetSprite("Sprites/Unit/Unit_SoldierA");
					go.AddComponent(new Collider(sr) { CheckCollisionEvents = true });
					go.AddComponent(new Unit(100, new Vector2(1, 0)));
					break;
			}

			return go;
		}
	}
}
