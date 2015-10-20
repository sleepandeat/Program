using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections;

namespace PullDwonReflesh.Themes
{
    public partial class CustListbox : UserControl
    {
        public event SelectionChangedEventHandler SelectionChanged;
        public event EventHandler RefreshRequested;

        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(CustListbox), new PropertyMetadata(""));
        public IEnumerable ItemsSource
        {
            get
            {
                return (IEnumerable)base.GetValue(ItemsSourceProperty);
            }
            set
            {
                base.SetValue(ItemsSourceProperty, value);
            }
        }

        private DataTemplate _ItemTemplate = null;
        public DataTemplate ItemTemplate
        {
            get
            {
                return _ItemTemplate;
            }
            set
            {
                _ItemTemplate = value;
                custListBox.ItemTemplate = value;
            }
        }

        public static readonly DependencyProperty IsRefreshingProperty = DependencyProperty.Register("IsRefreshing", typeof(bool), typeof(CustListbox), new PropertyMetadata(false, (d, e) => ((CustListbox)d).OnIsRefreshingChanged(e)));
        public bool IsRefreshing
        {
            get
            {
                return (bool)this.GetValue(CustListbox.IsRefreshingProperty);
            }
            set
            {
                this.SetValue(CustListbox.IsRefreshingProperty, value);
            }
        }

        protected void OnIsRefreshingChanged(DependencyPropertyChangedEventArgs e)
        {
            this.refreshPanel.IsRefreshing = (bool)e.NewValue;
        }

        public CustListbox()
        {
            InitializeComponent();
        }

        private void CustListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectionChanged != null)
            {
                SelectionChanged(sender, e);
            }
        }

        private void refreshPanel_RefreshRequested(object sender, EventArgs e)
        {
            if (RefreshRequested != null)
            {
                RefreshRequested(sender, e);
            }
        }
    }
}
