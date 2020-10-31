using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppExceptions
{
    public class WithdrawAmountExceedsBalanceException : Exception
    {
        public WithdrawAmountExceedsBalanceException() : base("yo broke ass is broke, bish")  { }

    }
}
