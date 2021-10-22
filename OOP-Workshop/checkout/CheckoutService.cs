using System;

namespace OOP_Workshop
{
    public class CheckoutService
    {
        private Check check;

        public void openCheck()
        {
            check = new Check();
        }

        internal void addProduct(Product product)
        {
            if (check == null)
            {
                openCheck();
            }
            check.addProduct(product);
        }

        public Check closeCheck()
        {
            Check closedCheck = check;
            check = null;
            return closedCheck;
        }

        public void useOffer(Offer offer) {
            if (offer is FactorByCategoryOffer) // offer instanceof FactorByCategoryOffer
            {
                FactorByCategoryOffer fbOffer = (FactorByCategoryOffer)offer;
                int points = check.getCostByCategory(fbOffer.GetCategory());
                check.addPoints(points * (fbOffer.GetFactor() - 1));
            }
            else if (offer is AnyGoodsOffer) // offer instanceof AnyGoodsOffer
            {
                AnyGoodsOffer agOffer = (AnyGoodsOffer)offer;
                if (agOffer.totalCost <= check.getTotalCost())
                    check.addPoints(agOffer.points);
            }
        }
    }
}