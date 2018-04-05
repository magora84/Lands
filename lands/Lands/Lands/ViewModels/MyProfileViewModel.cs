using GalaSoft.MvvmLight.Command;
using Lands.Helpers;
using Lands.Models;
using Lands.Servicios;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lands.ViewModels
{
   public class MyProfileViewModel:BaseViewModel
    {
        #region services
        private ApiService apiService;
        #endregion
        #region Atributtos
        private bool isRunning;
        private bool isEnabled;
        private ImageSource imageSource;
        private MediaFile file;
        #endregion
        #region Properties
        public UserLocal User { get; set; }
        public ImageSource ImageSource {
            get { return this.imageSource; }
            set { SetValue(ref this.imageSource, value); }
        }

        public bool IsEnabled {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }

        public bool IsRunning {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        #endregion
        #region Constructor
        public MyProfileViewModel() {
            this.apiService = new ApiService();
            this.User = MainViewModel.GetInstance().User;
            this.ImageSource = this.User.ImageFullPath;
            this.IsEnabled = true;
            
        }
        #endregion

        #region Comandos
        public ICommand ChangeImageCommand {
            get {
                return new RelayCommand(ChangeImage);
            }
        }

        private async void ChangeImage() {
            await CrossMedia.Current.Initialize();

            if (CrossMedia.Current.IsCameraAvailable &&
                CrossMedia.Current.IsTakePhotoSupported) {
                var source = await Application.Current.MainPage.DisplayActionSheet(
                    Languages.SourceImageQuestion,
                    Languages.Cancel,
                    null,
                    Languages.FromGallery,
                    Languages.FromCamera);

                if (source == Languages.Cancel) {
                    this.file = null;
                    return;
                }

                if (source == Languages.FromCamera) {
                    this.file = await CrossMedia.Current.TakePhotoAsync(
                        new StoreCameraMediaOptions {
                            Directory = "Sample",
                            Name = "test.jpg",
                            PhotoSize = PhotoSize.Small,
                        }
                    );
                }
                else {
                    this.file = await CrossMedia.Current.PickPhotoAsync();
                }
            }
            else {
                this.file = await CrossMedia.Current.PickPhotoAsync();
            }

            if (this.file != null) {
                this.ImageSource = ImageSource.FromStream(() => {
                    var stream = file.GetStream();
                    return stream;
                });
            }
        }
        #endregion
    }
}
