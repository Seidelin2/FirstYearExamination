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

			switch (type)
			{
				case "SoldierA":
					sr.SetSprite("Sprites/Unit/Unit_SoldierA");
					go.AddComponent(new Collider(sr));
					go.AddComponent(new Unit(100));
					break;
				case "SoldierB":
					sr.SetSprite("Sprites/Unit/Unit_SoldierB");
					go.AddComponent(new Collider(sr));
					go.AddComponent(new Unit(150));
					break;
			}

			return go;
		}
	}
}
