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
                        1, 400, 1, 200, 20, "Fast Tower", ProjectileType.Smallmissile);
                    sr.SetSprite("Sprites/Towers/Tower_Holder1");
                    break;
                case TowerType.Slow_Tower:
                    Tower = new Slow_Tower (
                        //damnge, range, firerate, projectilespeed, cost, name, projectiletype
                        1, 400, 1, 200, 20, "Slow Tower", ProjectileType.Bigmissile);
                    sr.SetSprite("Sprites/Towers/Tower_Holder2");
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
