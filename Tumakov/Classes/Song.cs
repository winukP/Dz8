using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov.Classes
{
    class Song
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public Song Prev { get; set; }
        public Song()
        {
            Name = "Неизвестно";
            Author = "Неизвестно";
            Prev = null;
        }
        public Song(string name, string author)
        {
            Name = name;
            Author = author;
            Prev = null;
        }
        public Song(string name, string author, Song prev)
        {
            Name = name;
            Author = author;
            Prev = prev;
        }
        public override bool Equals(object obj)
        {
            if (obj is Song other)
            {
                return Name == other.Name && Author == other.Author;
            }
            return false;
        }
    }
}
