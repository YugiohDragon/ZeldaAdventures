﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeldaAdventures.Maps
{
    public class HillMap : Map
    {
        public HillMap(): base("backdrop3")
        {

        }

        public override void SetupDoors()
        {
            Doors.Add(new Door
            {
                Location = new Rectangle(0, 0, 800, 10),
                DestinationMap = MapDictionary.OutsideHouse,
                DestinationPosition = new Vector2(400, 480)
            });

            Doors.Add(new Door
            {
                DestinationMap = MapDictionary.BeachMap,
                Location = new Rectangle(0, 470, 800, 10),
                DestinationPosition = new Vector2(400, 0)
            });
        }

        public override void SetupMapObjects()
        {
            
        }
    }
}
