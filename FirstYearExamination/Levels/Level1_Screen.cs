using FirstYearExamination.Components;
using FirstYearExamination.Factory;
using FirstYearExamination.Screens;
using FirstYearExamination.SQLite;
using FirstYearExamination.Tower;
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
            New_Tower tmp1 = nicolaiTest(new Vector2(675, 219));
            New_Tower tmp2 = nicolaiTest(new Vector2(220, 480));
            //tmp1.Target = tmp2.GameObject;
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
			base.Update(gameTime);

            HandleInput();
			GameWorld.Instance.SpawnUnit(1, goldUpdater);

			MouseState state = Mouse.GetState();

			if (state.RightButton == ButtonState.Pressed)
			{
				goldUpdater.UpdateGold(10);
			}
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(background, Vector2.Zero, Color.White);

            base.Draw(spriteBatch, gameTime);
        }

		public override void Start()
		{
			base.Start();
			goldUpdater = new GoldUpdater(guiManager.GoldText);
			goldUpdater.ResetGold();
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

        public New_Tower nicolaiTest(Vector2 pos)
        {
            //this is the attack part of the test towers, here the stats of the tower are, and the sprite the tower shoots with
            GameObject go = TowerFactory.Instance.Create(TowerType.Fast_Tower, pos);
            //SpriteRenderer sr = new SpriteRenderer();
            //Fast_Tower tower = new Fast_Tower(1, 500, 1, 40 ,5 , "hello", ProjectileType.Bigmissile);

            //sr.SetSprite("Sprites/Towers/Tower_Holder1");
            //sr.SetOrigin();
            //go.Transform.Position = pos;

            //go.AddComponent(sr);
            //go.AddComponent(tower);

            GameWorld.Instance.AddGameObject(go);

            Fast_Tower tmp = (Fast_Tower)go.GetComponent<Fast_Tower>();
            SpriteRenderer tmp1 = (SpriteRenderer)go.GetComponent<SpriteRenderer>();

            return tmp;
        }
    }
}
