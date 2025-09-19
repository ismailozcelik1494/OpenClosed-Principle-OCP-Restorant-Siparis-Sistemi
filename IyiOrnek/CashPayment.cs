// Nakit ödeme
public class CashPayment : IPaymentMethod
{
    public string PaymentType => "Nakit";
    
    public bool ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Nakit ödeme alındı: {amount:C}");
        Console.WriteLine("Para üstü hesaplanıyor...");
        return true;
    }
    
    public bool ValidatePaymentData()
    {
        return true; // Nakit için özel validasyon gerekmiyor
    }
}