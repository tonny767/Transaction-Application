using System;

namespace PT13{
    /// <summary>
    /// Card is a child class of abstract class Inventory, ViewInventoryDetails() is the override.
    /// </summary>
    public class Card:Inventory{
        private int _series;
        private string _rarity;
        private string _colour;
        private Foil _foil;
        public Card(int Series, string Name, string Rarity, string Colour, Foil Foil, int Quantity, double Price):base(Name, Quantity, Price){
            _series = Series;
            _rarity = Rarity;
            _colour = Colour;
            _foil = Foil;
        }
        /// <summary>
        /// printing relevant details about inventory inputted in admin class
        /// </summary>
        public override void ViewInventoryDetails()
        {
            Console.WriteLine("Card Name: {0}\nNumber Series: {1}\nRarity: {2}\nColour: {3}\nCard Status: {4}\nQuantity: {5}\nPrice: RM{6}/Item"
            , base.Name, Series, Rarity, Colour, CardStatus(), base.Quantity, base.Price);
        }
        /// <summary>
        /// Update itself when the card is marked as nonfoil
        /// </summary>
        public string CardStatus(){
            string write;
            if(_foil == Foil.Foil){
                write = "Foil";
            }else{
                write = "Non-Foil";
            }
            return write;
        }
        /// <summary>
        /// All the public get; set;
        /// </summary>
        public int Series{
            get{ return _series; }
            set{ _series = value; }
        }
        public string Colour{
            get{ return _colour; }
            set{ _colour = value; }
        }
        public string Rarity{
            get{ return _rarity; }
            set{ _rarity = value; }
        }
        public Foil Foil{
            get{ return _foil; }
            set{ _foil = value; }
        }
        /// <value>int, string, string, and enum Foil</value>
    }
}