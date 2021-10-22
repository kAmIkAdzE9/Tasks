using Xunit;

namespace OOP_Workshop {
    public class CheckoutServiceTest {
        [Fact]
        void closeCheck_withOneProduct() {
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.openCheck();

            checkoutService.addProduct(new Product (7, "Milk"));
            Check check = checkoutService.closeCheck();

            Assert.Equal(check.getTotalCost(), 7);
        }

        [Fact]
        void closeCheck_withTwoProduct() {
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.openCheck();

            checkoutService.addProduct(new Product (7, "Milk"));
            checkoutService.addProduct(new Product (3, "Bred"));
            Check check = checkoutService.closeCheck();

            Assert.Equal(check.getTotalCost(), 10);
        }
    }
}