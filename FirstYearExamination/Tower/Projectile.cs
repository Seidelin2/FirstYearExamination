using FirstYearExamination.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstYearExamination.Tower
{
    /// <summary>
	/// Lavet af Nicolai Toft
	/// </summary>
    public class Projectile : Component
    {
        int damage;
        int projectileSpeed;
        string name;
        GameObject target;
        SpriteRenderer sr;

        public Projectile(int damage, int projectileSpeed, string names)
        {
            this.damage = damage;
            this.projectileSpeed = projectileSpeed;
            this.name = names;
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
            sr = (SpriteRenderer)GameObject.GetComponent("SpriteRenderer");
        }

        public override void Update(GameTime gameTime)
        {
            MoveToTarget(gameTime);
            base.Update(gameTime);
        }

        private void MoveToTarget(GameTime gameTime)
        {
            if (target == null)
            {
                Death();
            }
            else if (Vector2.Distance(target.Transform.Position, GameObject.Transform.Position) <= 5)
            {
                //TODO : do damage to the unit
                Unit tmp = (Unit)target.GetComponent("Unit");
                
                tmp.TakeDamage(damage);
                Death();
            }
            else
            {
                Vector2 targetPosition = target.Transform.Position;
                Vector2 myPosition = GameObject.Transform.Position;
                Vector2 direction = Vector2.Normalize(targetPosition - myPosition);


                GameObject.Transform.Position += direction * projectileSpeed * GameWorld.DeltaTime;
                LookAtTarget();
            }
        }

        public void SetTarget(GameObject target)
        {
            this.target = target;
        }

        public void SpawnPostition(Vector2 pos)
        {
            GameObject.Transform.Position = pos;
        }

        private void Death()
        {
            GameWorld.Instance.RemoveGameObject(GameObject);
        }

        private void LookAtTarget()
        {
           float rotation = Helper.CalculateAngleBetweenPositions(GameObject.Transform.Position, target.Transform.Position);
            sr.Rotation = rotation + 90; 
        }
    }
}
