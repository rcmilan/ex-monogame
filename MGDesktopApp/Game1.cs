using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MGDesktopApp
{
    internal class Game1 : Game
    {
        private SpriteFont _font;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Vector2 myPos;
        private float mySpeed;
        private Texture2D myTexture;

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
                myTexture,
                myPos,
                null,
                Color.White,
                0f,
                new Vector2(myTexture.Width / 2, myTexture.Height / 2),
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
            myTexture = Content.Load<Texture2D>("sprite1");

            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up))
                myPos.Y -= mySpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Down))
                myPos.Y += mySpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Left))
                myPos.X -= mySpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Right))
                myPos.X += mySpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (myPos.X > _graphics.PreferredBackBufferWidth - myTexture.Width / 2)
                myPos.X = _graphics.PreferredBackBufferWidth - myTexture.Width / 2;
            else if (myPos.X < myTexture.Width / 2)
                myPos.X = myTexture.Width / 2;

            if (myPos.Y > _graphics.PreferredBackBufferHeight - myTexture.Height / 2)
                myPos.Y = _graphics.PreferredBackBufferHeight - myTexture.Height / 2;
            else if (myPos.Y < myTexture.Height / 2)
                myPos.Y = myTexture.Height / 2;

            base.Update(gameTime);
        }
    }
}