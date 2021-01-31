using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeldaAdventures.Maps
{
    public class MapObject
    {
        public bool LinkCollided { get; private set; } = false;
        public bool IsWalkable { get; set; } = true;
        public Rectangle Location;

        public MapObject(Rectangle location)
        {
            Location = location;
        }

        public virtual void LoadContent(ContentManager content)
        {

        }

        public virtual void OnCollision()
        {
            LinkCollided = true;
        }

        public virtual void Update(GameTime gameTime)
        {
            LinkCollided = false;
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
        }
    }
}
