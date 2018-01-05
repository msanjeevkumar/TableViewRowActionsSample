using System;
using Foundation;
using UIKit;

namespace registration.iOS
{
    public class NativeiOSListViewCell : UITableViewCell
    {
        private string _price;

        public NativeiOSListViewCell(NSString cellId) : base(UITableViewCellStyle.Value1, cellId)
        {
        }

        internal void UpdateCell(string title, string detail)
        {
            this.TextLabel.Text = title;
            this.DetailTextLabel.Text = detail;
        }
    }
}