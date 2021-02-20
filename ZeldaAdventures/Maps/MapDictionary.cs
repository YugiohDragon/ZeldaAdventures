using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZeldaAdventures.Maps.Beach;
using ZeldaAdventures.Maps.House;
using ZeldaAdventures.Maps.OutsideHouse;

namespace ZeldaAdventures.Maps
{
    public static class MapDictionary
    {
        public static List<Map> Maps = new List<Map>();
        public static HouseMap HouseMap = new HouseMap();
        public static OutsideHouse.OutsideHouse OutsideHouse = new OutsideHouse.OutsideHouse();
        public static HillMap HillMap = new HillMap();
        public static BeachMap BeachMap = new BeachMap();
        public static void LoadContent(ContentManager content)
        {
            HouseMap.InitMap(content);
            OutsideHouse.InitMap(content);
            HillMap.InitMap(content);
            BeachMap.InitMap(content);
        }
        
        private static void InitMap(this Map map, ContentManager content)
        {
            map.LoadContent(content);
            Maps.Add(map);
        }


        public static Map GetMapById(string id)
        {
            return Maps.FirstOrDefault(m => m.Id == id);
        }
        
    }
}
