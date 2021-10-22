using System;
using System.Collections.Generic;
using System.Collections;

namespace OOP_Workshop
{
    public class Check
    {
        private List<Product> products;

        public Check() {
            products = new List<Product>();
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

        public int getTotalPoints() {
            return getTotalCost();
        } 
    }
}