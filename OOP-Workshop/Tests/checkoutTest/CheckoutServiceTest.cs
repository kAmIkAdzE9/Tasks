using Xunit;
using System;

namespace OOP_Workshop
{
    public class CheckoutServiceTest
    {
        [Fact]
        void closeCheck_withOneProduct()
        {
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.openCheck();

            checkoutService.addProduct(new Product(7, "Milk", Category.MILK));
            Check check = checkoutService.closeCheck();

            Assert.Equal(check.getTotalCost(), 7);
        }

        [Fact]
        void closeCheck_withTwoProduct()
        {
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.openCheck();

            checkoutService.addProduct(new Product(7, "Milk", Category.MILK));
            checkoutService.addProduct(new Product(3, "Bred", Category.Bred));
            Check check = checkoutService.closeCheck();

            Assert.Equal(check.getTotalCost(), 10);
        }

        [Fact]
        void addProduct__whenCheckIsClosed__opensNewCheck()
        {
            CheckoutService checkoutService = new CheckoutService();

            checkoutService.addProduct(new Product(7, "Milk", Category.MILK));
            Check milkCheck = checkoutService.closeCheck();
            Assert.Equal(milkCheck.getTotalCost(), 7);

            checkoutService.addProduct(new Product(3, "Bred", Category.Bred));
            Check bredCheck = checkoutService.closeCheck();
            Assert.Equal(bredCheck.getTotalCost(), 3);
        }

        [Fact]
        void closeCheck__calcTotalPoints()
        {
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.openCheck();

            checkoutService.addProduct(new Product(7, "Milk", Category.MILK));
            checkoutService.addProduct(new Product(3, "Bred", Category.Bred));
            Check check = checkoutService.closeCheck();

            Assert.Equal(check.getTotalPoints(), 10);
        }

        [Fact]
        void useOffer__addOfferPoints()
        {
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.openCheck();

            checkoutService.addProduct(new Product(7, "Milk", Category.MILK));
            checkoutService.addProduct(new Product(3, "Bred", Category.Bred));
            checkoutService.useOffer(new AnyGoodsOffer(6, 2));
            Check check = checkoutService.closeCheck();

            Assert.Equal(check.getTotalPoints(), 12);
        }

        [Fact]
        void useOffer__whenCostLessThanRequired__doNothing()
        {
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.openCheck();

            checkoutService.addProduct(new Product(3, "Bred", Category.Bred));
            checkoutService.useOffer(new AnyGoodsOffer(6, 2));
            Check check = checkoutService.closeCheck();

            Assert.Equal(5, check.getTotalPoints());
        }

        [Fact]
        void useOffer__factorByCategory()
        {
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.openCheck();

            checkoutService.addProduct(new Product(7, "Milk", Category.MILK));
            checkoutService.addProduct(new Product(7, "Milk", Category.MILK));
            checkoutService.addProduct(new Product(3, "Bred", Category.Bred));

            checkoutService.useOffer(new FactorByCategoryOffer(Category.MILK, 2));
            Check check = checkoutService.closeCheck();

            Assert.Equal(check.getTotalPoints(), 31);
        }

        [Fact]
        void useOffer__checkDefaultExpiration() {
            FactorByCategoryOffer offer = new FactorByCategoryOffer(Category.MILK, 2);
            
            Assert.Equal(offer.checkExpiration(), true);
        }

        [Fact]
        void useOffer__checkExpiration() {
            FactorByCategoryOffer offer = new FactorByCategoryOffer(Category.MILK, 2);
            offer.setExpiration(DateTime.Now.AddYears(-1));
            
            Assert.Equal(offer.checkExpiration(), false);
        }
    }
}