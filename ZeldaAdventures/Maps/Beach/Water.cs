using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeldaAdventures.Maps.Beach
{
    public class Water : MapObject
    {
        public Water(Rectangle location) : base(location)
        {
            IsWalkable = false;
        }
    }
}
