using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Reader
    {
        public string Name { get; set; }
        public int BookCount { get; set; }

        public Reader(string name)
        {
            Name = name;
            BookCount = 1;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Reader reader = obj as Reader;
            if (reader == null)
            {
                return false;
            }
            return this.Name == reader.Name;
        }
        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
