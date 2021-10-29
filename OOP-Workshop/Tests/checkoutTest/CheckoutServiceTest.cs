using Xunit;
using System;

namespace OOP_Workshop
{
    public class CheckoutServiceTest
    {
        CheckoutService checkoutService;
        Product Milk_7;
        Product Milk_8;
        Product Bred_3;
        AnyGoodsOffer anyGoodsOffer;
        FactorByCategoryOffer factorByMilkOffer;
        FactorByCategoryOffer factorByBredOffer;
        BrandOffer brandOffer;
        DiscountOffer discountOffer;

        public CheckoutServiceTest()
        {
            checkoutService = new CheckoutService();
            Milk_7 = new Product(7, "Milk", "Волошкове поле", Category.MILK);
            Milk_8 = new Product(8, "Milk", "Волошкове поле", Category.MILK);
            Bred_3 = new Product(3, "Bred", Category.Bred);
            anyGoodsOffer = new AnyGoodsOffer(6, 2);
            factorByMilkOffer = new FactorByCategoryOffer(Category.MILK, 2);
            factorByBredOffer = new FactorByCategoryOffer(Category.Bred, 3);
            brandOffer = new BrandOffer("Волошкове поле");
            discountOffer = new DiscountOffer(Milk_8, 0.5);
        }

        [Fact]
        void closeCheck_withOneProduct()
        {
            checkoutService.openCheck();

            checkoutService.addProduct(Milk_7);
            Check check = checkoutService.closeCheck();

            Assert.Equal(check.getTotalCost(), 7);
        }

        [Fact]
        void closeCheck_withTwoProduct()
        {
            checkoutService.openCheck();

            checkoutService.addProduct(Milk_7);
            checkoutService.addProduct(Bred_3);
            Check check = checkoutService.closeCheck();

            Assert.Equal(check.getTotalCost(), 10);
        }

        [Fact]
        void addProduct__whenCheckIsClosed__opensNewCheck()
        {
            checkoutService.openCheck();

            checkoutService.addProduct(Milk_7);
            Check milkCheck = checkoutService.closeCheck();
            Assert.Equal(milkCheck.getTotalCost(), 7);

            checkoutService.addProduct(Bred_3);
            Check bredCheck = checkoutService.closeCheck();
            Assert.Equal(bredCheck.getTotalCost(), 3);
        }

        [Fact]
        void closeCheck__calcTotalPoints()
        {
            checkoutService.openCheck();

            checkoutService.addProduct(Milk_7);
            checkoutService.addProduct(Bred_3);
            Check check = checkoutService.closeCheck();

            Assert.Equal(check.getTotalPoints(), 10);
        }

        [Fact]
        void useOffer__addOfferPoints()
        {
            checkoutService.openCheck();

            checkoutService.addProduct(Milk_7);
            checkoutService.addProduct(Bred_3);

            checkoutService.useOffer(anyGoodsOffer);
            Check check = checkoutService.closeCheck();

            Assert.Equal(12, check.getTotalPoints());
        }

        [Fact]
        void useOffer__whenCostLessThanRequired__doNothing()
        {
            checkoutService.openCheck();

            checkoutService.addProduct(Bred_3);
            checkoutService.useOffer(anyGoodsOffer);
            Check check = checkoutService.closeCheck();

            Assert.Equal(3, check.getTotalPoints());
        }

        [Fact]
        void useOffer__factorByCategory()
        {
            checkoutService.openCheck();

            checkoutService.addProduct(Milk_7);
            checkoutService.addProduct(Milk_7);
            checkoutService.addProduct(Bred_3);

            checkoutService.useOffer(factorByMilkOffer);
            Check check = checkoutService.closeCheck();

            Assert.Equal(check.getTotalPoints(), 31);
        }

        [Fact]
        void usefactorByCategoryOffer__BeforeAddingLastProduct()
        {
            checkoutService.openCheck();

            checkoutService.addProduct(Milk_7);
            checkoutService.addProduct(Bred_3);
            
            checkoutService.useOffer(factorByMilkOffer);
            checkoutService.addProduct(Milk_7);
           
            Check check = checkoutService.closeCheck();

            Assert.Equal(check.getTotalPoints(), 31);
        }

        [Fact]
        void useOffer__DefaultExpiration()
        {
            checkoutService.openCheck();

            checkoutService.addProduct(Milk_7);
            checkoutService.useOffer(factorByMilkOffer);
            Check check = checkoutService.closeCheck();

            Assert.Equal(14, check.getTotalPoints());
        }

        [Fact]
        void useOffer__changeExpiration()
        {
            checkoutService.openCheck();

            checkoutService.addProduct(Milk_7);
            factorByMilkOffer.setExpiration(DateTime.Now.AddYears(-1));
            checkoutService.useOffer(factorByMilkOffer);
            Check check = checkoutService.closeCheck();

            Assert.Equal(7, check.getTotalPoints());
        }

        [Fact]
        void useOffer_BrandOffer() {
            checkoutService.openCheck();
            checkoutService.addProduct(Milk_7);
            checkoutService.addProduct(Milk_7);
            checkoutService.addProduct(Bred_3);

            checkoutService.useOffer(brandOffer);
            Check check = checkoutService.closeCheck();

            Assert.Equal(31, check.getTotalPoints());
        }

        [Fact]
        void useOffer_ProductOffer() {
            checkoutService.openCheck();
            checkoutService.addProduct(Milk_7);
            checkoutService.addProduct(Milk_7);
            checkoutService.addProduct(Bred_3);

            checkoutService.useOffer(new ProductOffer(Milk_7));
            Check check = checkoutService.closeCheck();

            Assert.Equal(31, check.getTotalPoints());
        }

        [Fact]
        void useOffer_DiscountOffer() {
            checkoutService.openCheck();
            checkoutService.addProduct(Milk_8);
            checkoutService.addProduct(Milk_8);
            checkoutService.addProduct(Bred_3);

            checkoutService.useOffer(discountOffer);
            Check check = checkoutService.closeCheck();

            Assert.Equal(11, check.getTotalCost());
        }
    }
}