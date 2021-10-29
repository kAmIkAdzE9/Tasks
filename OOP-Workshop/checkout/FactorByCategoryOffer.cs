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

        protected override int calculatePoints(Check check) {
            int points = check.getCostByCategory(category);
            return (points * (factor - 1));
        }

        protected override bool checkBonusCondition(Check check)
        {
            return check.getCostByCategory(category) != 0;
        }
    }
}