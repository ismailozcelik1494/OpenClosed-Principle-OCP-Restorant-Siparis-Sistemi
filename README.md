# Open/Closed Principle (OCP) - Restoran Sipariş Sistemi

Bu projede SOLID prensiplerinden **Open/Closed Principle (OCP)** uygulanmıştır.

## Açıklama

- **İyi Örnek ([IyiOrnek](IyiOrnek))**  
  `IPaymentMethod` arayüzü ile farklı ödeme türleri (Kredi Kartı, Banka Kartı, Nakit, PayPal, Apple Pay) ayrı sınıflarda tanımlanmıştır. Yeni bir ödeme türü eklemek için mevcut kodu değiştirmeye gerek yoktur, sadece yeni bir sınıf eklenir. Kod genişletmeye açıktır, değişikliğe kapalıdır.

- **Kötü Örnek ([KotuOrnek](KotuOrnek/Program.cs))**  
  `PaymentProcessor` sınıfında switch-case ile ödeme türleri ayrılmıştır. Yeni bir ödeme türü eklemek için mevcut kodu değiştirmek gerekir. Bu, OCP'yi ihlal eder.

## Dosya Yapısı

- `IyiOrnek/`  
  - IPaymentMethod.cs  
  - CreditCardPayment.cs  
  - DebitCardPayment.cs  
  - CashPayment.cs  
  - PayPalPayment.cs  
  - ApplePayPayment.cs  

- `KotuOrnek/`  
  - Program.cs  
  - CreditCardData.cs  
  - DebitCardData.cs  
  - PayPalData.cs  
  - GooglePayData.cs  

## OCP'ye Uygun Kod Örneği

Yeni bir ödeme türü eklemek için sadece yeni bir sınıf eklenir:

```csharp
public class NewPaymentType : IPaymentMethod
{
    public string PaymentType => "Yeni Ödeme";
    public bool ProcessPayment(decimal amount) { /* ... */ }
    public bool ValidatePaymentData() { /* ... */ }
}
```

## OCP'yi İhlal Eden Kod Örneği

Yeni bir ödeme türü eklemek için mevcut kod değiştirilir:

```csharp
switch (paymentType)
{
    // ...
    case "newpayment":
        // Yeni kod eklenir
        break;
}
```

## Sonuç

- **İyi örnek**: Kod genişletmeye açık, değişikliğe kapalıdır.
- **Kötü örnek**: Kod hem genişletmeye hem de değişikliğe açıktır, OCP'yi ihlal eder.