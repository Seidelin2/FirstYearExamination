using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FirstYearExamination.Towers.Tower_stats
{
    class Tower1 : Tower
    {
        public Tower1(Texture2D _sprite, Vector2 _position, Vector2 _scale, float _layerDepth, OriginPositionEnum _origin, int _tileSize, int _towerCost) : base(_sprite, _position, _scale, _layerDepth, _origin, _tileSize, _towerCost)
        {
            TowerStat();
        }

        public Tower1()
        {
            TowerStat();
        }

        public Tower1(Vector2 _position, Vector2 _scale, int _tileSize) : base(_position, _scale, _tileSize)
        {
            TowerStat();
        }

        public Tower1(int _towerCost) : base(_towerCost)
        {
            TowerStat();
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

        public override void Update()
        {
            base.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public void MakeTower()
        {
            sprite = SpriteContainer.sprite["Tower_Mikael"];
            transform.Scale = new Vector2((float)TileSize / 400, (float)TileSize / 400);
            layerDepth = 0.8f;
            originPositionEnum = OriginPositionEnum.BottomMid;

        }

        public void TowerStat()
        {
            this.speed = 400;
            fireRate = 0.1f;
            damage = 5;
            towerCost = 20;
            range = 2;
            name = "Mikael";
        }

        public override void FireProjectile()
        {
            myProjectile = new TowerProjectile(
                // Mytarget Unit
                myTarget,
                // Texture
                SpriteContainer.sprite["Projectile_CSharp"],
                // Position
                new Vector2(transform.Position.X, transform.Position.Y - ((float)tileSize / 2f)),
                // Scale
                new Vector2(0.5f, 0.5f),
                // Layer Depth
                0.95f,
                // Origin
                OriginPositionEnum.Mid,
                // Speed
                this.speed,
                // Damage
                damage
            );

            Instantiate(myProjectile);


            base.FireProjectile();
            myTarget = null;
        }
    }
}
