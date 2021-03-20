using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeldaAdventures.Items
{
    public class Inventory
    {
        public bool InventoryOpen = false;
        private Texture2D _texture;
        private bool _ready = true;
        public List<Item> Items { get; set; }

        public void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>("inventory");
        }

        public void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            var mKeyDown = keyboardState.IsKeyDown(Keys.E);

            if (mKeyDown && _ready)
            {
                InventoryOpen = !InventoryOpen;
                _ready = false;
            }

            if (!mKeyDown)
                _ready = true;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            if (InventoryOpen)
            {
                spriteBatch.Draw(_texture, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            }
        }
    }
}
