using System;
using System.Collections.Generic;

namespace PT13{
    /// <summary>
    /// Abstract Parent class Inventory, have child class of Card and abstract void of ViewInventoryDetails
    /// </summary>
    public abstract class Inventory{
        private string _name;
        private int _quantity;
        private double _price;
        public Inventory(string Name, int Quantity, double Price){
            _name = Name;
            _quantity = Quantity;
            _price = Price;
        }
        public abstract void ViewInventoryDetails();
        public string Name{
            get { return _name; }
            set { _name = value; }
        }
        public int Quantity{
            get { return _quantity; }
            set { _quantity = value; }
        }
        public double Price{
            get { return _price; }
            set { _price = value; }
        }
    }
}