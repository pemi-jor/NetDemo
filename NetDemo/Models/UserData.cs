using System;
using System.Collections.Generic;

namespace NetDemo.Models
{
    public partial class UserData
    {
        public UserData()
        {
            BattleShip = new HashSet<BattleShip>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public ICollection<BattleShip> BattleShip { get; set; }
    }
}
