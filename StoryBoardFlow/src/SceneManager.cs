namespace StoryBoardFlow
{
    using System.Diagnostics;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    
    public class SceneManager : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        Dictionary<string, GameScene> scenes = new Dictionary<string, GameScene>();
        GameScene currentScene;

        public SceneManager(Game game) : base(game)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public void LoadScene(string scene_key)
        {
            GameScene scene = scenes[scene_key];
            scene.LoadContent();
            scene.IsLoaded = true;
            scene.SceneState = SceneState.Active;
            currentScene = scene;
            foreach(KeyValuePair<string, GameScene> item in scenes)
            {
                var item_scene = item.Value as GameScene;
                if (currentScene.SceneKey != item_scene.SceneKey)
                {
                    if (item_scene.IsLoaded) item_scene.UnloadContent();
                    item_scene.SceneState = SceneState.Deactivated;
                    item_scene.IsLoaded = false;
                }
            }
        }

        protected override void LoadContent()
        {
            Debug.WriteLine("LoadContent StoryBoardFlow");
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        /// <summary>
        /// A default SpriteBatch shared by all the scenes. This saves each scenes having to bother creating their own local instance.
        /// </summary>
        public SpriteBatch SpriteBatch
        {
            get { return spriteBatch; }
        }

        public override void Update(GameTime gameTime)
        {
            currentScene.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            currentScene.Draw(gameTime);
        }

        public void AddScene(string scene_key, GameScene scene)
        {
            scene.SceneManager = this;
            scenes.Add(scene_key, scene);
        }

        public GameScene CurrentScene
        {
            get { return currentScene; }
        }
    }
}