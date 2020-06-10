using FirstYearExamination.Levels;
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
    /// <summary>
	/// Lavet af Casper Seidelin
	/// </summary>
    class TitleScreen : GameScreen
    {
        //For Testing Purposes
        private KeyboardState previousKS = Keyboard.GetState();
        private KeyboardState newKS;


        //Variables for handling graphics
        private Texture2D background;
        private string backgroundPath = "Sprites/UI/Slash_Screen_Game";

        public TitleScreen(GameWorld gameWorld) : base(gameWorld)
        {
            
        }

        public override void LoadContent()
        {
            //Set mouse cursor to visible.
            ScreenManager.IsMouseVisible = true;

            base.LoadContent();

            //Background
            background = gameScreenContent.Load<Texture2D>(backgroundPath);
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

            base.Draw(spriteBatch, gameTime);

        }

        /// <summary>
        /// This is just for testing purposes
        /// </summary>
        public void HandleInput()
        {
            newKS = Keyboard.GetState();

            if (newKS.GetPressedKeys().Length != 0 && previousKS.GetPressedKeys().Length == 0)
            {
                ScreenManager.ChangeScreenTo(new Level1_Screen(this.gameWorld));
            }

            previousKS = newKS;
        }
    }
}
