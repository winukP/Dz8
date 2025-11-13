using System;
using System.Collections.Generic;
using Tumakov.Classes;
using Tumakov.Enums;

namespace Tumakov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //9.1
            ShetBank shet1 = new ShetBank(Bank.Tekushet);
            shet1.Print();
            ShetBank shet2 = new ShetBank(100);
            shet2.Print();
            ShetBank shet3 = new ShetBank();
            shet3.Print();
            ShetBank shet4 = new ShetBank(2000, Bank.Sberegshet);
            shet4.Print();
            //9.2
            shet3.Put(500);
            shet3.Get(200);
            shet3.Print();
            //9.3
            shet3.Dipose();
            //dz 9.1
            Song song1 = new Song("I really want to stay at your house", "Rosa Walton");
            Song song2 = new Song("Live on Forever", "The Afters", song1);
            Song song3 = new Song("Я русский", "Шаман");
            Song song4 = new Song("Я русский", "Шаман");
            List<Song> music = new List<Song> { song1, song2, song3, song4 };
            foreach (Song song in music)
            {
                Console.WriteLine($"{song.Name} - {song.Author}, {(song.Prev == null ? "null" : song.Prev.Name)}");
            }
           
        }
    }
}
