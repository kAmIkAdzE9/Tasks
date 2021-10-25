namespace OOP_Workshop
{
    public class BrandOffer: Offer
    {
        string brand;

        public BrandOffer(string brand) {
            this.brand = brand;
        }
        protected override int calculatePoints(Check check) {
            int points = check.getCostByBrand(brand);
            return points;
        }

        protected override bool checkCondition(Check check)
        {
            return check.getCostByBrand(brand) != 0;
        }
    }
}