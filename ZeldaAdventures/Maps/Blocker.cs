using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeldaAdventures.Maps
{
    public class Blocker : MapObject
    {
        public Blocker(Rectangle location) : base(location)
        {
            IsWalkable = false;
        }
}
}
