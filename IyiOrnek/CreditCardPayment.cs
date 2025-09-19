// Kredi kartı ödeme
public class CreditCardPayment : IPaymentMethod
{
    private readonly string cardNumber;
    private readonly string cvv;
    private readonly string expiryDate;
    private readonly string cardHolderName;
    
    public string PaymentType => "Kredi Kartı";
    
    public CreditCardPayment(string cardNumber, string cvv, string expiryDate, string cardHolderName)
    {
        this.cardNumber = cardNumber;
        this.cvv = cvv;
        this.expiryDate = expiryDate;
        this.cardHolderName = cardHolderName;
    }
    
    public bool ProcessPayment(decimal amount)
    {
        if (!ValidatePaymentData())
        {
            Console.WriteLine("Kredi kartı bilgileri geçersiz!");
            return false;
        }
        
        Console.WriteLine($"Kredi kartı ödeme işleniyor: {amount:C}");
        Console.WriteLine($"Kart: ****{cardNumber.Substring(cardNumber.Length - 4)}");
        Console.WriteLine($"Kart sahibi: {cardHolderName}");
        
        // Banka API'si simülasyonu
        bool bankApproval = SimulateBankApproval();
        
        if (bankApproval)
        {
            Console.WriteLine("Ödeme başarıyla onaylandı!");
            return true;
        }
        else
        {
            Console.WriteLine("Banka ödemeyi reddetti!");
            return false;
        }
    }
    
    public bool ValidatePaymentData()
    {
        // Kart numarası kontrolü (basit Luhn algoritması)
        if (string.IsNullOrEmpty(cardNumber) || cardNumber.Length != 16)
            return false;
            
        // CVV kontrolü
        if (string.IsNullOrEmpty(cvv) || cvv.Length != 3)
            return false;
            
        // Son kullanma tarihi kontrolü
        if (DateTime.TryParseExact(expiryDate, "MM/yy", null, 
            System.Globalization.DateTimeStyles.None, out DateTime expiry))
        {
            return expiry > DateTime.Now;
        }
        
        return false;
    }
    
    private bool SimulateBankApproval()
    {
        // %90 onay oranı simülasyonu
        return Random.Shared.Next(1, 101) <= 90;
    }
}