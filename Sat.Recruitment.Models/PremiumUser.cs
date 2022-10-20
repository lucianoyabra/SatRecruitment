using Sat.Recruitment.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Models
{
    public class PremiumUser : User
    {
        public PremiumUser(string name, string email, string address, string phone, UserTypes type, decimal money) 
            : base(name, email, address, phone, type, money)
        {
        }

        public override decimal SetMoneyValue(decimal money)
        {
            if (money != null)
            {
                if (money > 100)
                {
                    var gif = money * 2;
                    return money + gif;
                }
                return 0;
            }
            else
            {
                return 0;
            }
           
        }
    }
}
