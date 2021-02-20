using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeldaAdventures.Maps
{
    public class WorldMap
    {
        public bool MapOpen = false;
        private Texture2D _texture;
        private bool _ready = true;

        public void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>("map");
        }

        public void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            var mKeyDown = keyboardState.IsKeyDown(Keys.M);

            if (mKeyDown && _ready)
            {
                MapOpen = !MapOpen;
                _ready = false;
            }

            if (!mKeyDown)
                _ready = true;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            if(MapOpen)
            {
                spriteBatch.Draw(_texture, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            }
        }
    }
}
