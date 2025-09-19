// Kötü tasarım - Her yeni ödeme türü için kod değişikliği gerekiyor
public class PaymentProcessor
{
    public bool ProcessPayment(decimal amount, string paymentType, object paymentData)
    {
        switch (paymentType.ToLower())
        {
            case "cash":
                return ProcessCashPayment(amount);
                
            case "creditcard":
                var cardData = (CreditCardData)paymentData;
                return ProcessCreditCardPayment(amount, cardData);
                
            case "debitcard":
                var debitData = (DebitCardData)paymentData;
                return ProcessDebitCardPayment(amount, debitData);
                
            // Yeni ödeme türü eklemek için bu kodu değiştirmek zorundayız
            case "paypal":
                var paypalData = (PayPalData)paymentData;
                return ProcessPayPalPayment(amount, paypalData);
                
            case "googlepay":
                var googleData = (GooglePayData)paymentData;
                return ProcessGooglePayPayment(amount, googleData);
                
            default:
                throw new NotSupportedException($"Payment type {paymentType} is not supported");
        }
    }
    
    private bool ProcessCashPayment(decimal amount)
    {
        Console.WriteLine($"Nakit ödeme: {amount:C}");
        return true;
    }
    
    private bool ProcessCreditCardPayment(decimal amount, CreditCardData data)
    {
        Console.WriteLine($"Kredi kartı ödeme: {amount:C} - Kart: ****{data.Number.Substring(data.Number.Length - 4)}");
        // Kredi kartı doğrulama ve işlem
        return data.CVV?.Length == 3;
    }
    
    private bool ProcessDebitCardPayment(decimal amount, DebitCardData data)
    {
        Console.WriteLine($"Banka kartı ödeme: {amount:C}");
        return !string.IsNullOrEmpty(data.PIN) && data.PIN.Length == 4;
    }
    
    // Her yeni ödeme türü için yeni metot eklemek zorundayız
    private bool ProcessPayPalPayment(decimal amount, PayPalData data)
    {
        Console.WriteLine($"PayPal ödeme: {amount:C} - Email: {data.Email}");
        return !string.IsNullOrEmpty(data.Email) && data.Email.Contains("@");
    }
    
    private bool ProcessGooglePayPayment(decimal amount, GooglePayData data)
    {
        Console.WriteLine($"Google Pay ödeme: {amount:C}");
        return !string.IsNullOrEmpty(data.Token);
    }
}