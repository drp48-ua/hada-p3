using System;
using System.Collections.Generic;

namespace library
{
    public class ENCategory
    {
        private int _id;
        private string _name;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }

        public ENCategory() { }

        public List<ENCategory> readAll()
        {
            CADCategory cad = new CADCategory();
            return cad.readAll();
        }
    }
}