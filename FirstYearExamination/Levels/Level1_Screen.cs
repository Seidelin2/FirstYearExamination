using FirstYearExamination.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstYearExamination.Levels
{
    class Level1_Screen : GameScreen
    {

        private Texture2D background;
        private string path = "Sprites/TestPixel";


        public Level1_Screen()
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

        }

        public override void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
