// PayPal ödeme - Yeni eklenen, mevcut kodu değiştirmeden
public class PayPalPayment : IPaymentMethod
{
    private readonly string email;
    private readonly string password;
    
    public string PaymentType => "PayPal";
    
    public PayPalPayment(string email, string password)
    {
        this.email = email;
        this.password = password;
    }
    
    public bool ProcessPayment(decimal amount)
    {
        if (!ValidatePaymentData())
        {
            Console.WriteLine("PayPal bilgileri geçersiz!");
            return false;
        }
        
        Console.WriteLine($"PayPal ödeme işleniyor: {amount:C}");
        Console.WriteLine($"Hesap: {email}");
        
        // PayPal API simülasyonu
        bool paypalApproval = SimulatePayPalAPI();
        
        if (paypalApproval)
        {
            Console.WriteLine("PayPal ödemesi başarılı!");
            return true;
        }
        else
        {
            Console.WriteLine("PayPal ödemesi başarısız!");
            return false;
        }
    }
    
    public bool ValidatePaymentData()
    {
        return !string.IsNullOrEmpty(email) && 
               email.Contains("@") && 
               !string.IsNullOrEmpty(password) && 
               password.Length >= 6;
    }
    
    private bool SimulatePayPalAPI()
    {
        return Random.Shared.Next(1, 101) <= 95; // %95 başarı oranı
    }
}