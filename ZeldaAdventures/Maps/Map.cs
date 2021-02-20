using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using ZeldaAdventures.Maps;

namespace ZeldaAdventures
{
    public abstract class Map
    {
        public Texture2D _texture;

        public List<Door> Doors = new List<Door>();
        public List<MapObject> Objects = new List<MapObject>();
        public string _textureName;

        public abstract void SetupDoors();
        public abstract void SetupMapObjects();
        public abstract string Id { get; }

        public Map(string textureName)
        {
            _textureName = textureName;
        }

        public void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>(_textureName);
            SetupDoors();
            SetupMapObjects();
            foreach (var mapObject in Objects)
                mapObject.LoadContent(content);
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            spriteBatch.Draw(_texture, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
        }
    }
}
