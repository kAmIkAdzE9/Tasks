using System;

namespace OOP_Workshop
{
    public class AnyGoodsOffer : Offer
    {
        int totalCost;
        int points;
        
        public AnyGoodsOffer(int totalCost, int points)
        {
            this.totalCost = totalCost;
            this.points = points;
        }

        protected override void addPoints(Check check)
        {
            check.addPoints(points);
        }
    }
}