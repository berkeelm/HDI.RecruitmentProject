# HDI.RecruitmentProject
Bir firmanın kullanıcı, ürün, arıza, garanti tipi gibi sabitleri tanımlayıp, bayilerin sistemi kullanarak satış yapabildiği, garanti tanımlayabildiği ve değişim & tamir merkezi atayabildiği, değişim & tamir merkezlerinin de sisteme girip değişen parçaları, fiyatlarını girdiği ve en sonunda firmanın bunu dashboard üzerinden özet olarak gördüğü bir sistemdir.

Projede Kullanılan Teknolojiler
- .Net Core 7
- CQRS Mimarisi
- Entity Framework Code First
- MSSQL
- SignalR
- Javascript / JQuery / AJAX
- HTML / CSS
- Bootstrap

Sistemde 3 rol mevcuttur;
- Firma Kullanıcıları
- Bayi Kullanıcıları
- Değişim & Tamir Merkezi Kullanıcıları

Tüm sayfalar rollere göre bir AuthorizationFilter kullanılarak erişime kısıtlanmıştır, ortak sayfalarda da aksiyonlar rol bazlı kısıtlanmıştır.

# Veritabanı Yapısı
![image](https://github.com/berkeelm/HDI.RecruitmentProject/assets/48200058/ef2bd1a3-b096-4495-81de-3a196a5633c1)

# Canlı Loglar (Firma)
![image](https://github.com/berkeelm/HDI.RecruitmentProject/assets/48200058/1dde87fc-5797-45e3-92a0-bd35cbee1061)

Bu sayfada firma yetkilileri anlık olarak sistemde yapılan işlemleri görüntülerler.

# Login
![image](https://github.com/berkeelm/HDI.RecruitmentProject/assets/48200058/654dfafb-51be-47cd-bac2-9dd7c79d2ebc)

# Dashboard (Firma)
![image](https://github.com/berkeelm/HDI.RecruitmentProject/assets/48200058/da5d40f4-c11c-4bc2-8c77-7a288addd23d)

# Kullanıcı Listesi (Firma)
![image](https://github.com/berkeelm/HDI.RecruitmentProject/assets/48200058/14315fb7-b4fc-463e-99bf-e9b709d9c572)

# Kullanıcı Ekle (Firma)
![image](https://github.com/berkeelm/HDI.RecruitmentProject/assets/48200058/eafc6b2a-d238-4d91-9fd7-14638a255991)

# Ürün Listesi (Firma)
![image](https://github.com/berkeelm/HDI.RecruitmentProject/assets/48200058/7c24840a-9422-4dcc-a9bb-37d3cfa6f6aa)

# Ürün Ekle (Firma)
![image](https://github.com/berkeelm/HDI.RecruitmentProject/assets/48200058/f74448c2-3e29-404f-9e56-47b8531f7187)

# Garanti Tipi Listesi (Firma)
![image](https://github.com/berkeelm/HDI.RecruitmentProject/assets/48200058/bd0c7c8f-2e41-455b-92f1-4e9fcb882403)

# Garanti Tipi Ekle (Firma)
![image](https://github.com/berkeelm/HDI.RecruitmentProject/assets/48200058/f3e78645-1156-4370-9533-904ae4cd8d4d)

# Arıza Listesi (Firma)
![image](https://github.com/berkeelm/HDI.RecruitmentProject/assets/48200058/5618f875-de8c-431b-a91b-35360d1496e3)

# Arıza Ekle (Firma)
![image](https://github.com/berkeelm/HDI.RecruitmentProject/assets/48200058/62929cef-1399-46d6-b77f-45b3dc836352)

# Satış Listesi (Firma, Bayi, Değişim & Tamir Merkezi)
![image](https://github.com/berkeelm/HDI.RecruitmentProject/assets/48200058/a21c1e59-b2f3-409f-9fda-ef3b9712bc1d)

# Garanti Ekle (Bayi)
![image](https://github.com/berkeelm/HDI.RecruitmentProject/assets/48200058/59ca9118-3180-4f59-92e8-b32f7fbb4749)

# Satış Geçmişi (Firma, Bayi, Değişim & Tamir Merkezi)
![image](https://github.com/berkeelm/HDI.RecruitmentProject/assets/48200058/62958e73-9f57-4a39-996c-4a1e27504551)

# Ürün Arızası Ekle (Değişim & Tamir Merkezi)
![image](https://github.com/berkeelm/HDI.RecruitmentProject/assets/48200058/99b978a2-2138-4603-bd41-76b83cd72cce)

# Satış Ekle (Bayi)
![image](https://github.com/berkeelm/HDI.RecruitmentProject/assets/48200058/4764a786-d75c-483a-9990-9cef9502c18d)
