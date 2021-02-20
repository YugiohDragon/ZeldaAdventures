using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
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

        public override string Id => "BeachMap";

        public override void Setup(ContentManager content)
        {
            Music = content.Load<Song>("field");

            Doors.Add(new Door
            {
                Location = new Rectangle(350, 0, 100, 10),
                DestinationMap = MapDictionary.HillMap,
                DestinationPosition = new Vector2(300, 480)
            });

            Objects.Add(new Sword(new Rectangle(20, 150, 51, 75)));
            Objects.Add(new Water(new Rectangle(0, 0, 150, 75)));
            Objects.Add(new Water(new Rectangle(0, 227, 200, 500)));
        }
    }
}
    
