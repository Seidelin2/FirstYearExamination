using FirstYearExamination.Gui;
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
        private string path = "Sprites/Map/Map_1";

        Texture2D texture;
        List<Panel> Panels;


        public Level1_Screen()
        {
            Panels = new List<Panel>();
            PanelDrawing();
        }

        public void LoadContent(GraphicsDevice device)
        {
            //Set mouse cursor to visible.
            ScreenManager.IsMouseVisible = true;

            texture = Helper.CreateTexture(device, 100, 100, (x) => Color.Black);

            base.LoadContent();
            background = gameScreenContent.Load<Texture2D>(path);

            foreach (var panel in Panels)
            {
                panel.LoadContent(device);
            }
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

            foreach (var panel in Panels)
            {
                panel.Draw(spriteBatch);
            }

            spriteBatch.Draw(background, Vector2.Zero, Color.White);
        }

        public void PanelDrawing()
        {
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    // outer panels
                    var panel1 = new Panel()
                    {
                        //Size of the Panels
                        Dimensions = new Vector2(64, 64),
                        Position = new Vector2(10 + j * 72, 10 + i * 72),
                        Color = Color.Black,
                    };

                    Panels.Add(panel1);
                }
            }
        }
    }
}
