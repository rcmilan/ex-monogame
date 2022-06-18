using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MGDesktopApp
{
    internal class Sprite1
    {
        public Vector2 Position;
        public float Speed;
        public Texture2D Texture;

        public Sprite1(Vector2 position, float speed = 100f)
        {
            this.Position = position;
            this.Speed = speed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                Texture,
                Position,
                null,
                Color.White,
                0f,
                new Vector2(Texture.Width / 2, Texture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f);
        }

        public void Move(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            var kstate = Keyboard.GetState();

            // Move
            if (kstate.IsKeyDown(Keys.Up))
                Position.Y -= Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (kstate.IsKeyDown(Keys.Down))
                Position.Y += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (kstate.IsKeyDown(Keys.Left))
                Position.X -= Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (kstate.IsKeyDown(Keys.Right))
                Position.X += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            LimitMovement(graphics);
        }

        private void LimitMovement(GraphicsDeviceManager graphics)
        {
            if (Position.X > graphics.PreferredBackBufferWidth - Texture.Width / 2)
                Position.X = graphics.PreferredBackBufferWidth - Texture.Width / 2;
            else if (Position.X < Texture.Width / 2)
                Position.X = Texture.Width / 2;

            if (Position.Y > graphics.PreferredBackBufferHeight - Texture.Height / 2)
                Position.Y = graphics.PreferredBackBufferHeight - Texture.Height / 2;
            else if (Position.Y < Texture.Height / 2)
                Position.Y = Texture.Height / 2;
        }
    }
}