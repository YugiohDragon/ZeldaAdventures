using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
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

        public override string Id => "HouseMap";
        public override void Setup(ContentManager content)
        {
            Music = content.Load<Song>("house");

            Doors.Add(new Door
            {
                Location = new Rectangle(353, 473, 113, 10),
                DestinationMap = MapDictionary.OutsideHouse,
                DestinationPosition = new Vector2(550, 200)
            });

            Objects.Add(new Bed());
        }

    }
}
