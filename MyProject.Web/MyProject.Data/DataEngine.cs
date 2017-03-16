using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MyProject.Data
{
    public class DataEngine
    {

        #region Account Methods

        #region GetAccount
        public  Account GetAccount(int AccountID)
        {
            Account returnAccount = new Account();

            using (var db = new TestDatabaseEntities())
            {

                List<Account> Accounts = db.Accounts.Where(a => a.AccountID == AccountID).Distinct().ToList();

                foreach (var Account in Accounts)
                {

                    returnAccount.Email = Account.Email;
                    returnAccount.Password_ = Account.Password_;

                }
           
            }

            return returnAccount;

        }
        #endregion

        #region GetAllAccounts
        public List<Account> GetAllAccounts()
        {
            
            using (var db = new TestDatabaseEntities())
            {

                List<Account> Accounts = db.Accounts.Distinct().ToList();


                return Accounts;
            }

        }
        #endregion

        #region AddAccount
        public bool AddAccount(Account NewAccount)
        {
            bool returnState = false;

            using (var db = new TestDatabaseEntities())
            {
                db.Accounts.Add(NewAccount);
                db.SaveChanges();
                returnState = true;
            }

            return returnState;
        }
        #endregion

        #endregion

    }
}
