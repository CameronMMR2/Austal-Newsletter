using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MyProject.Data
{
    public static class DataEngine
    {
        public static Account GetAccount(int AccountID)
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



    }
}
