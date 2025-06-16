
![indir](https://github.com/user-attachments/assets/1cf4d5e0-965d-46d0-bd35-9b8e13310371)

# J‑HR DökümanKataloğu Aktar

**J‑HR DökümanKataloğu Aktar**, Excel dosyasındaki doküman verilerini (PDF/Excel dosya bilgileri vb.) okuyan ve doğrudan bir veritabanına aktaran, pratik ve güvenli bir Windows aracıdır. Temel işlevi; İK veya doküman yönetim sistemlerinde, toplu veri aktarımını hatasız ve otomatik şekilde sağlamaktır. Tüm aktarımlar sırasında detaylı loglama yapılır ve herhangi bir hata oluşursa, yapılan işlemlerin tamamı otomatik olarak geri alınır (transaction rollback). Böylece veri bütünlüğü ve güvenliği korunur.

---

## 🚀 Temel Özellikler

- 📊 **Excel dosyasından toplu veri okuma**
- 🗄️ **Okunan verileri doğrudan veritabanına yazma (SQL)**
- 🛡️ **Tüm aktarım işlemleri transaction ile güvence altında; hata olursa işlem tamamen geri alınır**
- 📝 **Başarılı ve hatalı işlemler için detaylı loglama**
- 🔄 **Tek tıkla veya zamanlanmış olarak otomatik çalıştırma**
- ⚙️ **Kolay yapılandırma (Excel yolu, veritabanı bağlantısı, mapping ayarları)**

---

## 🗂 Proje Yapısı

```
J‑HR_DokumanKatalogu_Aktar/
├── ExcelReader/   # Excel dosyasından veri okuma
├── DbWriter/      # Veritabanına yazma işlemleri (transaction destekli)
├── Logging/       # Başarı ve hata loglama
├── Models/        # Veri modelleri
├── Config/        # Ayar dosyaları (appsettings.json)
└── Program.cs     # Uygulama giriş noktası
```

---

## 🛠️ Teknik Detaylar

- .NET 4.8 ile geliştirilmiştir.
- Excel işlemleri için EPPlus veya ClosedXML kullanılır.
- Veritabanı işlemleri transaction (işlem bütünlüğü) ile yapılır.
- Loglama için NLog veya Serilog tercih edilir.
- Hata durumunda yapılan tüm işlemler otomatik olarak geri alınır (rollback).

---

## ⚙️ Kullanım

1. `appsettings.json` dosyasından:
    - Excel dosya yolunu
    - Veritabanı bağlantı cümleni
2. Uygulamayı başlat; veriler otomatik olarak aktarılır.
3. Log dosyalarını ve işlemlerin durumunu kontrol et.

---

## 📄 Lisans

MIT License

---

## 📬 İletişim

- 👨‍💻 Geliştirici: [@dogukankosan](https://github.com/dogukankosan)  
- 🐞 Suggestions or issues: [Issues sekmesi](https://github.com/dogukankosan/LogoWhatsappEntegrasyon/issues)

---
