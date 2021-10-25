using System;
using System.Collections.Generic;

namespace OOP_Workshop
{
    public class CheckoutService
    {
        private Check check;
        private List<Offer> offers;

        public CheckoutService() {
            offers = new List<Offer>();
        }

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
            foreach(Offer offer in offers) {
                offer.apply(check);
            }
            check = null;
            return closedCheck;
        }

        public void useOffer(Offer offer) {
            offers.Add(offer);
        }
    }
}