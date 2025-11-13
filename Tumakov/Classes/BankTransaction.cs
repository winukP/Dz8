using System;

namespace Tumakov.Classes
{
    class BankTransaction
    {
        public readonly DateTime Date;
        public readonly decimal Summa;
        public BankTransaction(decimal summa)
        {
            Summa = summa;
            Date = DateTime.Now;
        }
    }
}
