using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MGDesktopApp
{
    internal class Game1 : Game
    {
        private SpriteFont _font;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D mytexture;
        private Vector2 myPos;
        private float mySpeed;

        public Game1() : base()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsFixedTimeStep = true;
            IsMouseVisible = true;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            // Draw
            _spriteBatch.DrawString(_font, "Hello World", new Vector2(0, 0), Color.Black);

            _spriteBatch.Draw(
                mytexture,
                myPos,
                null,
                Color.White,
                0f,
                new Vector2(mytexture.Width / 2, mytexture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        protected override void Initialize()
        {
            myPos = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            mySpeed = 100f;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _font = Content.Load<SpriteFont>("Consolas16");
            mytexture = Content.Load<Texture2D>("sprite1");

            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }
    }
}