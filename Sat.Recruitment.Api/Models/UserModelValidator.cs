using Sat.Recruitment.Api.Helpers;
using Sat.Recruitment.Common;
using Sat.Recruitment.Common.Constants;
using Sat.Recruitment.Models;

namespace Sat.Recruitment.Api.Models
{
    public static class UserModelValidator
    {
        public static Result IsValidUser(ref UserModel user)
        {

            Result validUserResult = new Result();
            if(user != null) { 
                if (user.Name == null) { 
                    //Validate if Name is null
                    validUserResult.Message = "The name is required";
                    validUserResult.IsSuccess = false;
                }
                if (user.Address == null) { 
                    //Validate if Address is null
                    validUserResult.Message += " The address is required";
                    validUserResult.IsSuccess = false;
                }
                if (user.Phone == null) { 
                    //Validate if Phone is null
                    validUserResult.Message += " The phone is required";
                    validUserResult.IsSuccess = false;
                }
                if (user.Phone == null)
                {
                    //Validate if Phone is null
                    validUserResult.Message += " The phone is required";
                    validUserResult.IsSuccess = false;
                }
                if (user.Email == null)
                {
                    //Validate if Email is null
                    validUserResult.Message += " The email is required";
                    validUserResult.IsSuccess = false;
                }
                else
                {
                    user.Email = EmailNormalizerHelper.NormalizeEmail(user.Email);
                    if(user.Email != Constants.InvalidEmail) { 
                        validUserResult.IsSuccess = true;
                    }
                    else
                    {
                        validUserResult.Message += " The email is invalid";
                        validUserResult.IsSuccess = false;
                    }
                }
            }
            return validUserResult;
        }

    }
}
