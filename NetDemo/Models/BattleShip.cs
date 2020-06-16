using System;
using System.Collections.Generic;

namespace NetDemo.Models
{
    public partial class BattleShip
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public DateTime TimeValue { get; set; }
        public int? UserId { get; set; }

        public UserData User { get; set; }
    }
}
