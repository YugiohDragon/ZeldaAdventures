using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeldaAdventures.Maps.Beach
{
    public class Sword : MapObject
    {
        private Texture2D _texture;

        public Sword(Rectangle location) : base(location)
        {
        }

        public override void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>("Sword");
            base.LoadContent(content);
        }

        public override void OnCollision()
        {
            base.OnCollision();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Location, Color.White);

            base.Draw(gameTime, spriteBatch);
        }
    }
}
