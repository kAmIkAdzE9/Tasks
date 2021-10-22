using System;

namespace OOP_Workshop
{
    public class FactorByCategoryOffer: Offer
    {
        Category category;
        int factor;

        public Category GetCategory () {
            return category;
        }

        public int GetFactor() {
            return factor;
        }

        public FactorByCategoryOffer(Category category, int factor)
        {
            this.category = category;
            this.factor = factor;
        }

        protected override void addPoints(Check check) {
            int points = check.getCostByCategory(category);
            check.addPoints(points * (factor - 1));
        }

        protected override bool checkCondition(Check check)
        {
            return check.getCostByCategory(category) != 0;
        }
    }
}