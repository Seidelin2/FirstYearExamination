using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstYearExamination.Gui
{
    public class Panel
    {
        public Vector2 Position { get; set; }
        public Vector2 Dimensions { get; set; }
        public Color Color { get; set; }

        private Texture2D texture;

        public void LoadContent(GraphicsDevice device)
        {
            texture = Helper.CreateTexture(device, (int)Dimensions.X, (int)Dimensions.Y, (x) => Color);
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(texture, Position, Color);
        }

    }
}
