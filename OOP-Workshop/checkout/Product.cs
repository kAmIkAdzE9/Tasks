using System;

namespace OOP_Workshop
{
    public class Product
    {
        int price;
        string name;

        public int GetPrice() {
            return price;
        }

        public Product(int price, String name)
        {
            this.price = price;
            this.name = name;
        }
    }
}