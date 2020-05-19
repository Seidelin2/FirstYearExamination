using FirstYearExamination.Components;
using FirstYearExamination.Gui;
using FirstYearExamination.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstYearExamination.GUI
{
    class Buttons : Game
    {
        //Button Testing
        private Color _backgroundColour = Color.CornflowerBlue;
        private List<Component> _gameComponents;

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            //button testing
            foreach (var component in _gameComponents)
            {
                component.Draw(gameTime, spriteBatch);
            }
        }

        public void LoadContent()
        {
            var randomButton = new GUIButtons(Content.Load<Texture2D>("Sprites/Towers/Tower_Holder1"), Content.Load<SpriteFont>("Fonts /Font"))
            {
                Position = new Vector2(350, 200),
                Text = "Random",
            };

            randomButton.Click += RandomButton_Click;

            var quitButton = new GUIButtons(Content.Load<Texture2D>("Sprites/Towers/Big_Missile"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(350, 250),
                Text = "Quit",
            };

            quitButton.Click += QuitButton_Click;

            _gameComponents = new List<Component>()
            {
                randomButton,
                quitButton,
            };
            
        }

        public  void UnloadContent()
        {
            
        }

        public  void Update(GameTime gameTime)
        {
            //button TEsting
            foreach (var component in _gameComponents)
            {
                component.Update(gameTime);
            }

        }


        //Button Testing
        private void QuitButton_Click(object sender, System.EventArgs e)
        {
            Exit();
        }

        private void RandomButton_Click(object sender, System.EventArgs e)
        {
            var random = new Random();

            _backgroundColour = new Color(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }
    }
}
