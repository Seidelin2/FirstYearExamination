using FirstYearExamination.Components;
using FirstYearExamination.Gui;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstYearExamination.GUI
{
    public class GUIManager 
    {
        private List<Component> _gameComponents;               

        private readonly GameWorld game;

        public GUIManager(GameWorld game )
        {
            this.game = game;
        }

        public GUIManager()
        {
        }

        public virtual void Awake()
		{

		}

		public virtual void Start()
		{

		}

		public virtual void LoadContent()
		{
            var randomButton = new GUIButtons(game.Content.Load<Texture2D>("Sprites/Towers/Tower_Holder1"), game.Content.Load<SpriteFont>("Fonts /Font"))
            {
                Position = new Vector2(350, 200),
                Text = "Random",
            };

            randomButton.Click += RandomButton_Click;

            var quitButton = new GUIButtons(game.Content.Load<Texture2D>("Sprites/Towers/Big_Missile"), game.Content.Load<SpriteFont>("Fonts/Font"))
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

		public virtual void Update(GameTime gameTime)
		{
            foreach (var component in _gameComponents)
            {
                component.Update(gameTime);
            }
        }

		public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
		{
            foreach (var component in _gameComponents)
            {
                component.Draw(gameTime, spriteBatch);
            }
        }

        private void QuitButton_Click(object sender, System.EventArgs e)
        {
            game.Exit();
        }

        private void RandomButton_Click(object sender, System.EventArgs e)
        {
            var random = new Random();

            game.backgroundColour = new Color(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }
    }
}
