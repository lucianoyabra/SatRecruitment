using Sat.Recruitment.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Models
{
    public class NormalUser : User
    {
        public NormalUser(string name, string email, string address, string phone, UserTypes type, decimal money) :
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
                    percentage = 0.12M;
                }
                if (money < 100)
                {
                    if (money > 10)
                    {
                        percentage = 0.8M;

                    }
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
