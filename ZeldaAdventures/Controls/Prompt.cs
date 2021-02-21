using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeldaAdventures.Controls
{
    public class Prompt
    {
        private string _prompt;
        private Button _button1;
        private Button _button2;

        private int _width = 400;
        private int _height = 100;

        private int _x
        {
            get
            {
                return 400 - _width / 2;
            }
        }

        private int _y
        {
            get
            {
                return 240 - _height / 2;
            }
        }

        public Prompt(string prompt, string button1, string button2, Action onButton1Clicked, Action onButton2Clicked)
        {
            _prompt = prompt;
            _button1 = new Button(button1, new Rectangle(_x + 20, _y + 50, 100, 40), Color.Blue, Color.Yellow, onButton1Clicked);
            _button2 = new Button(button2, new Rectangle(_x + _width - 120, _y + 50, 100, 40), Color.Blue, Color.Yellow, onButton2Clicked);
        }

        public void Update(GameTime gameTime, Game game)
        {
            game.IsMouseVisible = true;
            _button1.Update(gameTime);
            _button2.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Game1.State = GameState.Paused;
            spriteBatch.Draw(SharedContent.Blank, new Rectangle(_x, _y, _width, _height), Color.Red);
            spriteBatch.DrawString(SharedContent.Font, _prompt, new Vector2(_x + 20, _y + 10), Color.White);
            _button1.Draw(spriteBatch);
            _button2.Draw(spriteBatch);
        }
    }
}
