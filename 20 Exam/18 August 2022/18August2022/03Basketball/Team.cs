using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {

        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            players = new List<Player>();

        }



        private List<Player> players;

        public List<Player> Players
        {
            get { return players; }
            set { players = value; }
        }





        public string Name { get; set; }

        public int OpenPositions { get; set; }

        public char Group { get; set; }

        public int Count { get { return players.Count; } }
     

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return $"Invalid player's information.";
            }
            else if (this.OpenPositions == 0)
            {
                return $"There are no more open positions.";
            }
            else if (player.Rating < 80)
            {
                return $"Invalid player's rating.";
            }
            else
            {
                this.players.Add(player);
                this.OpenPositions--;
                return $"Successfully added {player.Name} to the team. Remaining open positions: {this.OpenPositions}.";
            }
        }

     
        public bool RemovePlayer(string name)
        {
            var targetPlayer = this.Players.FirstOrDefault(x => x.Name == name);
            if (targetPlayer == null)
            {
                return false;
            }
            this.OpenPositions++;
            this.players.Remove(targetPlayer);
            return true;
        }
        //public 	int RemovePlayerByPosition(string position)
        //{
        //    int remuvPosition = 0;

        //    List <Player> filter= this.Players.Where(x=> x.Position != position).ToList();

        //    remuvPosition = this.Count - filter.Count();
        //    this.players = filter;

        //    return remuvPosition;
        //}

        public int RemovePlayerByPosition(string position)
        {
            int countRemovedPlayers = 0;
            while (this.Players.FirstOrDefault(x => x.Position == position) != null)
            {
                var targetPlayer = this.Players.FirstOrDefault(x => x.Position == position);
                this.OpenPositions++;
                this.players.Remove(targetPlayer);
                countRemovedPlayers++;
            }



            return countRemovedPlayers;
        }

        public 	Player RetirePlayer(string name)
        {
            Player retirePlayer = this.Players.FirstOrDefault(p => p.Name == name);
            if (retirePlayer != null)
            {
               retirePlayer.Retired = true;
            }
            return retirePlayer;
           
        }

        public List<Player> AwardPlayers(int games)
        {
            List<Player> list = this.Players.Where(x=> x.Games >= games).ToList();
            return list;
        }

        public string 	Report()
        {
            StringBuilder sb= new StringBuilder();
            sb.AppendLine($"Active players competing for Team {this.Name} from Group {this.Group}:");
            foreach (var item in this.Players.Where(x=>x.Retired==false))
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
