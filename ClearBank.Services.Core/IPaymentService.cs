
using ClearBank.Services.Models;

namespace ClearBank.Services.Core
{
    public interface IPaymentService
    {
        MakePaymentResult MakePayment(MakePaymentRequest request);
    }
}
