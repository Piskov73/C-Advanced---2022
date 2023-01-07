using System;
using System.Text;
using System.Xml.Linq;

namespace Basketball
{
    public class Player
    {
        //name, position, rating, games). 
        public Player(string name, string position, double rating, int games)
        {
            Name = name;
            Position = position;
            Rating = rating;
            Games = games;

        }

        //  •	Name: string
        public string Name { get; set; }
        //•	Position: string
        public string Position { get; set; }
        //•	Rating: double
        public double Rating { get; set; }
        //•	Games: int
        public int Games { get; set; }
        //•	Retired: boolean – false by default
        public bool Retired { get; set; }

        //-Player: {name}
        //--Position: {position}
        //--Rating: {rating}
        //--Games played: { games}
        public override string ToString()
        {
            StringBuilder sb= new StringBuilder();
            sb.AppendLine($"-Player: {this.Name}");
            sb.AppendLine($"--Position: {this.Position}");
            sb.AppendLine($"--Rating: {this.Rating}");
            sb.AppendLine($"--Games played: {this.Games}");
            return sb.ToString().TrimEnd();
        }




    }
}
