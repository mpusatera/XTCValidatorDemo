using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XTCValidatorDemo
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            ButtonCommand = new Command(async () => await ButtonExecution());
        }
        public ICommand ButtonCommand { get; set; }
        public ICommand EmailValidatorCommand { get; set; }
        public ICommand PasswordValidatorCommand { get; set; }
        public ICommand RepeatPasswordValidatorCommand { get; set; }
        public bool EmailValid { get; set; } = false;
        public bool PasswordValid { get; set; } = false;
        public bool PasswordMatchValid { get; set; } = false;
        private async Task ButtonExecution()
        {
            try
            {
                if (CheckInputValues())
                {
                    await App.Current.MainPage.DisplayAlert("Success!", "Validation Successful", "Ok");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Invalid!", "One or more entry fields are NOT valid. Please correct and submit again.", "Ok");
                }
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Exception!", $"Error encountered in {MethodBase.GetCurrentMethod().Name}: {e.Message}", "Ok");
            }
        }
        private bool CheckInputValues()
        {
            EmailValidatorCommand.Execute(null);
            PasswordValidatorCommand.Execute(null);
            RepeatPasswordValidatorCommand.Execute(null);
            return EmailValid && PasswordValid && PasswordMatchValid;
        }
    }
}
