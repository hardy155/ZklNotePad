using NotePad.Model;
using NotePad.ViewModels;
using NotePad.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NotePad.ViewModel
{
    public class MainViewModel : BindableBase
    {
        
        public DocumentModel Document { get; private set; }
        public AboutViewModel About { get; }
        public FileViewModel File { get; }
        public FormatViewModel Format { get;  }

       
        public MainViewModel( DocumentModel model ,IDialogService service)
        {
            Document = model;
            Format=new FormatViewModel(Document,service);
            About = new AboutViewModel(service);
            File = new FileViewModel(Document);
           
           }

    }
}
