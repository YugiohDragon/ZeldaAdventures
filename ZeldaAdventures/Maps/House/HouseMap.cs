using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeldaAdventures.Maps.House
{
    public class HouseMap : Map
    {
        public HouseMap() : base("backdrop1")
        {
           
        }

        public override void SetupDoors()
        {
            Doors.Add(new Door
            {
                Location = new Rectangle(353, 473, 113, 10),
                DestinationMap = MapDictionary.OutsideHouse,
                DestinationPosition = new Vector2(550, 200)
            });
        }

        public override void SetupMapObjects()
        {
            Objects.Add(new Bed());
        }
    }
}
