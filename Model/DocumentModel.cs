using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NotePad.Model
{ 
    public class DocumentModel:BindableBase
    {
        private string text;
        private string filepath;
        private string filename;
        public string Text { get { return text; } set { SetProperty(ref text, value); } }
        public string FilePath { get { return filepath; } set { SetProperty(ref filepath, value); } }
        public string Filename { get { return filename; } set { SetProperty(ref filename, value); } }
        public bool IsEmpty { get { if (string.IsNullOrEmpty(FilePath)||string.IsNullOrEmpty(Filename)) return true; return false; } }
      
       
        
    }
}
