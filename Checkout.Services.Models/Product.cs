namespace Checkout.Services
{
    public class Product
    {
        public string model { get; set; }

        public int unitPrice { get; set; }

        public bool hasDiscount { get; set; }

        public int? forUnits { get; set; }

        public int? discountPrice { get; set; }
    }
}
