using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MGDesktopApp
{
    internal class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch sprites;
        private SpriteFont font;

        public Game1() : base()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.IsFixedTimeStep = true;
            this.IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.sprites = new SpriteBatch(this.GraphicsDevice);

            this.font = this.Content.Load<SpriteFont>("Consolas16");


            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.CornflowerBlue);

            this.sprites.Begin();

            // Draw
            this.sprites.DrawString(this.font, "Hello World", new Vector2(0, 0), Color.Black);

            this.sprites.End();

            base.Draw(gameTime);
        }
    }
}
