# İnsan Kaynakları Yönetim Sistemi (IKYS) API

Bu repository, İnsan Kaynakları Yönetim Sistemi (IKYS) için Backend API'yi içerir. API, C# ve .NET Core kullanılarak geliştirilmiştir ve SQL Server veritabanı ile entegre çalışır. API, RESTful mimari kullanarak şirketler, yöneticiler, çalışanlar ve talepler gibi kaynakları yönetmenizi sağlar.

## Proje Özeti

İnsan Kaynakları Yönetim Sistemi (IKYS), şirketlerin ve çalışanlarının yönetimini sağlayan bir uygulamadır. Onion Architecture deseni ile yapılmıştır. Bu backend API, aşağıdaki işlevleri sağlamaktadır:

- **Şirket Yönetimi**: Şirket bilgilerini ekleme, düzenleme, silme.
- **Yönetici Yönetimi**: Çalışan bilgilerini ekleme, güncelleme, silme.
- **Çalışan Yönetimi**: Çalışan bilgilerini ekleme, güncelleme, silme.
- **Talep Yönetimi**: Çalışanların taleplerini oluşturma, görüntüleme ve güncelleme.

API, **Onion Architecture** prensiplerine göre tasarlanmış olup, iş mantığı, veri erişimi ve dış servisler birbirinden bağımsız olarak yapılandırılmıştır. Bu sayede sistemin bakımı, test edilebilirliği ve genişletilmesi kolaydır.

## Kullanılan Teknolojiler

- **Backend API**: C# ve SQL Server kullanılarak geliştirilmiştir.
- **Veritabanı**: SQL Server
- **Mimari**: Backend'de Onion Architecture kullanılmıştır.
 
## Gereksinimler
- SQL Server (veritabanı için)
  
### Yazılım Gereksinimleri

- **.NET SDK**: API'yi çalıştırmak için .NET Core SDK gereklidir. [En son sürümü buradan indiriniz](https://dotnet.microsoft.com/download).
- **SQL Server**: Veritabanı yönetim sistemi olarak SQL Server gereklidir. [SQL Server'ı buradan indiriniz](https://www.microsoft.com/en-us/sql-server/sql-server-downloads).

### Donanım Gereksinimleri

- **RAM**: En az 4GB
- **İşlemci**: Modern çok çekirdekli işlemci (i7 veya daha iyisi önerilir)
- **Depolama**: En az 1GB boş disk alanı

## Kurulum

### 1. Repository'yi Klonlayın

Proje dosyalarını yerel bilgisayarınıza klonlamak için aşağıdaki komutu kullanabilirsiniz:

```bash
git clone https://github.com/hazanakpinar/IKPro-backend.git

