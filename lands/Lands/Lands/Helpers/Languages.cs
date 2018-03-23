
namespace Lands.Helpers
{
    using Xamarin.Forms;
    using Interfaces;
    using Resources;

    public static class Languages {
        static Languages() {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();

            Resource.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Accept {
            get { return Resource.Accept; }
        }

        public static string EmailValidation {
            get { return Resource.EmailValidation; }
        }

        public static string Error {
            get { return Resource.Error; }
        }
        public static string EmailPlaceHolder {
            get { return Resource.EmailPlaceHolder; }
        }
        public static string Rememberme {
            get { return Resource.Rememberme; }
        }
        public static string Menu {
            get { return Resource.Menu; }
        }
        public static string MyProfile {
            get { return Resource.MyProfile; }
        }
        public static string Statics {
            get { return Resource.Statics; }
        }
        public static string LogOut {
            get { return Resource.LogOut; }
        }

        public static string RegisterTitle {
            get { return Resource.RegisterTitle; }
        }

        public static string ChangeImage {
            get { return Resource.ChangeImage; }
        }

        public static string FirstNameLabel {
            get { return Resource.FirstNameLabel; }
        }

        public static string FirstNamePlaceHolder {
            get { return Resource.FirstNamePlaceHolder; }
        }

        public static string FirstNameValidation {
            get { return Resource.FirstNameValidation; }
        }

        public static string LastNameLabel {
            get { return Resource.LastNameLabel; }
        }

        public static string LastNamePlaceHolder {
            get { return Resource.LastNamePlaceHolder; }
        }

        public static string LastNameValidation {
            get { return Resource.LastNameValidation; }
        }

        public static string PhoneLabel {
            get { return Resource.PhoneLabel; }
        }

        public static string PhonePlaceHolder {
            get { return Resource.PhonePlaceHolder; }
        }

        public static string PhoneValidation {
            get { return Resource.PhoneValidation; }
        }

        public static string ConfirmLabel {
            get { return Resource.ConfirmLabel; }
        }

        public static string ConfirmPlaceHolder {
            get { return Resource.ConfirmPlaceHolder; }
        }

        public static string ConfirmValidation {
            get { return Resource.ConfirmValidation; }
        }

        public static string EmailValidation2 {
            get { return Resource.EmailValidation2; }
        }

        public static string PasswordValidation2 {
            get { return Resource.PasswordValidation2; }
        }

        public static string ConfirmValidation2 {
            get { return Resource.ConfirmValidation2; }
        }

        public static string UserRegisteredMessage {
            get { return Resource.UserRegisteredMessage; }
        }

        public static string SourceImageQuestion {
            get { return Resource.SourceImageQuestion; }
        }

        public static string Cancel {
            get { return Resource.Cancel; }
        }

        public static string FromGallery {
            get { return Resource.FromGallery; }
        }

        public static string FromCamera {
            get { return Resource.FromCamera; }
        }

        public static string Save {
            get { return Resource.Save; }
        }

        public static string ChangePassword {
            get { return Resource.ChangePassword; }
        }

        public static string CurrentPassword {
            get { return Resource.CurrentPassword; }
        }

        public static string CurrentPasswordPlaceHolder {
            get { return Resource.CurrentPasswordPlaceHolder; }
        }

        public static string NewPassword {
            get { return Resource.NewPassword; }
        }

        public static string NewPasswordPlaceHolder {
            get { return Resource.NewPasswordPlaceHolder; }
        }

        public static string ConnectionError1 {
            get { return Resource.ConnectionError1; }
        }

        public static string ConnectionError2 {
            get { return Resource.ConnectionError2; }
        }

        public static string LoginError {
            get { return Resource.LoginError; }
        }

        public static string ChagePasswordConfirm {
            get { return Resource.ChagePasswordConfirm; }
        }

        public static string IncorrectPassword {
            get { return Resource.IncorrectPassword; }
        }
    }
}
