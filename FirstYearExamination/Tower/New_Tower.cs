using FirstYearExamination.Components;
using FirstYearExamination.Factory;
using FirstYearExamination.Tower;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstYearExamination
{
    public class New_Tower : Component
    {
        protected int damage;
        protected int range;
        protected int fireRate;
        protected float currentFireRate;
        protected int projectileSpeed;
        protected  int cost;
        protected string name;
        protected GameObject target;

        protected ProjectileType projectiletype;

        public GameObject Target { get => target; set => target = value; }

        public New_Tower (int damage, int range, int fireRate, int projectileSpeed, int cost, string name, ProjectileType projectileType)
        {
            this.damage = damage;
            this.range = range;
            this.fireRate = fireRate;
            this.projectileSpeed = projectileSpeed;
            this.cost = cost;
            this.name = name;
            this.projectiletype = projectileType;
        }

        public New_Tower ()
        {

        }

        public override void Awake()
        {
            base.Awake();
        }

        public override void Destroy()
        {
            base.Destroy();
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            TowerFire();
        }

        public void FindTarget()
        {
            //TODO find target 
        }

        public void TowerFire()
        {
            if (target == null)
            {
                FindTarget();
            }
            else if (Vector2.Distance(target.Transform.Position, GameObject.Transform.Position) > range)
            {
                FindTarget();
            }
            else
            {
                if (currentFireRate <= 0)
                {
                    Shoot();
                }
                else
                {
                    currentFireRate -= GameWorld.DeltaTime;
                }
            }
        }

        public void Shoot()
        {
            currentFireRate = fireRate;
            GameObject go = ProjectileFactory.Instance.Create(projectiletype, target, GameObject.Transform.Position, damage, projectileSpeed);
            GameWorld.Instance.AddGameObject(go);
        }
    }
}
