using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    internal class Guild
    {
        private List<Player> player;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            player = new List<Player>();
        }

        public List<Player> Player
        {
            get { return player; }
            set { player = value; }
        }
      

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count { get { return player.Count; } }
        public void AddPlayer(Player player)
        {
            if (Count < Capacity)
            {
                this.player.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            var remuvePlayer=this.player.FirstOrDefault(x=>x.Name==name);
            if (remuvePlayer != null)
            {
                player.Remove(remuvePlayer);
                return true;
            }
            return false;
        }
        public void PromotePlayer(string name)
        {
            Player promoterPlayer = this.player.FirstOrDefault(x => x.Name == name);
            if (promoterPlayer != null)
            {
                if(promoterPlayer.Rank!= "Member")
                {
                    promoterPlayer.Rank = "Member";
                }
            }
        }
        public void DemotePlayer(string name)
        {
            Player demoterPlayer = this.player.FirstOrDefault(x => x.Name == name);
            if (demoterPlayer != null)
            {
                if (demoterPlayer.Rank != "Trial")
                {
                    demoterPlayer.Rank = "Trial";
                }
            }
        }
        public Player[] KickPlayersByClass(string clas) 
        {
            Player[] returnRemuvPlayer = this.player.Where(x=>x.Class==clas).ToArray();
            var filterRemuv= this.player.Where(x => x.Class != clas).ToList();
            this.player = filterRemuv;
            return returnRemuvPlayer;
        }
        public string 	Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var item in player)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
