using FirstYearExamination.Builder;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace FirstYearExamination
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {
		#region INSTANCE
		private static GameWorld instance;

		public static GameWorld Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new GameWorld();
				}
				return instance;
			}
		}
		#endregion

		GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

		private List<GameObject> gameObjects = new List<GameObject>();

		//Resolution
		public static Vector2 screenSize;

        public GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

			graphics.PreferredBackBufferWidth = 1024;
			graphics.PreferredBackBufferHeight = 768;
			screenSize = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
		}

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
			// TODO: Add your initialization logic here
			IsMouseVisible = true;

			Director director = new Director(new PlayerBuilder());

			gameObjects.Add(director.Construct());

			for (int i = 0; i < gameObjects.Count; i++)
			{
				gameObjects[i].Awake();
			}

			base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

			for (int i = 0; i < gameObjects.Count; i++)
			{
				gameObjects[i].Start();
			}

			// TODO: use this.Content to load your game content here
		}

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

			// TODO: Add your update logic here
			for (int i = 0; i < gameObjects.Count; i++)
			{
				gameObjects[i].Update(gameTime);
			}

			base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

			// TODO: Add your drawing code here
			spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

			for (int i = 0; i < gameObjects.Count; i++)
			{
				gameObjects[i].Draw(spriteBatch);
			}

			spriteBatch.End();

			base.Draw(gameTime);
        }
    }
}
