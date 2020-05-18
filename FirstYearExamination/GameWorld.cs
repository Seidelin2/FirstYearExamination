using FirstYearExamination.Builder;
using FirstYearExamination.Components;
using FirstYearExamination.Gui;
using FirstYearExamination.ObjectPool;
using FirstYearExamination.Screens;
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
		public List<Collider> Colliders { get; set; } = new List<Collider>();

		public static float DeltaTime { get; set; }
		private float unitSpawnTime;
		private float UnitCoolDown = 1;

        public GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";


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
			//Sreen Resolutions
            graphics.PreferredBackBufferWidth = (int)ScreenManager.ScreenDimensions.X;
            graphics.PreferredBackBufferHeight = (int)ScreenManager.ScreenDimensions.Y;
			//Change to true for fullScreen mode
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            ScreenManager.Initialize();

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

            ScreenManager.LoadContent(Content);



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
            ScreenManager.UnloadContent();

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
			DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            ScreenManager.Update(gameTime);

            // TODO: Add your update logic here
            for (int i = 0; i < gameObjects.Count; i++)
			{
				gameObjects[i].Update(gameTime);
			}

			SpawnUnit();

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

            ScreenManager.Draw(spriteBatch);

            for (int i = 0; i < gameObjects.Count; i++)
			{
				gameObjects[i].Draw(spriteBatch);
			}



            spriteBatch.End();

			base.Draw(gameTime);
        }



		public void AddGameObject(GameObject go)
		{
			go.Awake();
			go.Start();
			gameObjects.Add(go);

			Collider c = (Collider)go.GetComponent("Collider");

			if (c != null)
			{
				Colliders.Add(c);
			}
		}

		public void RemoveGameObject(GameObject go)
		{
			gameObjects.Remove(go);
		}

		private void SpawnUnit()
		{
			unitSpawnTime += DeltaTime;

			if(unitSpawnTime >= UnitCoolDown)
			{
				GameObject go = UnitPool.Instance.GetObject();
				go.Transform.Position = new Vector2(-64, 64);
				AddGameObject(go);

				unitSpawnTime = 0;
			}
		}
	}
}
