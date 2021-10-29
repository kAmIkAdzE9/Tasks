using System;

namespace OOP_Workshop
{
    public class DiscountOffer : Offer
    {
        Product product;
        double coefficient;

        public DiscountOffer(Product product, double coefficient) {
            this.product = product;
            this.coefficient = coefficient;
        }

        protected override int calculateCost(Check check) {
            return -Convert.ToInt32(Convert.ToDouble(check.getCostByProduct(product)) * coefficient);
        }
    }
}