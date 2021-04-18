using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class ReaderRegister
    {
        private List<Reader> allReaders = new List<Reader>();
        public int Count()
        {
            return allReaders.Count;
        }
        public void Add(Reader reader)
        {
            this.allReaders.Add(reader);
        }
        public Reader Get(int index)
        {
            if (index >= 0 && index < allReaders.Count)
            {
                return this.allReaders[index];
            }
            return null;
        }
        public Reader Get(string name)
        {
            foreach (Reader reader in allReaders)
            {
                if (reader.Name == name)
                {
                    return reader;
                }
            }
            return null;
        }
        public bool Contains(string name)
        {
            foreach (Reader reader in allReaders)
            {
                if (reader.Name == name)
                {
                    return true;
                }
            }
            return false;
        }
        public void AddBookCount(Reader reader)
        {
            foreach (Reader r in allReaders)
            {
                if (r.Equals(reader))
                {
                    r.BookCount++;
                }
            }
        }
        public void MinusBookCount(Reader reader)
        {
            foreach (Reader r in allReaders)
            {
                if (r.Equals(reader))
                {
                    r.BookCount--;
                }
            }
        }
    }
}
