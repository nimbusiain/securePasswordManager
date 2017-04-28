using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CredentialManagement;

namespace securePasswoedTest
{
    class Program
    {
        //private const string PasswordName = "ServerPassword";
        //private readonly string _foo;

        static void Main(string[] args)
        {
            //Create new instance
            var passwordStore = new PasswordRepository();

            //Check if password exists
            string currentPassword;
            currentPassword = passwordStore.GetPassword();

            //Check if password null
            if (currentPassword != "")
            {
                Console.WriteLine("Password: Exists: ");
                Console.WriteLine(currentPassword);
                //Console.WriteLine(currentPassword.GetType() == typeof(string));
                Console.ReadLine();
            }
            else
            {
                string myPassword;
                Console.WriteLine("Enter password:");
                myPassword = Console.ReadLine();
                Console.WriteLine("Your password:" + myPassword);
                Console.ReadLine();
                passwordStore.SavePassword(myPassword);
            }

        }

        public class PasswordRepository
        {
            private const string PasswordName = "NimbusAppPassword";

            public void SavePassword(string password)
            {
                using (var cred = new Credential())
                {
                    cred.Password = password;
                    cred.Target = PasswordName;
                    cred.Type = CredentialType.Generic;
                    cred.PersistanceType = PersistanceType.LocalComputer;
                    cred.Save();
                }
            }

            public string GetPassword()
            {
                using (var cred = new Credential())
                {
                    cred.Target = PasswordName;
                    cred.Load();
                    //string tempPassword;
                    //tempPassword = cred.ToString();
                    return cred.Password;
                    //return tempPassword;
                }
            }
        }

    }
}
