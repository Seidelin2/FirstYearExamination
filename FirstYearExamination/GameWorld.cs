using FirstYearExamination.Components;
using FirstYearExamination.Gui;
using FirstYearExamination.GUI;
using FirstYearExamination.ObjectPool;
using FirstYearExamination.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
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
		Unit unit;

        private List<GameObject> gameObjects = new List<GameObject>();
		public List<Collider> Colliders { get; set; } = new List<Collider>();
		public Dictionary<Point, Cell> Cells = new Dictionary<Point, Cell>();

		public static float DeltaTime { get; set; }
		private float unitSpawnTime;
		private float UnitCoolDown = 1;

        public Color backgroundColour = Color.CornflowerBlue;

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
			
            graphics.PreferredBackBufferWidth = (int)ScreenManager.ScreenDimensions.X;
            graphics.PreferredBackBufferHeight = (int)ScreenManager.ScreenDimensions.Y;
			//Change to true for fullScreen mode
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            ScreenManager.Initialize(this);

			for (int i = 0; i < gameObjects.Count; i++)
			{
				gameObjects[i].Awake();
			}

			for (int x = 0; x < 16; x++)
			{
				for(int y = 0; y < 12; y++)
				{
					Cells.Add(new Point(x, y), new Cell(new Point(x, y)));
				}
			}

			UnitPath();

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

			foreach(Cell cell in Cells.Values)
			{
				cell.LoadContent(Content);
			}

			//unit.SetWaypoint(Cells[new Point(0, 1)]);

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

			Collider[] tmpColliders = Colliders.ToArray();

			for (int i = 0; i < tmpColliders.Length; i++)
			{
				for (int j = 0; j < tmpColliders.Length; j++)
				{
					tmpColliders[i].OnCollisionEnter(tmpColliders[j]);
				}
			}

			foreach(Unit unit in units)
			{
				unit.Update(gameTime);
			}

			SpawnUnit();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backgroundColour);

			// TODO: Add your drawing code here
			spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

            ScreenManager.Draw(spriteBatch, gameTime);

            for (int i = 0; i < gameObjects.Count; i++)
			{
				gameObjects[i].Draw(spriteBatch);
			}

			foreach (Cell cell in Cells.Values)
			{
				cell.Draw(spriteBatch);
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

			if (unitSpawnTime >= UnitCoolDown)
			{
				GameObject go = UnitPool.Instance.GetObject();
				AddGameObject(go);
				unit = (Unit)go.GetComponent("Unit");
				unit.SetWaypoint(Cells[new Point(0, 1)]);
				unitSpawnTime = 0;
			}
		}

		private void UnitPath()
		{
			#region Map_01
			Cells[new Point(0, 1)].Neighbour = Cells[new Point(1, 1)];
			Cells[new Point(0, 1)].Neighbour = Cells[new Point(12, 1)];
			Cells[new Point(12, 1)].Neighbour = Cells[new Point(12, 2)];
			Cells[new Point(12, 2)].Neighbour = Cells[new Point(13, 2)];
			Cells[new Point(13, 2)].Neighbour = Cells[new Point(13, 5)];
			Cells[new Point(13, 5)].Neighbour = Cells[new Point(1, 5)];
			Cells[new Point(1, 5)].Neighbour = Cells[new Point(1, 9)];
			Cells[new Point(1, 9)].Neighbour = Cells[new Point(2, 9)];
			Cells[new Point(2, 9)].Neighbour = Cells[new Point(2, 10)];
			Cells[new Point(2, 10)].Neighbour = Cells[new Point(15, 10)];
			#endregion
		}
	}
}
