// Banka kartı ödeme
public class DebitCardPayment : IPaymentMethod
{
    private readonly string cardNumber;
    private readonly string pin;
    private readonly decimal accountBalance;
    
    public string PaymentType => "Banka Kartı";
    
    public DebitCardPayment(string cardNumber, string pin, decimal accountBalance)
    {
        this.cardNumber = cardNumber;
        this.pin = pin;
        this.accountBalance = accountBalance;
    }
    
    public bool ProcessPayment(decimal amount)
    {
        if (!ValidatePaymentData())
        {
            Console.WriteLine("Banka kartı bilgileri geçersiz!");
            return false;
        }
        
        if (accountBalance < amount)
        {
            Console.WriteLine($"Yetersiz bakiye! Mevcut: {accountBalance:C}, Gerekli: {amount:C}");
            return false;
        }
        
        Console.WriteLine($"Banka kartı ödeme işleniyor: {amount:C}");
        Console.WriteLine($"Kart: ****{cardNumber.Substring(cardNumber.Length - 4)}");
        Console.WriteLine($"Kalan bakiye: {(accountBalance - amount):C}");
        Console.WriteLine("Ödeme başarıyla tamamlandı!");
        
        return true;
    }
    
    public bool ValidatePaymentData()
    {
        return !string.IsNullOrEmpty(cardNumber) && 
               cardNumber.Length == 16 && 
               !string.IsNullOrEmpty(pin) && 
               pin.Length == 4 &&
               pin.All(char.IsDigit);
    }
}