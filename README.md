# 📅 Activity Planner API

**ActivityPlanner**, kullanıcıların etkinlik planlaması yapabileceği, **Angular frontend** ve **ASP.NET Core Web API** tabanlı bir projedir. REST mimarisine uygun olarak geliştirilmiş, modüler ve ölçeklenebilir bir katmanlı mimariye sahiptir.

## 🛠️ Kullanılan Teknolojiler

- **ASP.NET Core (.NET 9 Preview)** – Web API geliştirme platformu
- **Entity Framework Core** – Veritabanı işlemleri için ORM (Object-Relational Mapping) aracı
- **SQL Server** – İlişkisel veritabanı sistemi
- **JWT Authentication** – Güvenli kullanıcı kimlik doğrulama yöntemi
- **AutoMapper** – Nesneler arası veri transferi ve eşleme kolaylığı
- **Scalar.AspNetCore** – API dokümantasyonu için sade ve modern bir araç
- **StackExchange.Redis** – Redis tabanlı önbellekleme ve dağıtık veri yönetimi
- **Docker** – Redis'in container ortamında çalıştırılması
- **User Secrets (Secret Manager)** – Geliştirme ortamında gizli verilerin güvenli şekilde yönetimi
- **Angular** – Modern, component tabanlı frontend framework
- **Katmanlı Mimari** – Kodun sorumluluklarına göre ayrıldığı yapı

## 📁 Proje Yapısı

## 📁 Proje Yapısı

```bash
├── [ActivityPlanner.API](https://github.com/omerkrmn/activity-planner/tree/main/ActivityPlanner.API)             # Web API uygulamasının giriş noktası
├── [ActivityPlanner.Entities](https://github.com/omerkrmn/activity-planner/tree/main/ActivityPlanner.Entities)   # Veri modelleri ve DTO tanımlamaları
├── [ActivityPlanner.Presentation](https://github.com/omerkrmn/activity-planner/tree/main/ActivityPlanner.Presentation) # Controller'lar ve HTTP endpoint'leri
├── [ActivityPlanner.Repositories](https://github.com/omerkrmn/REPO_ADI/tree/main/ActivityPlanner.Repositories) # Veri erişim katmanı (EF Core)
├── [ActivityPlanner.Service](https://github.com/omerkrmn/activity-planner/tree/main/ActivityPlanner.Service)     # Uygulamanın iş mantığı ve servis katmanı
├── [ActivityPlanner.Frontend](https://github.com/omerkrmn/activity-planner/tree/main/ActivityPlanner.Frontend)   # Angular tabanlı istemci uygulama
├── [ActivityPlanner.Test](https://github.com/omerkrmn/activity-planner/tree/main/ActivityPlanner.Test)           # Birim test projeleri
