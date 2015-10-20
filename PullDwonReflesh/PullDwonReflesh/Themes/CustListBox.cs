using System.Windows;
using System.Windows.Controls;

namespace PullDwonReflesh
{
    [TemplatePart(Name = CustListBox.ScrollViewerPart, Type = typeof(ScrollViewer))]
    public class CustListBox : ListBox
    {
        public const string ScrollViewerPart = "ScrollViewer";

        public CustListBox()
        {
            this.DefaultStyleKey = typeof(CustListBox);
        }

        #region AutoScrollMargin DependencyProperty

        public static readonly DependencyProperty AutoScrollMarginProperty = DependencyProperty.Register(
            "AutoScrollMargin", typeof(int), typeof(CustListBox), new PropertyMetadata(32));

        public double AutoScrollMargin
        {
            get
            {
                return (int)this.GetValue(CustListBox.AutoScrollMarginProperty);
            }
            set
            {
                this.SetValue(CustListBox.AutoScrollMarginProperty, value);
            }
        }

        #endregion
    }
}
