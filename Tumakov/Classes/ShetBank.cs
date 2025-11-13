using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Tumakov.Enums;

namespace Tumakov.Classes
{
    class ShetBank
    {
        private static long Nomer = 1;
        public long NomerInd { get; set; }
        public decimal Balans { get; set; }
        public Bank TypeShet {  get; set; }
        private Queue Transactions = new Queue();
        public ShetBank()
        {
            Balans = 0;
            TypeShet = Bank.Unknown;
            NomerUnik();
        }
        public ShetBank(decimal balans)
        {
            Balans = balans;
            TypeShet= Bank.Unknown;
            NomerUnik();
        }
        public ShetBank(Bank typeshet)
        {
            Balans = 0;
            TypeShet = typeshet;
            NomerUnik();
        }
        public ShetBank(decimal balans, Bank typeshet)
        {
            Balans = balans;
            TypeShet = typeshet;
            NomerUnik();
        }
        public decimal Transfer(ShetBank shet, decimal summa)
        {
            if (summa <= 0)
            {
                Console.WriteLine("Сумма перевода должна быть положительной");
                return Balans;
            }
            if (summa < shet.Balans)
            {
                shet.Get(summa);
                Balans += summa;
                return Balans;
            }
            else
            {
                Console.WriteLine("Недостаточно средств");
                return Balans;
            }

        }
        public decimal Put(decimal deposit)
        {
            BankTransaction trans = new BankTransaction(deposit);
            Transactions.Enqueue(trans);
            Balans += deposit;
            return Balans;
        }
        public decimal Get(decimal take)
        {
            if (take <= 0)
            {
                Console.WriteLine("Сумма должна быть положительной");
                return Balans;
            }
            if (take > Balans)
            {
                Console.WriteLine("Много хочешь, мало имеешь");
                return Balans;
            }
            else
            {
                Balans -= take;
                BankTransaction trans = new BankTransaction(-take);
                Transactions.Enqueue(trans);
                return Balans;
            }
        }
        private long NomerUnik()
        {
            NomerInd = Nomer;
            Nomer++;
            return NomerInd;
        }
        public void Dipose()
        {
            var filename = $"transactions{NomerInd}.txt";
            var way = $"..\\..\\Files\\{filename}";
            using (StreamWriter writer = new StreamWriter(way))
            {
                foreach (BankTransaction trans in Transactions)
                {
                    writer.WriteLine($"{trans.Date} , {trans.Summa}");
                }
            }
            GC.SuppressFinalize(this);
        }
        private void History()
        {
            Console.WriteLine($"Транзакции счета {NomerInd}:");
            if (Transactions.Count == 0)
            {
                Console.WriteLine("Нет транзакций");
            }
            foreach (BankTransaction trans in Transactions)
            {
                if (trans.Summa > 0)
                {
                    Console.WriteLine($"Дата: {trans.Date:HH:mm:ss}. Поплнение {trans.Summa} руб.");
                }
                else
                {
                    Console.WriteLine($"Дата: {trans.Date:HH:mm:ss}. Снятие {trans.Summa} руб.");
                }
            }
        }
        public void Print()
        {
            Console.WriteLine($"Номер счета: {NomerInd}");
            Console.WriteLine($"Баланс: {Balans}");
            Console.WriteLine($"Тип счета: {TypeShet}");
            History();
        }
    }
}
