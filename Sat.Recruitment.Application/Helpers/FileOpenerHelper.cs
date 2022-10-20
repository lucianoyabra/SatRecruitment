using Sat.Recruitment.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Data.Helpers
{
    public static class FileOpenerHelper
    {
        public static List<string> ReadUsersFromFile(string direc)
        {
            List<string> listUsers = new List<string>();
            using (var reader = new StreamReader(Directory.GetCurrentDirectory() + "/" + direc))
            {
                List<string> listA = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    listUsers.Add(values[0]);
                }
            }
            return listUsers;

        }
        public static async Task<Result> AddUserAsync(string path, string user)
        {
            Result res = new Result();
            res.IsSuccess = true;
            try
            {
                await File.AppendAllTextAsync((Directory.GetCurrentDirectory() + "/" + path), Environment.NewLine + user);
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.Message;
            }
            return res;

        }
    }
}
