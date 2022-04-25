using NotePad.Model;
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
    public class FontViewModel : BindableBase, IDialogAware
    {
        public DelegateCommand ComfirmCommand { get; }
        public DelegateCommand CancelCommand { get; }
        public FontViewModel( )
        {
            ComfirmCommand = new DelegateCommand(OnComfirmCommand);
            CancelCommand = new DelegateCommand(OnCancelCommand);
        }
        private FontModel font ;
        public FontModel Font { get { return font; } set { SetProperty(ref font, value); } }

        private void OnComfirmCommand()
        {
            DialogParameters pairs = new DialogParameters
            {
                { "result", Font }
            };
            RequestClose.Invoke(new DialogResult(ButtonResult.OK, pairs));
        }
        private void OnCancelCommand()
        {
            RequestClose.Invoke(new DialogResult(ButtonResult.Cancel));
        }

        public string Title => "字体设置";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
          Font= parameters.GetValue<FontModel>("FontModel");
        }
    }
}
