
![indir](https://github.com/user-attachments/assets/5af8865a-0294-4e30-a0ad-1db6724f8c6d)

# J‑HR DökümanKataloğu Aktar

🏢 **HR doküman kataloğundan PDF/Excel dosya bilgisini çekip, hedef sisteme aktarım yapan Windows aracı**  
Özellikle Logo ERP ya da dış sistemlerin İK modüllerindeki doküman meta verilerini okur ve başka bir veritabanına veya depolama servisine gönderir (örneğin SharePoint, SQL, AWS S3 vb.).

---

## 🔍 Özellikler

- 📁 Kaynak klasör veya veritabanından doküman listesini okur
- 📊 PDF/Excel dosya meta verisini çıkarır (isim, boyut, tarih, md5/sha1 hash)
- 🚚 Verileri hedef sistem tipine göre aktarır (SQL, JSON API, REST)
- 🧭 Mapping / eşleme şablonları destekli (kaynak ↔ hedef)
- 🔄 Kısa aralıklarla tekrarlanan görev planlaması (Quartz.NET)
- 📝 Aktarım başarı/hata logları

---

## 📂 Proje Yapısı

J‑HR_DokumanKatalogu_Aktar/
├── Reader/ # Metadata okuma sınıfları (PDF, Excel, klasör)
├── Mapper/ # Kaynak → hedef eşlemeleri
├── Writer/ # Hedef sisteme yazma (DB, API)
├── Scheduler/ # Quartz.NET görev tanımları
├── Config/ # appsettings.json / mapping dosyaları
├── Models/ # Metadata modelleri
├── Logging/ # Aktarım logları
└── Program.cs # Konsol veya servis uygulaması

---

## ⚙️ Kurulum & Kullanım

1. `appsettings.json` içinde:
   - Kaynak (SQL, klasör, dosya path)
   - Hedef (SQL bağlantısı, API endpoint)
   - Mapping ayarları (örneğin JSON içinde “DokumanTipi”: “HedefKategori”)
   - Quartz cron tanımı (örneğin: `0 0/15 * * * ?` – her 15 dakikada bir)

---

🧠 Teknik Detaylar
.NET 6+ konsol veya Worker Service

Quartz.NET zamanlama

PDF: iTextSharp veya PDFSharp

Excel: EPPlus veya ClosedXML

Hash: SHA256

Logging: NLog veya Serilog

Mapping: JSON veya YAML şablonlarla esnek yapı

---

🛠️ Geliştirici İpuçları
Try/catch içine alınmış tüm veri okuma ve yazma işlemleri

Hatalı kayıtlar “ErrorLog” tablosuna yazılır

Başarılı olanların sayısı ve meta bilgisi “SuccessLog” içinde

Kaynak ve hedef modeller ReaderModel ve WriterModel olarak ayrılmış

---

📄 Lisans
MIT License

---

📬 İletişim
👨‍💻 Geliştirici: @dogukankosan
🐞 Hata bildirimi ve öneri için: Issues sekmesi

