using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeldaAdventures.Maps.House
{
    class Bed : MapObjectd
    {
        SpriteFont _font;

        public Bed() : base(new Rectangle(700, 10, 40, 60))
        {
        }

        public override void LoadContent(ContentManager content)
        {
            _font = content.Load<SpriteFont>("prompt");
            base.LoadContent(content);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (LinkCollided)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(_font, "in bed", new Vector2(0, 0), Color.Red);
                spriteBatch.End();
            }
        }
    }
}
