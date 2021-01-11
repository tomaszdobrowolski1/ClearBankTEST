using ClearBank.Data.Core;
using ClearBank.Data.Models;
using ClearBank.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClearBank.Services.Core
{
    // moq doesnt allow mocking static method hence wrapping logic in normal class and will mock this
    public class AccountFactory
    {
        public virtual Account Get(MakePaymentRequest request)
        {
            var dataStoreType = Config.DataStoreType;
            Account account = null;
            if (dataStoreType == "Backup")
            {
                var accountDataStore = new BackupAccountDataStore();
                account = accountDataStore.GetAccount(request.DebtorAccountNumber);
            }
            else
            {
                var accountDataStore = new AccountDataStore();
                account = accountDataStore.GetAccount(request.DebtorAccountNumber);
            }
            return account;
        }
    }
}
