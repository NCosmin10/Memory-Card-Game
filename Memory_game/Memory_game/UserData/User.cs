using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory_game.UserData
{
    public class User
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public int NumberOfGames { get; set; }
        public int NumberOfWonGames { get; set; }
        public User(string Name,string Image)
        {
            this.Name = Name;
            this.Image = Image;
            this.NumberOfGames = 0;
            this.NumberOfWonGames = 0;
        }
        public User()
        {

        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
