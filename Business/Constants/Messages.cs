namespace Business.Constants
{
    public class Messages
    {
        public static string UserFirstNameNotEmpty = "Ad boş bırakılamaz";
        public static string UserFirstNameMinimumLength = "Ad en az 2 karakterden oluşmalı";
        public static string UserFirstNameMaximumLength = "Ad en fazla 20 karakterden oluşabilir";
        public static string UserLastNameNotEmpty = "Soyad boş bırakılamaz";
        public static string UserLastNameMinimumLength = "Soyad en az 2 karakterden oluşmalı";
        public static string UserLastNameMaximumLength = "Soyad en fazla 20 karakterden oluşabilir";
        public static string UserEmailNotEmpty = "E-posta boş bırakılamaz";
        public static string UserEmailEmailAddress = "Geçersiz e-posta adresi";
        public static string UserPasswordNotEmpty = "Şifre boş bırakılamaz";
        public static string UserPasswordMinimumLength = "Şifre en az 8 karakterden oluşmalı";
        public static string UserPasswordMaximumLength = "Şifre en fazla 50 karakterden oluşabilir";

        public static string CommentContentNotEmpty = "Yorum boş bırakılamaz";
        public static string CommentContentMinimumLength = "Yorum en az 5 karakterden oluşmalı";
        public static string CommentContentMaximumLength = "Yorum en fazla 500 karakterden oluşabilir";

        public static string ContactSubjectNotEmpty = "Konu boş bırakılamaz";
        public static string ContactSubjectMinimumLength = "Konu en az 5 karakterden oluşmalı";
        public static string ContactSubjectMaximumLength = "Konu en fazla 50 karakterden oluşabilir";
        public static string ContactMessageNotEmpty = "Mesaj boş bırakılamaz";
        public static string ContactMessageMinimumLength = "Mesaj en az 10 karakterden oluşmalı";
        public static string ContactMessageMaximumLength = "Mesaj en fazla 1000 karakterden oluşabilir";

        public static string BlogTitleNotEmpty = "Başlık boş bırakılamaz";
        public static string BlogTitleMinimumLength = "Başlık en az 5 karakterden oluşmalı";
        public static string BlogTitleMaximumLength = "Başlık en fazla 100 karakterden oluşabilir";
        public static string BlogContentNotEmpty = "İçerik boş bırakılamaz";
        public static string BlogContentMinimumLength = "İçerik en az 100 karakterden oluşmalı";
        public static string BlogImageUrlNotEmpty = "Ana resim seçilmedi";
        public static string BlogThumbnailImageUrlNotEmpty = "Yan resim seçilmedi";
        public static string CategoryIdNotEmpty = "Kategori seçilmedi";
        public static string CategoryIdGreaterThan = "Geçersiz kategori";

        public static string WriterAboutMinimumLength = "Hakkımda en az 5 karakterden oluşmalı";
        public static string WriterAboutMaximumLength = "Hakkımda en fazla 500 karakterden oluşabilir";
	}
}
