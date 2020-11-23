using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDAL.Models
{
    public class Category : IEntity<int>
    {
        public int Id { get; set; }

        public string name { get; set; }

        public Category()
        {
        }

        public Category(string name)
        {
            this.name = name;
        }

        public Category(int id, string name) : this(name)
        {
            Id = id;

        }
    }
}
