using Microsoft.Win32;
using NotePad.Model;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace NotePad.ViewModel
{
    public class FileViewModel:BindableBase
    {
        public DocumentModel Document { get; private set; }
        public DelegateCommand NewFileCommand { get; }
        public DelegateCommand OpenFileCommand { get; }
        public DelegateCommand SaveCommand { get; }
        public DelegateCommand SaveAsCommand { get; }
        public DelegateCommand ExitCommand { get; }
        public FileViewModel(DocumentModel documentModel)
        {
            Document = documentModel;
            NewFileCommand = new DelegateCommand(OnNewFile);
            OpenFileCommand=new DelegateCommand(OnOpenFile);
            SaveCommand =new DelegateCommand(OnSave,()=>!Document.IsEmpty);
            SaveAsCommand=new DelegateCommand(OnSaveAs);
            ExitCommand = new DelegateCommand(OnExit);
        }
        private void OnOpenFile()
        {
            var openfiledialog=new OpenFileDialog();
            if(openfiledialog.ShowDialog()==true)
            {
                DockFile(openfiledialog);
                Document.Text=File.ReadAllText(openfiledialog.FileName);
            }

        }
        private void OnNewFile()
        {
            Document.Filename = String.Empty;
            Document.FilePath = String.Empty;
            Document.Text = String.Empty;
        }
        private void OnSave()
        {
           
                File.WriteAllText(Document.FilePath, Document.Text);
            
         }
        private void OnSaveAs()
        {
            var savefiledialog = new SaveFileDialog();
            savefiledialog.Filter= "Text File (.txt)|*.txt";
            if(savefiledialog.ShowDialog()==true)
            {
                DockFile(savefiledialog);
                File.WriteAllText(savefiledialog.FileName, Document.Text);
            }

        }
        private void OnExit()
        {
            Application.Current.Shutdown();
        }
       
        private void DockFile<T>(T dialog) where T:FileDialog
        {
            Document.FilePath= dialog.FileName;
            Document.Filename = dialog.SafeFileName;
        }
    }

}