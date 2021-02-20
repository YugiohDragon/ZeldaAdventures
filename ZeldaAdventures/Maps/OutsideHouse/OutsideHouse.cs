using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;
using ZeldaAdventures.Maps.OutsideHouse;

namespace ZeldaAdventures.Maps.OutsideHouse
{
    public class OutsideHouse : Map
    {
        public OutsideHouse() : base("backdrop2")
        {
          
        }

        public override string Id => "OutsideHouse";

        public override void SetupDoors()
        {
            Doors.Add(new Door
            {
                DestinationMap = MapDictionary.HouseMap,
                Location = new Rectangle(550, 200, 20, 20),
                DestinationPosition = new Vector2(353, 473)
            });

            Doors.Add(new Door
            {
                DestinationMap = MapDictionary.HillMap,
                Location = new Rectangle(0, 470, 800, 10),
                DestinationPosition = new Vector2(400, 0)
            });
        }

        public override void SetupMapObjects()
        {
            Objects.Add(new DungeonGuy(new Rectangle(20, 150, 271, 287)));
            
        }
    }
}
