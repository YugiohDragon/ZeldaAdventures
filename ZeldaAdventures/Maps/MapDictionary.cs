using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;
using ZeldaAdventures.Maps.House;

namespace ZeldaAdventures.Maps
{
    public static class MapDictionary
    {
        public static HouseMap HouseMap = new HouseMap();
        public static OutsideHouse OutsideHouse = new OutsideHouse();
        public static HillMap HillMap = new HillMap();

        public static void LoadContent(ContentManager content)
        {
            HouseMap.LoadContent(content);
            OutsideHouse.LoadContent(content);
            HillMap.LoadContent(content);
        }
    }
}
