using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
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

        public override string Id => "HillMap";

        public override void Setup(ContentManager content)
        {
            Music = content.Load<Song>("field");

            Doors.Add(new Door
            {
                Location = new Rectangle(0, 0, 800, 10),
                DestinationMap = MapDictionary.OutsideHouse,
                DestinationPosition = new Vector2(400, 480)
            });
            
            Doors.Add(new Door
            {
                DestinationMap = MapDictionary.BeachMap,
                Location = new Rectangle(350, 470, 100, 10),
                DestinationPosition = new Vector2(400, 0)
            });

            Objects.Add(new Blocker(new Rectangle(250, 350, 10, 100)));
            Objects.Add(new Blocker(new Rectangle(450, 350, 10, 100)));
        }
    }
}
