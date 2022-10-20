using Sat.Recruitment.Common;
using System;

namespace Sat.Recruitment.Models
{
    public abstract class User
    {
        public User(string name, string email, string address, string phone, UserTypes type, decimal money)
        {
            Name = name;
            Email = email;
            Address = address;
            Phone = phone;
            userType = type;
            this.money = SetMoneyValue(money);
        }

        public abstract decimal SetMoneyValue(decimal money);

        private readonly decimal money;

        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }
        private UserTypes userType;

        public virtual decimal Money{
            get {
                return this.money;
            }
        }

        public UserTypes UserType
        {
            get
            {
                return this.userType;
            }
        }

        public bool SetUserType(string type)
        {
            UserTypes result;
            if (Enum.TryParse(type, out result))
            {
                switch (result)
                {
                    case UserTypes.SuperUser:
                        this.userType = UserTypes.SuperUser;
                        return true;
                    case UserTypes.Premium:
                        this.userType = UserTypes.Premium;
                        return true;
                    default:
                        this.userType = UserTypes.Normal;
                        return true;
                }
            }
            else
            {
                return false;
            }
        }
        
    }
}
