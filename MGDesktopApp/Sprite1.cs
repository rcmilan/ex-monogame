using MGDesktopApp.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MGDesktopApp
{
    internal class Sprite1 : ISprite
    {
        public Vector2 Position;
        public float Speed;
        private SpriteEffects _spriteEffects = SpriteEffects.None;

        private byte currentAnimationIndex;
        private byte previousAnimationIndex;

        private Rectangle[] sourceRectangles;
        private int threshold;
        private float timer;

        public Sprite1(Vector2 position, float speed = 100f)
        {
            this.Position = position;
            this.Speed = speed;
        }

        public Texture2D Texture { get; private set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                Texture,
                Position,
                sourceRectangles[currentAnimationIndex],
                Color.White,
                0f,
                new Vector2(Texture.Width / 2, Texture.Height / 2),
                Vector2.One,
                _spriteEffects,
                0f);
        }

        public void SetTexture(Texture2D texture)
        {
            timer = 0; // Set a default timer value.

            threshold = 250; // Set an initial threshold of 250ms, you can change this to alter the speed of the animation (lower number = faster animation).

            // Three sourceRectangles contain the coordinates of the character's three down-facing sprites on the charaset.
            sourceRectangles = new Rectangle[3];
            sourceRectangles[0] = new Rectangle(0, 128, 48, 64);
            sourceRectangles[1] = new Rectangle(48, 128, 48, 64);
            sourceRectangles[2] = new Rectangle(96, 128, 48, 64);

            // This tells the animation to start on the left-side sprite.
            previousAnimationIndex = 2;
            currentAnimationIndex = 1;

            Texture = texture;
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics, bool limitScreen = true)
        {
            Move(gameTime, graphics, limitScreen);

            ChangeSprite(gameTime);
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            Update(gameTime, graphics, false);
        }

        private void ChangeSprite(GameTime gameTime)
        {
            // Check if the timer has exceeded the threshold.
            if (timer > threshold)
            {
                // If the character is in the middle sprite of the animation.
                if (currentAnimationIndex == 1)
                {
                    // If the previous animation was the left-side sprite, then the next animation should be the right-side sprite.
                    if (previousAnimationIndex == 0)
                    {
                        currentAnimationIndex = 2;
                    }
                    else
                    // If not, then the next animation should be the left-side sprite.
                    {
                        currentAnimationIndex = 0;
                    }
                    // Track the animation.
                    previousAnimationIndex = currentAnimationIndex;
                }
                // If the character was not in the middle sprite of the animation, he should return to the middle sprite.
                else
                {
                    currentAnimationIndex = 1;
                }
                // Reset the timer.
                timer = 0;
            }
            // If the timer has not reached the threshold, then add the milliseconds that have past since the last Update() to the timer.
            else
            {
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
        }

        private void Move(GameTime gameTime, GraphicsDeviceManager graphics, bool limitScreen)
        {
            var kstate = Keyboard.GetState();

            // Move
            if (kstate.IsKeyDown(Keys.Up))
            {
                Position.Y -= Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (kstate.IsKeyDown(Keys.Down))
            {
                Position.Y += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (kstate.IsKeyDown(Keys.Left))
            {
                Position.X -= Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (kstate.IsKeyDown(Keys.Right))
            {
                Position.X += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (limitScreen)
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
}