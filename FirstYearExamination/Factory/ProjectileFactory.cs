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
    class ProjectileFactory : Factory
    {

        #region INSTANCE
        private static ProjectileFactory instance;

        public static ProjectileFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProjectileFactory();
                }
                return instance;
            }
        }
        #endregion


        public override GameObject Create(string type)
        {
            GameObject go = new GameObject();
            SpriteRenderer sr = new SpriteRenderer();
            Projectile projectile = new Projectile(10, 10, "Smallmissile");

            switch (type)
            {
                case "ProjcetileA":
                    sr.SetSprite("Sprites/Towers/Small_Missile");
                    go.AddComponent(sr);
                    go.AddComponent(projectile);

                    break;
                default:
                    break;
            }
            return go;
        }

        public GameObject Create(ProjectileType type, GameObject target, Vector2 pos)
        {
            GameObject go = new GameObject();
            SpriteRenderer sr = new SpriteRenderer();
            Projectile projectile;

            switch (type)
            {
                case ProjectileType.Smallmissile:
                    projectile = new Projectile(10, 50, "Small missile");
                    sr.SetSprite("Sprites/Towers/Small_Missile");
                    sr.SetOrigin();
                    go.AddComponent(sr);
                    go.AddComponent(projectile);
                    projectile.SetTarget(target);
                    go.Transform.Position = pos;
                    break;
                case ProjectileType.Bigmissile:
                    projectile = new Projectile(20, 50, "Big Missile");
                    sr.SetSprite("Sprites/Towers/Big_Missile");
                    sr.SetOrigin();
                    go.AddComponent(sr);
                    go.AddComponent(projectile);
                    projectile.SetTarget(target);
                    go.Transform.Position = pos;
                    break;
                default:
                    break;
            }
            return go;
        }
    }
}
