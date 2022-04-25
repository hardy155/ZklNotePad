using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace NotePad.Model
{
    public class FontModel:BindableBase
    {
        private FontStyle fontstyle;
        private FontFamily fontfamily;
        private TextWrapping textwrapping;
        private bool iswrapped;
        private double size;

        public FontStyle FontStyle { get { return fontstyle; } set { SetProperty(ref fontstyle, value); } }
        public FontFamily FontFamily { get { return fontfamily; } set { SetProperty(ref fontfamily, value); } }
        public TextWrapping TextWrapping { get { return textwrapping; } set { SetProperty(ref textwrapping, value); IsWrapped = value == TextWrapping.Wrap ? true : false; } }
        public bool IsWrapped { get { return iswrapped; } set { SetProperty(ref iswrapped, value); } }
        public double Size { get { return size; } set { SetProperty(ref size, value);} }

    }
}
