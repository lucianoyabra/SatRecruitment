using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Models
{
    public class Result
    {
        private bool isSuccess;
        private string message;

        public bool IsSuccess
        {
            get
            {
                return this.isSuccess;
            }
            set
            {
                this.isSuccess = value;
            }

        }

        public string Message
        {
            get
            {
                return this.message;
            }
            set
            {
                this.message = value;
            }

        }
    }
}
