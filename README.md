# 📅 Activity Planner API

ActivityPlanner, kullanıcıların etkinlik planlaması yapabileceği, Angular frontend ve ASP.NET Core Web API tabanlı bir projedir. REST mimarisine uygun olarak geliştirilmiştir ve N-tier mimariye sahiptir.

## 🛠️ Kullanılan Teknolojiler

- ASP.NET Core (.NET 9)
- Entity Framework Core
- Angular (Frontend)
- AutoMapper
- FluentValidation
- JWT Authentication
- SQL Server
- N-tier Mimari

## 📁 Proje Yapısı

```bash
├── ActivityPlanner.API             # Uygulamanın başlangıç noktası
├── ActivityPlanner.Entities        # Modeller ve DTO'lar
├── ActivityPlanner.Presentation    # API Controller'ları
├── ActivityPlanner.Repositories    # EF Core üzerinden veri erişimi
├── ActivityPlanner.Service         # İş mantığı ve servis katmanı
├── ActivityPlanner.Frontend        # Angular istemcisi
├── ActivityPlanner.Test            # Unit test projeleri
