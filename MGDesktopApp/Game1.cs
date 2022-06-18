using MGDesktopApp.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MGDesktopApp
{
    internal class Game1 : Game
    {
        private SpriteFont _font;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private List<ISprite> _sprites;

        public Game1() : base()
        {
            Content.RootDirectory = "Content";
            _graphics = new GraphicsDeviceManager(this);
            IsFixedTimeStep = true;
            IsMouseVisible = true;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            // Draw
            _spriteBatch.DrawString(_font, "Hello World", new Vector2(0, 0), Color.Black);

            foreach (var sprite in _sprites)
            {
                sprite.Draw(_spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        protected override void Initialize()
        {
            var myPos = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            var mySpeed = 100f;

            var sprite1 = new Sprite1(myPos, mySpeed);
            var sprite2 = new Sprite1(myPos, mySpeed * 2);
            var sprite3 = new Sprite1(myPos, mySpeed * 3);

            _sprites = new List<ISprite>
            {
                sprite1,
                sprite2,
                sprite3
            };

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _font = Content.Load<SpriteFont>("Consolas16");

            foreach (var sprite in _sprites)
            {
                sprite.SetTexture(Content.Load<Texture2D>("sprite1"));
            }

            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (var sprite in _sprites)
            {
                sprite.Update(gameTime, _graphics);
            }

            base.Update(gameTime);
        }
    }
}