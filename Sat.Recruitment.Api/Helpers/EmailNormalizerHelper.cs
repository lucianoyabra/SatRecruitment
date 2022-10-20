using Sat.Recruitment.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Helpers
{
    public static class EmailNormalizerHelper
    {
        public static string NormalizeEmail(string email) {

            try
            {
                //Normalize email
                var aux = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
                if (aux.Length > 1) { 
                    var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

                    aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

                    return string.Join("@", new string[] { aux[0], aux[1] });
                }
                else
                {
                    return Constants.InvalidEmail;
                }
            }
            catch (Exception)
            {

                throw;
            }
            

        }
    }
}
