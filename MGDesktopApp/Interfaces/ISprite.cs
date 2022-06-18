using Microsoft.Xna.Framework.Graphics;

namespace MGDesktopApp.Interfaces
{
    internal interface ISprite : IDrawable, IUpdatable
    {
        void SetTexture(Texture2D texture);
    }
}