# Project37_CodeFirstBasic

Bu proje, **Entity Framework Core** kullanarak **Code-First** yaklaşımıyla bir veritabanı oluşturmayı ve veritabanını iki varlık (`Movies` ve `Games`) ile doldurmayı amaçlamaktadır. Aşağıda proje yapısı ve işleyişi hakkında detaylı bir açıklama bulunmaktadır.

---

## 📂 Proje Yapısı

- **Namespace:** `Project37_CodeFirstBasic.Data`
- **DbContext Sınıfı:** `PatikaFirstDbContext`

Veritabanı bağlamı, varlıkları ve bunlara ait yapılandırmaları yönetir. Projede iki ana varlık bulunmaktadır:
1. `Movie` (Film)
2. `Game` (Oyun)

---

## 🔧 Veritabanı Yapılandırması

### OnConfiguring
Veritabanı bağlantısı aşağıdaki yapılandırmayla oluşturulmaktadır:
```csharp
optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Username=postgres;Password=postgres;Database=PatikaCodeFirstDb1");
```
PostgreSQL'in çalıştığından ve bağlantı bilgilerini yerel ayarlarınıza göre düzenlediğinizden emin olun.

### OnModelCreating
Varlıklara özel yapılandırmalar ve başlangıç (seed) verileri burada tanımlanmıştır.

---

## 🎥 Movie Varlığı

### Tablo Yapılandırması
- **Tablo Adı:** `Movies`
- **Özellikler:**
  - `Id` (Birincil Anahtar)
  - `Title` (Gerekli, Maksimum Uzunluk: 150)
  - `Genre` (Tür)
  - `ReleaseYear` (Gerekli, Çıkış Yılı)

### Başlangıç Verileri
`Movies` tablosu aşağıdaki verilerle doldurulmaktadır:
| Id  | Başlık              | Tür              | Çıkış Yılı  |
|------|---------------------|------------------|-------------|
| 1    | Inception           | Bilim Kurgu      | 2010        |
| 2    | The Godfather       | Suç              | 1972        |
| 3    | The Dark Knight     | Aksiyon          | 2008        |
| 4    | Forrest Gump        | Dram             | 1994        |
| 5    | Coco                | Animasyon        | 2017        |

---

## 🎮 Game Varlığı

### Tablo Yapılandırması
- **Tablo Adı:** `Games`
- **Özellikler:**
  - `Id` (Birincil Anahtar)
  - `Name` (Gerekli, Maksimum Uzunluk: 100)
  - `Platform` (Gerekli, Maksimum Uzunluk: 150)
  - `Rating` (20,2 Ondalık, Opsiyonel)

### Başlangıç Verileri
`Games` tablosu aşağıdaki verilerle doldurulmaktadır:
| Id  | İsim                     | Platform         | Puan (Eğer belirtilmişse) |
|------|--------------------------|------------------|---------------------------|
| 1    | Red Dead Redemption 2    | PC               | -                         |
| 2    | The Last of Us Part II   | PlayStation      | -                         |
| 3    | Halo Infinite            | Xbox             | -                         |
| 4    | Super Mario Odyssey      | Nintendo Switch  | -                         |
| 5    | Cyberpunk 2077           | PC               | -                         |

---

## 🛠️ Kullanım Adımları

1. **Bağımlılıkları Yükleyin**: Aşağıdaki komutlarla Entity Framework Core ve PostgreSQL NuGet paketlerini yükleyin:
   ```bash
   dotnet add package Microsoft.EntityFrameworkCore
   dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
   ```

2. **PostgreSQL Veritabanını Ayarlayın**:
   - PostgreSQL'in kurulu ve çalışır durumda olduğundan emin olun.
   - `PatikaCodeFirstDb1` adında bir veritabanı oluşturun.

3. **Migrasyonları Uygulayın**:
   - Terminalden aşağıdaki komutları çalıştırarak migrasyon oluşturun ve veritabanına uygulayın:
     ```bash
     dotnet ef migrations add InitialCreate
     dotnet ef database update
     ```

4. **Verileri Kontrol Edin**:
   - PostgreSQL'de `Movies` ve `Games` tablolarını kontrol ederek başlangıç verilerinin başarıyla eklendiğinden emin olun.

---

## 🚀 Özellikler

- **Code-First Yaklaşımı**: Veritabanı şeması doğrudan kod ile tanımlanır.
- **Otomatik Veri Doldurma**: Tablolar başlangıç verileriyle doldurulur.
- **Genişletilebilir Yapı**: Daha fazla varlık veya ilişki kolayca eklenebilir.

---

## 🌟 Gelecekteki Geliştirmeler

- `Movie` ve `Game` varlıklarına `Director` (Yönetmen), `Publisher` (Yayımcı) veya `Price` (Fiyat) gibi özellikler eklenebilir.
- Varlıklar arasında ilişkiler tanımlanabilir (ör. `Movie` türleri veya `Game` geliştiricileri).
- Veritabanıyla etkileşim kurmak için bir ön yüz arayüzü eklenebilir.

---

## 🧠 Fikirler ve Notlar

Bu proje, **Entity Framework Core** kullanılarak veritabanı yönetiminin nasıl kolaylaştırılabileceğini göstermektedir. Kod ile veritabanı şeması arasındaki tutarlılığı sağlamak ve yönetimi kolaylaştırmak için etkili bir yöntemdir.

İyi çalışmalar! 🚀
