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

        public override void aplly(Check check)
        {
            if (totalCost <= check.getTotalCost()) {
                check.addPoints(points);
            }
        }
    }
}