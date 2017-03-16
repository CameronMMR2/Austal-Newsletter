using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Data;

namespace MyProject.Business
{
    public class BusinessEngine
    {

        //Instantiate the data layer
        DataEngine dataEngine = new DataEngine();

        #region Account Methods

        #region GetAccount
        /// <summary>
        /// Pass an integer AccountID and return the full Account information in the Account Class
        /// </summary>
        /// <param name="AccountID"></param>
        /// <returns>Account</returns>
        public Account GetAccount(int AccountID)
        {
            Account returnAccount = new Account();

            returnAccount = dataEngine.GetAccount(AccountID);

            return returnAccount;
        }
        #endregion 

        #region GetAccountEmails
        public List<string> GetAccountEmails()
        {
            List<string> AccountEmails = new List<string>();

            List<Account> Accounts = dataEngine.GetAllAccounts();

            foreach (var Account in Accounts) 
            {
                AccountEmails.Add(Account.Email);
            }

            return AccountEmails;
        }
        #endregion

        #region GetAccountPasswords
        public List<string> GetAccountPasswords()
        {
            List<string> AccountPasswords = new List<string>();

            List<Account> Accounts = dataEngine.GetAllAccounts();

            foreach (var Account in Accounts)
            {
                AccountPasswords.Add(Account.Password_);
            }

            return AccountPasswords;
        }
        #endregion

        #region AddAccount
        public bool AddAccount(string Email, string Password, string FirstName, string LastName)
        {
            Account NewAccount = new Account();
            User NewUser = new User();

            NewAccount.Email = Email;
            NewAccount.Password_ = Password;
            NewUser.FirstName = FirstName;
            NewUser.LastName = LastName;
            NewUser.CreationDate = DateTime.Now;

            NewAccount.Users.Add(NewUser);
            
            return dataEngine.AddAccount(NewAccount);

        }
        #endregion

        #endregion


    }
}
