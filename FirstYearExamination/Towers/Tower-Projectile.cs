using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstYearExamination
{
    class Tower_Projectile
    {
        public float rotationVelocity = 3f;
        public float LinearVelocity = 4f;

        public Unit myTarget;

        public float speed = 100;
        public int damaget = 40;
        public Vector2 velocity;

        public Tower_Projectile(Texture2D _sprite, Vector2 _position, Vector2 _scale, float _layerDepth, float _speed, int _damget)
        {
            this.speed = _speed;
            this.damaget = _damget;
        }

        public override void Update()
        {
            if (myTarget == null || myTarget.IsAlive == false)
            {
                Destroy(this);

            }
            else
            {
                UpdateProjectile();
                ProjectileMovement();
                HitTarget();
            }

            base.Update();
        }

        public void HitTarget()
        {
            if (Vector2.Distance(myTarget.Transform.Position, transform.Position) < 5)
            {
                myTarget.Takedamage(damaget);
                Destroy(this);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }


        public void UpdateProjectile()
        {
            float deltaTime = Time.deltaTime;

            transform.Position += ((velocity * speed) * deltaTime);
        }

        public void ProjectileMovement()
        {
            Vector2 tmpDirection = new Vector2(0, 0);
            int offSet = 4;

            if (transform.Position.X < offSet + myTarget.Transform.Position.X)
            {
                tmpDirection += new Vector2(1, 0);
            }

            if (transform.Position.X + offSet > myTarget.Transform.Position.X)
            {
                tmpDirection += new Vector2(-1, 0);
            }

            if (transform.Position.Y < offSet + myTarget.Transform.Position.Y)
            {
                tmpDirection += new Vector2(0, 1);
            }

            if (transform.Position.Y + offSet > myTarget.Transform.Position.Y)
            {
                tmpDirection += new Vector2(0, -1);
            }

            tmpDirection.Normalize();

            velocity = tmpDirection;
        }
    }
}