using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using ZeldaAdventures.Controls;

namespace ZeldaAdventures.Maps.OutsideHouse
{
    public class DungeonGuy : MapObject
    {
        public Prompt _prompt;
        bool promptReady = true;
        private Texture2D _texture;

        public DungeonGuy(Rectangle location) : base(location)
        {
         

        }

        public override void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>("wdadad");
            base.LoadContent(content);
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
