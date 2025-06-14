# J‑HR DökümanKataloğu Aktar

🏢 **HR doküman kataloğundan PDF/Excel dosya bilgisini çekip, hedef sisteme aktarım yapan Windows aracı**  
Özellikle Logo ERP veya dış sistemlerin İK modüllerindeki doküman meta verilerini okur ve başka bir veritabanına veya depolama servisine iletir (örn. SharePoint, SQL, AWS S3 vb.).

---

## 🔍 Özellikler

- 📁 Kaynak klasör veya veritabanından doküman listesi okuma
- 📊 PDF/Excel dosya meta verisinin çıkarılması (isim, boyut, tarih, hash)
- 🚚 SQL, JSON API veya REST ile hedef sisteme aktarım
- 🧭 Mapping/şablon desteği (kaynak ↔ hedef)
- 🔄 Quartz.NET ile zamanlanmış görev planlaması
- 📝 Aktarım başarı ve hata logları

---

## 📂 Proje Yapısı

```
J‑HR_DokumanKatalogu_Aktar/
├── Reader/       # Metadata okuma sınıfları (PDF, Excel, klasör)
├── Mapper/       # Kaynak → hedef eşlemeleri
├── Writer/       # Hedef sisteme yazma (DB, API)
├── Scheduler/    # Quartz.NET görev tanımları
├── Config/       # appsettings.json / mapping dosyaları
├── Models/       # Metadata modelleri
├── Logging/      # Aktarım logları
└── Program.cs    # Konsol veya servis uygulaması
```

---

## ⚙️ Kurulum & Kullanım

1. `appsettings.json` dosyasında:
   - Kaynak (SQL, klasör, dosya yolu)
   - Hedef (SQL bağlantısı, API endpoint)
   - Mapping ayarları (ör: JSON ile “DokumanTipi”: “HedefKategori”)
   - Quartz cron tanımı (örn: `0 0/15 * * * ?` – her 15 dakikada bir çalıştırmak için)

---

## 🧠 Teknik Detaylar

- .NET 6+ (konsol uygulaması veya Worker Service)
- Quartz.NET ile zamanlama
- PDF: iTextSharp veya PDFSharp
- Excel: EPPlus veya ClosedXML
- Hash: SHA256 ile dosya bütünlüğü kontrolü
- Logging: NLog veya Serilog
- Mapping: JSON veya YAML şablonlar

---

## 🛠️ Geliştirici İpuçları

- Tüm okuma/yazma işlemleri try/catch ile korunur
- Hatalı kayıtlar “ErrorLog” tablosuna/log dosyasına yazılır
- Başarılı aktarımlar “SuccessLog” ile takip edilir
- Kaynak ve hedef modeller ayrı (ReaderModel, WriterModel)

---

## 📄 Lisans

MIT License

---

## 📬 İletişim

👨‍💻 Geliştirici: @dogukankosan  
🐞 Hata bildirimi ve öneriler için: Issues sekmesini kullanabilirsiniz.
