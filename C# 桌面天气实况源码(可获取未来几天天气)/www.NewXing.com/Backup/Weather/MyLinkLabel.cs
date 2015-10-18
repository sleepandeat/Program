using System;
using System.Collections.Generic;
using System.Text;

namespace Weather
{
    class MyLinkLabel:System.Windows.Forms.LinkLabel
    {
        public bool Selectable
        {
            get { return this.GetStyle(System.Windows.Forms.ControlStyles.FixedHeight); }
            set { this.SetStyle(System.Windows.Forms.ControlStyles.Selectable, value); }
        }
    }
}
