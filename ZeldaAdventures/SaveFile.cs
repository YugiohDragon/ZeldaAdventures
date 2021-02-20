using System;
using System.Collections.Generic;
using System.Text;

namespace ZeldaAdventures
{
    public class SaveFile
    {
        public GameState CurrentState { get; set; }
        public string MapId { get; set; }
        public float LinkX { get; set; }
        public float LinkY { get; set; }
    }
}
