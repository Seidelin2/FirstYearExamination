using FirstYearExamination.Gui;
using FirstYearExamination.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstYearExamination.Levels
{
    class Level1_Screen : GameScreen
    {
        //Used for HandleInput
        private KeyboardState previousKS = Keyboard.GetState();
        private KeyboardState newKS;

        private Texture2D background;
        private string path = "Sprites/Map/Map_1";



        public Level1_Screen()
        {

        }

        public override void LoadContent()
        {
            //Set mouse cursor to visible.
            ScreenManager.IsMouseVisible = true;

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


        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
        }


        /// <summary>
        /// HandleInput is just for testing purposes
        /// To see if we are able to switch between screens
        /// </summary>
        public void HandleInput()
        {
            newKS = Keyboard.GetState();

            if (newKS.GetPressedKeys().Length != 0 && previousKS.GetPressedKeys().Length == 0)
            {
                ScreenManager.ChangeScreenTo(new Level2_Screen());
            }

            previousKS = newKS;
        }

    }
}
