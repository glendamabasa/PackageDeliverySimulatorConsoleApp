using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftUptitudeTest.HelperMethods
{
    public class FileHandler
    {
        public void WriteToFile(string username,string password)
        {
            using (StreamWriter writer = new StreamWriter("Login.txt"))
            {
                writer.WriteLine(username+","+password);
            }
        }

        public UserDetails ReadFromFile()
        {
            UserDetails userDetail = new UserDetails();

            using (StreamReader reader = new StreamReader("Login.txt"))
            {
                string line;
                var userCredentials = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    userCredentials += line;
                }
                var splittedDetails = userCredentials.Split(',');
                userDetail.UserName = splittedDetails[0];
                userDetail.Password = splittedDetails[1];
            }
            return userDetail;
        }
    }
}
