using FirstYearExamination.Components;
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
    /// <summary>
	/// Lavet af Nicolai Toft
	/// </summary>
    public class Fast_Tower : New_Tower
    {
        public Fast_Tower(int damage, int range, float fireRate, int projectileSpeed, int cost, string name, ProjectileType projectileType)
        {
            this.damage = damage;
            this.range = range;
            this.fireRate = fireRate;
            this.projectileSpeed = projectileSpeed;
            this.cost = cost;
            this.name = name;
            this.projectiletype = projectileType;
        }

        public override void Awake()
        {
            MakeTower();
            base.Awake();
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            TowerFire();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        public void MakeTower()
        {

        }

        public void New_Tower()
        {
            
        }
    }
}
