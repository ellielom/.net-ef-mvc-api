using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppExceptions
{
    public class WithdrawFromFrozenAccountException : Exception
    {

        public WithdrawFromFrozenAccountException() : base("all your base are belong to us") { }
    }
}
