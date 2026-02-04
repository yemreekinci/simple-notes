# Simple Notes
TR Türkçe | EN English

---

## TR - Türkçe

### Simple Notes - Full Stack Not Uygulaması

Simple Notes, backend tarafında  
**ASP.NET Core (Clean Architecture)**,  
frontend tarafında ise  
**Flutter (GetX)** kullanılarak geliştirilmiş bir full-stack not uygulamasıdır.

Bu proje; temiz mimari, sürdürülebilirlik ve
frontend–backend iletişimine odaklanmaktadır.

---

### Özellikler

- Not ekleme, güncelleme ve silme
- Drag & drop ile not sıralama
- Tüm notları toplu silme
- Clean Architecture backend yapısı
- OpenAPI dokümantasyonu (Scalar)
- Flutter Web ve Android desteği

---

### Proje Yapısı

```text
simple-notes/
│
├── backend/
│   ├── SimpleNotes.API
│   ├── SimpleNotes.Application
│   ├── SimpleNotes.Domain
│   └── SimpleNotes.Infrastructure
│
├── frontend/
│   └── simplenotes_flutter
│
└── README.md

```
## Kapsam & Sınırlamalar

Bu proje bilinçli olarak basit seviyede tutulmuş olup aşağıdaki konulara odaklanmaktadır:
- Clean Architecture prensipleri
- Full-stack (frontend–backend) iletişim
- Temel CRUD ve sıralama (ordering) mantığı

---

## EN - English


### Simple Notes – Full Stack Notes Application

Simple Notes is a full-stack notes application developed with  
**ASP.NET Core (Clean Architecture)** on the backend and  
**Flutter (GetX)** on the frontend.

This project focuses on clean architecture, maintainability, and
smooth frontend–backend communication.

---

### Features

- Create, update, and delete notes
- Drag & drop note reordering
- Bulk delete (delete all notes)
- Clean Architecture backend structure
- OpenAPI documentation (Scalar)
- Flutter Web and Android support

---

### Project Structure

```text
simple-notes/
│
├── backend/
│   ├── SimpleNotes.API
│   ├── SimpleNotes.Application
│   ├── SimpleNotes.Domain
│   └── SimpleNotes.Infrastructure
│
├── frontend/
│   └── simplenotes_flutter
│
└── README.md

```
## Scope & Limitations

This project is intentionally kept at a basic level and focuses on:
- Clean Architecture principles
- Full-stack (frontend–backend) communication
- Basic CRUD and ordering logic
