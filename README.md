# Bilimsel Hesap Makinesi

Bu proje, C# Windows Forms kullanılarak geliştirilmiş bir bilimsel hesap makinesi uygulamasıdır. Uygulama, temel matematiksel işlemlerden bilimsel hesaplamalara kadar geniş bir yelpazede işlem yapabilme yeteneğine sahiptir.

## Özellikler

### 🔢 Temel İşlevler
- Rakamlar (0-9)
- Dört işlem butonları (+, -, ×, ÷)
- Mod alma (%)
- Virgül (,)
- Parantez ( )
- Eşittir (=)
- Temizleme (AC)
- Tek karakter silme (C)

### 🧮 Bilimsel İşlemler
- Faktöriyel (x!)
- Doğal logaritma (ln)
- 10 tabanında logaritma (log)
- Karekök (√)
- Üs alma (xʸ)
- Matematiksel sabitler (π ve e)
- Trigonometrik işlemler (sin, cos, tan)

## Proje Gereksinimleri ve Kurallar

1. **Form Tasarımı**
   - Her öğrencinin form tasarımı (arayüz yerleşimi) kendine özgü olmalıdır.
   - Form boyutu: 400x539 piksel
   - Başlangıç pozisyonu: Ekran merkezi
   - Arka plan rengi: RGB(240, 240, 240)

2. **Kodlama Standartları**
   - Tüm değişkenler, butonlar ve metodlar Türkçe isimlendirme ile yazılmıştır.
   - Pascal Notasyonu kullanılmıştır (her kelime büyük harfle başlar).
   - Örnek: `RakamEkle`, `IslemEkle`, `HesaplaTemelIslem`

3. **Metot Yapısı**
   - Dört işlem (+, -, ×, ÷) ve rakam butonları (0-9) geriye değer döndüren metodlarla tanımlanmıştır.
   - Örnek:
     ```csharp
     private string RakamEkle(string rakam)
     private string IslemEkle(string islem)
     ```

4. **Void Metotlar**
   - Projede en az bir adet geriye değer döndürmeyen metot(void) kullanılmıştır.
   - Örnek:
     ```csharp
     private void FormAyarlariniYukle()
     private void TrigonometrikIslemYap(string fonksiyon)
     ```

5. **Hesaplama Yetenekleri**
   - Tüm hesaplamalar birden fazla sayıyı ve işlemi destekleyecek şekilde yapılmıştır.
   - İşlem önceliği sırası:
     1. Parantez içi işlemler
     2. Kök işlemleri
     3. Üs alma işlemleri
     4. Çarpma, bölme ve mod işlemleri
     5. Toplama ve çıkarma işlemleri

6. **Sonuç Gösterimi**
   - Kullanıcı, = butonuna bastığında işlem sonucu görüntülenir.
   - Hata durumlarında kullanıcıya bilgilendirici mesajlar gösterilir.

## Teknik Detaylar

### Kullanılan Teknolojiler
- C# 7.3
- Windows Forms
- .NET Framework

### Önemli Metotlar
1. **HesaplaIfade**
   - Parantez içi işlemleri yönetir
   - Kök işlemlerini kontrol eder
   - Temel işlemleri hesaplar

2. **HesaplaTemelIslem**
   - Kök işlemlerini hesaplar
   - Üs alma işlemlerini yapar
   - Çarpma, bölme ve mod işlemlerini gerçekleştirir
   - Toplama ve çıkarma işlemlerini yapar

3. **TrigonometrikIslemYap**
   - Sinüs, kosinüs ve tanjant hesaplamalarını yapar
   - Radyan/derece modunu destekler

## Kullanım Örnekleri

1. **Temel İşlemler**
   ```
   2 + 3 × 4 = 14
   (2 + 3) × 4 = 20
   ```

2. **Bilimsel İşlemler**
   ```
   √16 = 4
   2^3 = 8
   sin(90) = 1 (derece modunda)
   ```

3. **Karmaşık İşlemler**
   ```
   √(16 + 9) = 5
   (2 + 3) × √(16) = 20
   ```

## Geliştirme Notları
- Proje, Visual Studio IDE kullanılarak geliştirilmiştir.
- Tüm kodlar Türkçe isimlendirme standartlarına uygun yazılmıştır.
- Hata yönetimi ve kullanıcı geri bildirimi öncelikli olarak ele alılmıştır. 
