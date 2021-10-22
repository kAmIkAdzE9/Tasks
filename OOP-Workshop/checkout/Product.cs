using System;

namespace OOP_Workshop
{
    public class Product
    {
        int price;
        string name;
        Category category;

        public int GetPrice() {
            return price;
        }

        public Category getCategory() {
            return category;
        }

        public Product(int price, String name)
        {
            this.price = price;
            this.name = name;
        }

        public Product(int price, String name, Category category)
        {
            this.price = price;
            this.name = name;
            this.category = category;
        }
    }
}