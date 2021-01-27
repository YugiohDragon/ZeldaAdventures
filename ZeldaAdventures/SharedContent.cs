using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeldaAdventures
{
    public class SharedContent
    {
        public static SpriteFont Font { get; private set;}

        public static Texture2D Blank { get; private set; }

        public static void LoadContent(ContentManager content)
        {
            Font = content.Load<SpriteFont>("Prompt");
            Blank = content.Load<Texture2D>("Blank");
        }
    }
}
