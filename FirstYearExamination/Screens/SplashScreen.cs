using FirstYearExamination.Components;
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
            New_Tower tmp1= nicolaiTest(new Vector2(100,100));
            New_Tower tmp2= nicolaiTest(new Vector2(300,300));
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
            GameObject go = new GameObject();
            SpriteRenderer sr = new SpriteRenderer();
            New_Tower tower = new New_Tower(1, 500, 1, 40 ,5 , "hello", ProjectileType.Bigmissile);

            sr.SetSprite("Sprites/Towers/Tower_Holder1");
            sr.SetOrigin();
            go.Transform.Position = pos;

            go.AddComponent(sr);
            go.AddComponent(tower);

            GameWorld.Instance.AddGameObject(go);
            return tower;
        }
    }
}
