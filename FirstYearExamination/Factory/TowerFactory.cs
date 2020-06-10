using FirstYearExamination.Components;
using FirstYearExamination.Tower;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstYearExamination.Factory
{
    /// <summary>
	/// Lavet af Nicolai Toft
	/// </summary>
    public class TowerFactory : Factory
    {
        #region INSTANCE
        private static TowerFactory instance;

        public static TowerFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TowerFactory();
                }
                return instance;
            }
        }


        #endregion

        public override GameObject Create(string type)
        {
            throw new NotImplementedException();
        }

        public GameObject Create(TowerType towerType, Vector2 pos)
        {
            GameObject go = new GameObject();
            SpriteRenderer sr = new SpriteRenderer();

            New_Tower Tower = null;


            switch (towerType)
            {
                case TowerType.Fast_Tower:
                    Tower = new Fast_Tower(
                        //damnge, range, firerate, projectilespeed, cost, name, projectiletype
                        10, 600, 0.5f, 200, 20, "Fast Tower", ProjectileType.Smallmissile);
                    sr.SetSprite("Sprites/Towers/Tower_Holder1");
                    Collider colider = new Collider(sr,Tower) { CheckCollisionEvents = true };
                    colider.Tag = "Tower";
                    go.AddComponent(colider);
                    colider.Colliderscaler = new Vector2(4, 4);
                    float OffsetcalulationX = sr.Sprite.Width * colider.Colliderscaler.X/2;
                    float OffsetcalulationY = sr.Sprite.Height * colider.Colliderscaler.Y/2;
                    colider.Collideroffset = new Vector2(OffsetcalulationX, OffsetcalulationY);
                    break;
                case TowerType.Slow_Tower:
                    Tower = new Slow_Tower (
                        //damnge, range, firerate, projectilespeed, cost, name, projectiletype
                        30, 600, 2, 200, 20, "Slow Tower", ProjectileType.Bigmissile);
                    sr.SetSprite("Sprites/Towers/Tower_Holder2");
                    Collider colider02 = new Collider(sr, Tower) {CheckCollisionEvents  = true };
                    colider02.Tag = "Tower";
                    go.AddComponent(colider02);
                    break;
                case TowerType.AOE_Tower:
                    break;
                case TowerType.MultiTarget_Tower:
                    break;
                case TowerType.Random_Fire:
                    break;
                default:
                    break;
            }
            sr.SetOrigin();
            go.Transform.Position = pos;
            go.AddComponent(sr);
            go.AddComponent(Tower);

            return go;

        }

    }
}
