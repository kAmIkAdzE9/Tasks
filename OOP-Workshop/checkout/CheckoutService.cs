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
            offer.aplly(check);
        }
    }
}