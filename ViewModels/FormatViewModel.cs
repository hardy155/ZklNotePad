using NotePad.Model;
using NotePad.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NotePad.ViewModel
{
    public class FormatViewModel:BindableBase
    {
        private readonly IDialogService dialogService;

        public DocumentModel Document { get; set; }
        public FontModel Font { get; set; }
        public DelegateCommand WrapCommand { get; }
        public DelegateCommand FontSettingCommand { get;  }
        public FormatViewModel( DocumentModel model, IDialogService service)
        {
            Document = model;
            Font = new FontModel();
            dialogService= service;
            FontSettingCommand=new DelegateCommand(OnFormatCommand);
            WrapCommand= new DelegateCommand(OnWrapCommand);
        }
        private void OnFormatCommand()
        {
            DialogParameters param = new DialogParameters();
            param.Add("FontModel", Font);
            dialogService.ShowDialog("Font", param, arg =>
            {
               if(arg.Result==ButtonResult.OK)
                {
                   Font= arg.Parameters.GetValue<FontModel>("result");
                }
            });
        }
        private void OnWrapCommand()
        {
            if(Font.TextWrapping==TextWrapping.Wrap)
            {
                Font.TextWrapping = TextWrapping.NoWrap;
            }
            else
            {
                Font.TextWrapping=TextWrapping.Wrap;
            }

        }

    }
}
