// Apple Pay ödeme - Sonradan eklenen, hiçbir mevcut kodu değiştirmeden
public class ApplePayPayment : IPaymentMethod
{
    private readonly string deviceId;
    private readonly string touchId;
    private readonly bool isTouchIdAuthenticated;
    
    public string PaymentType => "Apple Pay";
    
    public ApplePayPayment(string deviceId, string touchId, bool isTouchIdAuthenticated)
    {
        this.deviceId = deviceId;
        this.touchId = touchId;
        this.isTouchIdAuthenticated = isTouchIdAuthenticated;
    }
    
    public bool ProcessPayment(decimal amount)
    {
        if (!ValidatePaymentData())
        {
            Console.WriteLine("Apple Pay kimlik doğrulama başarısız!");
            return false;
        }
        
        Console.WriteLine($"Apple Pay ödeme işleniyor: {amount:C}");
        Console.WriteLine("Touch ID ile kimlik doğrulandı");
        Console.WriteLine($"Cihaz ID: {deviceId}");
        
        // Apple Pay API simülasyonu
        bool applePayApproval = SimulateApplePayAPI();
        
        if (applePayApproval)
        {
            Console.WriteLine("Apple Pay ödemesi başarılı!");
            return true;
        }
        else
        {
            Console.WriteLine("Apple Pay ödemesi başarısız!");
            return false;
        }
    }
    
    public bool ValidatePaymentData()
    {
        return !string.IsNullOrEmpty(deviceId) && 
               !string.IsNullOrEmpty(touchId) && 
               isTouchIdAuthenticated;
    }
    
    private bool SimulateApplePayAPI()
    {
        return Random.Shared.Next(1, 101) <= 98; // %98 başarı oranı
    }
}