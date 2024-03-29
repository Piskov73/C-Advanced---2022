﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    internal class Player
    {
        // •Name: string
        //•	Class: string
        //•	Rank: string – "Trial" by default
        //•	Description: string – "n/a" by default
        public Player(string name, string clas)
        {
            Name = name;
            Class = clas;
            Rank = "Trial";
            Description = "n/a";
        }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Rank { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            // Player {Name}: {Class}
            // Rank: { Rank}
            // Description: { Description}
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Player {Name}: {Class}");
            sb.AppendLine($"Rank: {Rank}");
            sb.AppendLine($"Description: {Description}");

            return sb.ToString().Trim();
        }

    }
}
