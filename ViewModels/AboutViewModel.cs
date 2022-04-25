using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotePad.ViewModels
{
    public class AboutViewModel:BindableBase
    {
        private readonly IDialogService dialogService;
        public DelegateCommand HelpCommand { get;}
        public AboutViewModel(IDialogService service)
        {
            dialogService = service;
            HelpCommand = new DelegateCommand(OnHelpCommand);
            
        }
        private void OnHelpCommand()
        {
            dialogService.ShowDialog("Author");
        }
        
    }
}
