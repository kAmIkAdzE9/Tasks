using System;

namespace OOP_Workshop
{
    public class Product
    {
        int price;
        string name;
        string brand;
        Category category;

        public int GetPrice() {
            return price;
        }

        public Category getCategory() {
            return category;
        }

        public string getBrand() {
            return brand;
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

        public Product(int price, String name, string brand, Category category)
        {
            this.price = price;
            this.name = name;
            this.category = category;
            this.brand = brand;
        }
    }
}