using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using FirstYearExamination.Screens;
using FirstYearExamination.Levels;

namespace FirstYearExamination
{
    static class ScreenManager
    {
        //ContentManager for handling all content in the game.
        private static ContentManager contentManager;

        //Dimensions of the game window (Width, height).
        private static Vector2 screenDimensions = new Vector2(1024, 768);

        //The GameScreen that is currently being displayed.
        public static GameScreen CurrentScreen { get; private set; }

        //Varable for holding any screen that needs to be cached.
        public static GameScreen CachedScreen { get; private set; }

        ///Toogles the mouse cursor visible or invisible, based on what the current screen calls for.
        ///Any screen that needs the mouse cursor must set this variable to true in its own LoadContent() method.
        public static bool IsMouseVisible = false;

        public static ContentManager ContentManager { get => contentManager; private set => contentManager = value; }
        public static Vector2 ScreenDimensions { get => screenDimensions; private set => screenDimensions = value; }

        /// <summary>
        /// Sets initial screen parameters when game starts.
        /// </summary>
        public static void Initialize(GameWorld gameWorld)
        {
            CurrentScreen = new Level1_Screen(gameWorld);
        }

        /// <summary>
        /// Changes screens in the game. Unloads old content and loads new content.
        /// </summary>
        /// <param name="newScreen">The screen to be changed to.</param>
        public static void ChangeScreenTo(GameScreen newScreen)
        {
            IsMouseVisible = false;
            CurrentScreen.UnloadContent();
            CurrentScreen = newScreen;
            CurrentScreen.LoadContent();
        }

        /// <summary>
        /// Loads content required by the current game screen.
        /// </summary>
        /// <param name="contentManager"></param>
        public static void LoadContent(ContentManager contentManager)
        {
            ContentManager = new ContentManager(contentManager.ServiceProvider, "Content");
            CurrentScreen.LoadContent();
        }

        /// <summary>
        /// Unloads content no longer needed by the game whenever current screen changes.
        /// </summary>
        public static void UnloadContent()
        {
            CurrentScreen.UnloadContent();
            contentManager.Unload();
        }

        /// <summary>
        /// Updates game elements on the screen.
        /// </summary>
        /// <param name="gameTime"></param>
        public static void Update(GameTime gameTime)
        {
            CurrentScreen.Update(gameTime);
        }

        /// <summary>
        /// Draws the screen.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public static void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            CurrentScreen.Draw(spriteBatch, gameTime);
        }

        /// <summary>
        /// Saves the current screen, so that it can be changed back to if necessary.
        /// </summary>
        public static void CacheCurrentScreen()
        {
            CachedScreen = CurrentScreen;
        }

        /// <summary>
        /// Loads the cached screen and makes it active.
        /// </summary>
        public static void LoadCachedScreen()
        {
            ChangeScreenTo(CachedScreen);
            CachedScreen = null;
        }
    }
}
