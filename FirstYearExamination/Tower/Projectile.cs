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
    public class Projectile : Component
    {

        int damage;
        int range;
        int projectileSpeed;
        string name;
        GameObject target;

        public Projectile(int damage, int range, int projectileSpeed, string name)
        {
            this.damage = damage;
            this.range = range;
            this.projectileSpeed = projectileSpeed;
            this.name = name;
        }

        public override void Awake()
        {
            base.Awake();
        }

        public override void Destroy()
        {
            base.Destroy();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
