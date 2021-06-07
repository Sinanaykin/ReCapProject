using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages //oya-cakmak,merve-esen
    {
      
        public static string CarDescriptionMinTwoCharacters = "Araba ismi minimum 2 karakter olmalıdır.";
        public static string DailyPriceBiggerThanZero = "Fiyat 0'dan büyük olmalıdır.";
        public static string ReturnDateIsNull = "Araba teslim edilmediği için kiralanamaz.";
        public static string CarRented = "Araba kiralandı.";

        public static string BrandAdded = "Marka eklendi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandListed = "Marka listelendi";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorListed = "Renk listelendi";

        public static string CarAdded = "Araç eklendi";
        public static string CarUpdated = "Araç güncellendi";
        public static string CarDeleted = "Araç silindi";
        public static string CarListed = "Araç listelendi";
        public static string CarNameInValid = "Araç ismi geçersiz";
        public static string CarDailyPriceInValid = "Günlük fiyatı 0 dan büyük olmalıdır.";
        public static string MaintenanceTime = "Sistem bakımda";

        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserListed = "Kullanıcı listelendi";

        public static string CustomerAdded = "Müsteri eklendi";
        public static string CustomerUpdated = "Müsteri güncellendi";
        public static string CustomerDeleted = "Müsteri silindi";
        public static string CustomerListed = "Müsteri listelendi";

        public static string RentalAdded = "Kiralama bilgisi eklendi";
        public static string RentalUpdated = "Kiralama bilgisi güncellendi";
        public static string RentalDeleted = "Kiralama bilgisi silindi";
        public static string RentalReturnDateError = "Araç teslim edilmemiştir.";


        
        
        public static string AllCarImages = "Araç resmi Listelendi";

      
  

        public static string CarImageAdded = "Araç resmi eklendi";
        public static string CarImageLimit = "Araç resmi en fazla 5 tane olabilir";
        public static string CarImageDeleted = "Araç resmi silindi";
        public static string CarImageUpdated = "Araç resmi güncellendi";
        public static string CarImageNotFound = "Araç resmi bulunamadı";





        public static string AuthorizationDenied = "Yekiniz yok";
        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string SuccessfulLogin = "Başarılı giriş";
    }
}