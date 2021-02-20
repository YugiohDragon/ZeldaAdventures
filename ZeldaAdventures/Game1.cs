using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using ZeldaAdventures.Controls;
using ZeldaAdventures.Maps;

namespace ZeldaAdventures
{
    public class Game1 : Game
    {
        public static GameState State = GameState.Running;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _link;
        private Map _map;
        private Vector2 _linkPosition = new Vector2(300, 300);
        private float _linkSpeed = 5;
        private bool _doorReady = true;
        private TimeSpan? _lastTimeSaved = null;
        private int _saveDelayMs = 1000;
        private WorldMap _worldMap = new WorldMap();

        private Rectangle _linkRectangle
        {
            get
            {
                return new Rectangle((int)_linkPosition.X, (int)_linkPosition.Y, _link.Width * 2, _link.Height * 2);
            }
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _link = Content.Load<Texture2D>("Link");
            MapDictionary.LoadContent(Content);
            _map = MapDictionary.HouseMap;
            SharedContent.LoadContent(Content);
            _worldMap.LoadContent(Content);
            LoadGame();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if(_lastTimeSaved == null
                || _lastTimeSaved.Value.Add(TimeSpan.FromMilliseconds(_saveDelayMs)) < gameTime.TotalGameTime)
            {
                _lastTimeSaved = gameTime.ElapsedGameTime;
                SaveGame();
            }
            
            var previousX = _linkPosition.X;
            var previousY = _linkPosition.Y;

            if (State == GameState.Running)
            {
                var keyboardState = Keyboard.GetState();

                if (!_worldMap.MapOpen)
                {
                    if (keyboardState.IsKeyDown(Keys.D))
                        _linkPosition.X += _linkSpeed;

                    if (keyboardState.IsKeyDown(Keys.A))
                        _linkPosition.X -= _linkSpeed;

                    if (keyboardState.IsKeyDown(Keys.S))
                        _linkPosition.Y += _linkSpeed;

                    if (keyboardState.IsKeyDown(Keys.W))
                        _linkPosition.Y -= _linkSpeed;
                }

                _worldMap.Update(gameTime, keyboardState);

            }

            if (_linkPosition.Y + _link.Height > _graphics.PreferredBackBufferHeight)
                _linkPosition.Y = _graphics.PreferredBackBufferHeight - _link.Height;

            if (_linkPosition.X + _link.Width > _graphics.PreferredBackBufferWidth)
                _linkPosition.X = _graphics.PreferredBackBufferWidth - _link.Width;

            if (_linkPosition.X < 0)
                _linkPosition.X = 0;

            if (_linkPosition.Y < 0)
                _linkPosition.Y = 0;

            if (_doorReady)
            {
                foreach (var door in _map.Doors)
                {
                    if (door.Location.Intersects(_linkRectangle))
                    {
                        _map = door.DestinationMap;
                        _linkPosition = door.DestinationPosition;
                        _doorReady = false;
                        break;
                    }
                }
            }
            else
            {
                if (_map.Doors.All(d => !d.Location.Intersects(_linkRectangle)))
                    _doorReady = true;
            }


            foreach (var mapObject in _map.Objects)
            {
                mapObject.Update(gameTime);
                if (mapObject.Location.Intersects(_linkRectangle))
                {
                    mapObject.OnCollision();
                    if(!mapObject.IsWalkable)
                    {
                        _linkPosition.X = previousX;
                        _linkPosition.Y = previousY;
                    }
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _map.Draw(gameTime, _spriteBatch, _graphics);
            _spriteBatch.Draw(_link, _linkRectangle,  Color.White);
            foreach (var mapObject in _map.Objects)
                mapObject.Draw(gameTime, _spriteBatch);
            _worldMap.Draw(gameTime, _spriteBatch, _graphics);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        private void SaveGame()
        {
            var savefile = new SaveFile()
            {
                MapId = _map.Id,
                CurrentState = State,
                LinkX = _linkPosition.X,
                LinkY = _linkPosition.Y
            };

            File.WriteAllText("game.txt", JsonConvert.SerializeObject(savefile));
        }

        private void LoadGame()
        {
            if(File.Exists("game.txt"))
            {
                var savefile = JsonConvert.DeserializeObject<SaveFile>(File.ReadAllText("game.txt"));
                _map = MapDictionary.GetMapById(savefile.MapId);
                _linkPosition.X = savefile.LinkX;
                _linkPosition.Y = savefile.LinkY;
                State = savefile.CurrentState;
            }
        }
    }
}
