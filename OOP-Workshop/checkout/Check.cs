using System;
using System.Collections.Generic;
using System.Collections;

namespace OOP_Workshop
{
    public class Check
    {
        private List<Product> products;
        private int points;
        private int totalCost;

        public Check()
        {
            products = new List<Product>();
            points = 0;
            totalCost = 0;
        }

        public List<Product> getProducts()
        {
            return products;
        }

        public int getTotalCost()
        {
            return totalCost;
        }

        internal void addProduct(Product product)
        {
            products.Add(product);
            addCost(product.GetPrice());
        }

        public int getTotalPoints()
        {
            return getTotalCost() + points;
        }

        internal void addPoints(int points)
        {
            this.points += points;
        }

        internal void addCost(int value)
        {
            totalCost += value;
        }

        public int getCostByCategory(Category category)
        {
            int output = 0;
            foreach (Product product in products)
            {
                if (product.getCategory() == category)
                {
                    output += product.GetPrice();
                }
            }
            return output;
        }

        public int getCount()
        {
            return products.Count;
        }

        public int getCostByProduct(Product product)
        {
            int cost = 0;
            foreach (Product p in products)
            {
                if (product == p)
                {
                    cost += product.GetPrice();
                }
            }
            return cost;
        }

        public int getCostByBrand(string brand)
        {
            int cost = 0;
            foreach (Product p in products)
            {
                if (brand == p.getBrand())
                {
                    cost += p.GetPrice();
                }
            }
            return cost;
        }
    }
}