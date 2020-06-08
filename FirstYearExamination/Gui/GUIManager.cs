using FirstYearExamination.Components;
using FirstYearExamination.Gui;
using FirstYearExamination.Screens;
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

        private readonly GameScreen gameScreen;

		private GUIText gold;

		public GUIText GoldText { get => gold; set => gold = value; }

		public GUIManager(GameScreen gameScreen)
        {
            this.gameScreen = gameScreen;
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
			var waveButton = new GUIButtons(gameScreen.gameScreenContent.Load<Texture2D>("Sprites/UI/UI_Tower"), gameScreen.gameScreenContent.Load<SpriteFont>("Fonts /Font"))
			{
				Position = new Vector2(935, 176),
				Text = "Next Wave",
			};

			waveButton.Click += WaveButton_Click;

			var randomButton = new GUIButtons(gameScreen.gameScreenContent.Load<Texture2D>("Sprites/UI/UI_Tower"), gameScreen.gameScreenContent.Load<SpriteFont>("Fonts /Font"))
            {
                Position = new Vector2(935, 96),
                Text = "Random",
            };

            randomButton.Click += RandomButton_Click;

            var quitButton = new GUIButtons(gameScreen.gameScreenContent.Load<Texture2D>("Sprites/UI/UI_Quit"), gameScreen.gameScreenContent.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(935, 256),
                Text = "Quit",
            };

			GoldText = new GUIText(gameScreen.gameScreenContent.Load<SpriteFont>("Fonts/Font"))
			{
				Position = new Vector2(0, 650),
				Text = "Gold: X",
			};

            quitButton.Click += QuitButton_Click;

            _gameComponents = new List<Component>()
            {
                randomButton,
                quitButton,
				waveButton,
				GoldText,
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
            gameScreen.gameWorld.Exit();
        }

        private void RandomButton_Click(object sender, System.EventArgs e)
        {
            var random = new Random();

            gameScreen.gameWorld.backgroundColour = new Color(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }

		private void WaveButton_Click(object sender, EventArgs e)
		{
			gameScreen.gameWorld.waveController.NextWave();
		}
	}
}
