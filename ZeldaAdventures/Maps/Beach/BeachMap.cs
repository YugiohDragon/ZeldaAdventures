﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

using System.Text;

namespace ZeldaAdventures.Maps.Beach
{
    public class BeachMap : Map
    {
        public BeachMap(): base("backdrop4")
        {

        }

        public override void SetupDoors()
        {
            Doors.Add(new Door
            {
                Location = new Rectangle(350, 0, 100, 10),
                DestinationMap = MapDictionary.HillMap,
                DestinationPosition = new Vector2(300, 480)
            });

        }

        public override void SetupMapObjects()
        {
            
        }
    }
}
