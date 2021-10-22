using System;
using System.Collections.Generic;
using System.Collections;

namespace OOP_Workshop
{
    public class Check
    {
        private List<Product> products;
        private int points;

        public Check()
        {
            products = new List<Product>();
            points = 0;
        }

        public int getTotalCost()
        {
            int totalCost = 0;
            foreach (Product product in this.products)
            {
                totalCost += product.GetPrice();
            }
            return totalCost;
        }

        internal void addProduct(Product product)
        {
            products.Add(product);
        }

        public int getTotalPoints()
        {
            return getTotalCost() + points;
        }

        internal void addPoints(int points)
        {
            this.points += points;
        }

        internal int getCostByCategory(Category category)
        {
            // return products.stream()
            //         .filter(p->p.category == category)
            //         .mapToInt(p->p.price)
            //         .reduce(0, (a, b)->a + b);
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
    }
}