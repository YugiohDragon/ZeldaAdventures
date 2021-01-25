using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeldaAdventures.Maps
{
    public class Door
    {
        public Rectangle Location { get; set; }
        public Map DestinationMap { get; set; }
        public Vector2 DestinationPosition { get; set; }
    }
}
