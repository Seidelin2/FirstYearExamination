using FirstYearExamination.Components;
using FirstYearExamination.Factory;
using FirstYearExamination.Tower;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstYearExamination.Screens
{
    class SplashScreen : GameScreen
    {
        private KeyboardState previousKS = Keyboard.GetState();
        private KeyboardState newKS;

        //Variables for handling graphics
        private Texture2D background;
        private string path = "Sprites/TestPixel";

        /// <summary>
        /// Default contructor.
        /// </summary>
        public SplashScreen(GameWorld gameWorld) : base(gameWorld)
        {
            //tmp tower location, to test if the towers would work, these are just 2 tower placements
            New_Tower tmp1 = nicolaiTest(new Vector2(200, 100));
            New_Tower tmp2 = nicolaiTest(new Vector2(300, 400));
            tmp1.Target = tmp2.GameObject;
            //tmp2.Target = tmp1.GameObject;
        }

        public override void LoadContent()
        {
            base.LoadContent();
            background = gameScreenContent.Load<Texture2D>(path);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            HandleInput();
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
        }

        public void HandleInput()
        {
            newKS = Keyboard.GetState();

            if (newKS.GetPressedKeys().Length != 0 && previousKS.GetPressedKeys().Length == 0)
            {
                ScreenManager.ChangeScreenTo(new TitleScreen(this.gameWorld));
            }

            previousKS = newKS;
        }

        public New_Tower nicolaiTest(Vector2 pos)
        {
            //this is the attack part of the test towers, here the stats of the tower are, and the sprite the tower shoots with
            GameObject go = TowerFactory.Instance.Create(TowerType.Fast_Tower, pos);
            //SpriteRenderer sr = new SpriteRenderer();
            //Fast_Tower tower = new Fast_Tower(1, 500, 1, 40 ,5 , "hello", ProjectileType.Bigmissile);

            //sr.SetSprite("Sprites/Towers/Tower_Holder1");
            //sr.SetOrigin();
            //go.Transform.Position = pos;

            //go.AddComponent(sr);
            //go.AddComponent(tower);

            GameWorld.Instance.AddGameObject(go);

            Fast_Tower tmp = (Fast_Tower)go.GetComponent<Fast_Tower>();
            SpriteRenderer tmp1 = (SpriteRenderer)go.GetComponent<SpriteRenderer>();

            return tmp;
        }

        //public void PlaceTower()
        //{
        //    //TODO Get cell position 
        //    Vector2 cellpostition;

        //    GameObject go = TowerFactory.Instance.Create(TowerType.Fast_Tower, cellpostition);

        //    GameWorld.Instance.AddGameObject(go);
        //}
    }
}
