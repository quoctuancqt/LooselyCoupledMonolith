using Refit;
using System.Threading.Tasks;

namespace OrderService.Contract
{
    public interface IOrderClient
    {
        [Post("/api/order")]
        Task<OrderResponse> CreateAsync();
    }
}
