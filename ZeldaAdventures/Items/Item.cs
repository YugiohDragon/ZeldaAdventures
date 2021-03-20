using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeldaAdventures.Items
{
    public abstract class Item
    {
        public abstract string TextureName { get; set; }

        private Texture2D _texture;

        public virtual void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>(TextureName);
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public void Draw(GameTime gameTime, SpriteBatch, GraphicsDeviceManager graphics)
        {

        }
    }
}
