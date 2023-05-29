# PhoneBook App

Proje basit haliyle telefon rehberine kişi ekleme ve raporlama üzerine iki adet microservice den oluşmaktadır.

## Özellikler

- Rehbere kişi ekleme, silme, güncelleme ve listeleme
- Rehberdeki kişilerin adres bilgilerini ekleme, silme, güncelleme ve listeleme
- Rapor ekleme, silme, güncelleme ve listeleme işlemleri
- Rapor detay ekleme, silme, güncelleme ve listeleme işlemleri
- Konuma göre kullanıcıların sayısı ve telefon numaralarının sayının rapor edilmesi

## Teknolojiler

Projede kullanılan başlıca teknolojiler:

- .Net Core 6
- RabbitMQ(Masstransit)
- Docker
- PostgreSQL
- MongoDB


## Kurulum

Bilgisayarınızda [Docker](https://www.docker.com/) kurulmuş olmalı.

Projeyi çalıştırmak için proje terminalinden:
```sh
docker-compose up -d
```
komutunu çalıştırmak yeterlidir.
