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

		public Level1_Screen(GameWorld gameWorld) : base(gameWorld)
        {

        }

		public override void LoadContent()
        {
            //Set mouse cursor to visible.
            ScreenManager.IsMouseVisible = true;

            base.LoadContent();
            background = gameScreenContent.Load<Texture2D>(path);
			GameWorld.Instance.UnitPath(1);
		}

		public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            HandleInput();
			GameWorld.Instance.SpawnUnit(1);
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(background, Vector2.Zero, Color.White);

            base.Draw(spriteBatch, gameTime);
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
                ScreenManager.ChangeScreenTo(new Level2_Screen(this.gameWorld));
            }

            previousKS = newKS;
        }
	}
}
