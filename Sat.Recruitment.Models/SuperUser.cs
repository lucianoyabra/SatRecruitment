using Sat.Recruitment.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Models
{
    public class SuperUser : User
    {
        public SuperUser(string name, string email, string address, string phone, UserTypes type, decimal money) :
             base(name, email, address, phone, type, money)
        {
        }

        public override decimal SetMoneyValue(decimal money)
        {
            if (money != null)
            {
                var percentage = 0.0M;
                if (money > 100)
                {
                    percentage = 0.20M;
                }
                var gif = money * percentage;
                return money + gif;
            }
            else
            {
                return 0;
            }
        }
    }
}
