using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppExceptions
{
    public class WithdrawAmountLessThanOrEqualToZeroException : Exception
    {
        public WithdrawAmountLessThanOrEqualToZeroException() : base("gotta be positive, u dumb dumb")   { }
    }
}
