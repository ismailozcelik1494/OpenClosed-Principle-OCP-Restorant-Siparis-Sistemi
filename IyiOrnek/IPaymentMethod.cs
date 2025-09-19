// Temel ödeme interface'i - değişmez
public interface IPaymentMethod
{
    string PaymentType { get; }
    bool ProcessPayment(decimal amount);
    bool ValidatePaymentData();
}