using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ZeldaAdventures.Controls
{
    public class Button
    {
        public string _buttonText;
        public Rectangle _rectangle;
        public Action _onClick;
        public Color _buttonColor;
        public Color _textColor;
        private bool _clickStarted = false;

        public Button(string buttonText, Rectangle rectangle, Color buttonColor, Color textColor, Action onClick)
        {
            _buttonText = buttonText;
            _rectangle = rectangle;
            _buttonColor = buttonColor;
            _textColor = textColor;
            _onClick = onClick;
        }

        public void Update(GameTime gameTime)
        {
            var mouseState = Mouse.GetState();
            var mousePosition = new Vector2(mouseState.X, mouseState.Y);
            if(mouseState.LeftButton == ButtonState.Pressed && _rectangle.Contains(mousePosition))
            {
                _clickStarted = true;
            }
            if(_clickStarted && mouseState.LeftButton == ButtonState.Released)
            {
                if (_rectangle.Contains(mousePosition))
                {
                    _onClick();
                    
                }
                _clickStarted = false;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(SharedContent.Blank, _rectangle, _buttonColor);
            var textSize = SharedContent.Font.MeasureString(_buttonText);
            var textMiddlePoint = new Vector2(textSize.X / 2, textSize.Y / 2);
            var rectangleMiddlePoint = new Vector2(_rectangle.X + (_rectangle.Width / 2), _rectangle.Y + (_rectangle.Height / 2));
            var textPosition = new Vector2((int)(rectangleMiddlePoint.X - (textSize.X / 2)), (int)(rectangleMiddlePoint.Y - (textSize.Y / 2)));
            spriteBatch.DrawString(SharedContent.Font, _buttonText, textPosition, _textColor);
        }
    }
}
