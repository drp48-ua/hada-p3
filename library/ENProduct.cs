using System;

namespace library
{
    public class ENProduct
    {
        private string _code;
        private string _name;
        private int _amount;
        private float _price;
        private int _category;
        private DateTime _creationDate;

        public string Code { get => _code; set => _code = value; }
        public string Name { get => _name; set => _name = value; }
        public int Amount { get => _amount; set => _amount = value; }
        public float Price { get => _price; set => _price = value; }
        public int Category { get => _category; set => _category = value; }
        public DateTime CreationDate { get => _creationDate; set => _creationDate = value; }

        public ENProduct() { }

        public ENProduct(string code, string name, int amount, float price, int category, DateTime creationDate)
        {
            this.Code = code;
            this.Name = name;
            this.Amount = amount;
            this.Price = price;
            this.Category = category;
            this.CreationDate = creationDate;
        }

        public bool create()
        {
            CADProduct cad = new CADProduct();
            return cad.create(this);
        }

        public bool update()
        {
            CADProduct cad = new CADProduct();
            return cad.update(this);
        }

        public bool delete()
        {
            CADProduct cad = new CADProduct();
            return cad.delete(this);
        }

        public bool read()
        {
            CADProduct cad = new CADProduct();
            return cad.read(this);
        }

       
    }
}