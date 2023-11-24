using Service.Interface.Responses;

namespace Service.Interface
{
    public interface IRepository
    {
        Task<CheckoutResponse> Checkout(List<string> product, CancellationToken cancellationToken =default);
        void setProductDetails();
    }
}
