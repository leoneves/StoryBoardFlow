using System;
using Microsoft.Xna.Framework;
using System.IO;

namespace StoryBoardFlow
{
    public abstract class GameScene
    {
        SceneManager sceneManager;
        SceneState sceneState = SceneState.Deactivated;
        bool isLoaded;
        string scene_key;

        public virtual void LoadContent() { }
        public virtual void UnloadContent() { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(GameTime gameTime) { }

        public GameScene(string scene_key)
        {
            this.scene_key = scene_key;
        }

        public SceneManager SceneManager
        {
            get { return sceneManager; }
            internal set { sceneManager = value; }
        }

        public SceneState SceneState
        {
            get { return sceneState; }
            set { sceneState = value; }
        }

        public bool IsLoaded
        {
            get { return isLoaded; }
            set { isLoaded = value; }
        }

        public string SceneKey
        {
            get { return scene_key; }
        }
    }
}