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
    }
}
