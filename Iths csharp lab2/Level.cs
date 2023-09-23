using Iths_csharp_lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iths_csharp_lab2
{
    enum Levels
    {
        Gold = 85,
        Silver = 90,
        Bronze = 95,
    }

    internal class Level : Customer
    {
        Levels CustomerLevel { get; set; }

        public Level(string userName, string password)
            : base(userName, password)
        {
            
        }

        public double Gold(double totalPrice)
        {
          
            return totalPrice * ((int)Levels.Gold / 100);
        }
    }

}
