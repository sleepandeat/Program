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
using Microsoft.Phone.Controls;

using System.Threading;
using System.Collections.ObjectModel;
using System.Collections;

namespace PullDwonReflesh
{
    public partial class MainPage : PhoneApplicationPage
    {
        private Timer refreshTimer;
        private ObservableCollection<string> DemoData;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            DemoData = new ObservableCollection<string>();

            AddString(0, 40);
            this.custListBox.DataContext = this.DemoData;
        }

        private void refreshPanel_RefreshRequested(object sender, EventArgs e)
        {
            this.custListBox.IsRefreshing = true;
            this.refreshTimer = new Timer(
                delegate
                {
                    // Reload the list, on the UI thread.
                    this.Dispatcher.BeginInvoke(
                        delegate
                        {
                            Refresh();
                            this.custListBox.DataContext = this.DemoData;
                            this.custListBox.IsRefreshing = false;
                        });
                },
                null, 3000, -1);
        }

        private void Refresh()
        {
            DemoData.Clear();
            index = 0;
            string buf = "被刷了 = =! ";
            for (int i = 0; i < 20; i++)
            {
                DemoData.Add(buf);
            }
        }

        private void AddString(int statnum, int num)
        {
            string buf = "Good night ! ";
            for (int i = 0; i < num; i++)
            {
                DemoData.Add(buf + ++index);
            }
        }
        //加载
        private int index = 0;
        private bool _IsHookedScrollEvent = false;
        private ScrollViewer _ScrollViewer = null;

        private VisualStateGroup FindVisualState(FrameworkElement element, string name)
        {
            if (element == null)
                return null;

            IList groups = VisualStateManager.GetVisualStateGroups(element);
            foreach (VisualStateGroup group in groups)
            {
                if (group.Name == name)
                    return group;
            }

            return null;
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (_IsHookedScrollEvent)
                return;
            _ScrollViewer = App._ScrollViewer;
            if (_ScrollViewer != null)
            {
                _IsHookedScrollEvent = true;
                FrameworkElement element = VisualTreeHelper.GetChild(_ScrollViewer, 0) as FrameworkElement;
                if (element != null)
                {
                    VisualStateGroup visualStateGroup = FindVisualState(element, "ScrollStates");
                    visualStateGroup.CurrentStateChanged += new EventHandler<VisualStateChangedEventArgs>(visualStateGroup_CurrentStateChanged);
                }
            }
        }

        void visualStateGroup_CurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            var visualState = e.NewState.Name;
            if (visualState == "NotScrolling")
            {
                var v1 = _ScrollViewer.ExtentHeight - _ScrollViewer.VerticalOffset;
                var v2 = _ScrollViewer.ViewportHeight * 1.5;

                if (v1 <= v2 && !custListBox.IsRefreshing)
                {
                    AddString(index, 20);
                    visualState += "_End";
                }
            }
        }
    }
}