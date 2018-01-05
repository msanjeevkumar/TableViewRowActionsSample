using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
namespace registration.iOS
{
    public class CustomiOSListViewSource : UITableViewSource
    {
        private readonly NSString _cellIdentifier = new NSString("TableCell");
        private CustomListView _customListView;
        private List<ListItemViewModel> _tableItems;

        public CustomiOSListViewSource(CustomListView customListView)
        {
            this._customListView = customListView;
            Items = new List<ListItemViewModel>();
        }

        public List<ListItemViewModel> Items
        {
            get
            {
                return _tableItems;
            }

            set
            {
                _tableItems = value;
            }
        }

        public override UITableViewRowAction[] EditActionsForRow(UITableView tableView, NSIndexPath indexPath)
        {
            var delete = UITableViewRowAction.Create(UITableViewRowActionStyle.Destructive, "X", (arg1, arg2) =>
            {
                _customListView.NotifyDeleteItemSelected(indexPath.Section);
            });

            var reduce = UITableViewRowAction.Create(UITableViewRowActionStyle.Normal, "-1", (arg1, arg2) =>
            {
                _customListView.NotifyReduceQuantitySelected(indexPath.Section);
            });

            reduce.BackgroundColor = UIColor.FromRGB(95, 95, 95);
            delete.BackgroundColor = UIColor.Red;
            return new UITableViewRowAction[] { delete, reduce };
        }

        public override UISwipeActionsConfiguration GetTrailingSwipeActionsConfiguration(UITableView tableView, NSIndexPath indexPath)
        {
            var delete = UIContextualAction.FromContextualActionStyle(UIContextualActionStyle.Destructive, "X", (action, sourceView, completionHandler) =>
            {
                _customListView.NotifyDeleteItemSelected(indexPath.Section);
                completionHandler(true);
            });

            var reduce = UIContextualAction.FromContextualActionStyle(UIContextualActionStyle.Normal, "-1", (action, sourceView, completionHandler) =>
            {
                _customListView.NotifyReduceQuantitySelected(indexPath.Section);
                completionHandler(true);
            });

            reduce.BackgroundColor = UIColor.FromRGB(95, 95, 95);
            delete.BackgroundColor = UIColor.Red;
            var swipeAction = UISwipeActionsConfiguration.FromActions(new UIContextualAction[] { delete, reduce });
            swipeAction.PerformsFirstActionWithFullSwipe = false;
            return swipeAction;
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return _tableItems.Count;
        }

        #region user interaction methods

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            Console.WriteLine("Row " + indexPath.Section.ToString() + " selected");
            tableView.DeselectRow(indexPath, true);
        }

        public override void RowDeselected(UITableView tableView, NSIndexPath indexPath)
        {
            Console.WriteLine("Row " + indexPath.Section.ToString() + " deselected");
        }

        #endregion

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            // request a recycled cell to save memory
            NativeiOSListViewCell cell = tableView.DequeueReusableCell(_cellIdentifier) as NativeiOSListViewCell;

            // if there are no cells to reuse, create a new one
            if (cell == null)
            {
                cell = new NativeiOSListViewCell(_cellIdentifier);
            }

            var item = _tableItems[indexPath.Section];
            cell.UpdateCell(item.Title, item.Detail);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return 1;
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
            {
                return ((UIScreen.MainScreen.Bounds.Size.Width - 20) * 100) / 602;
            }

            return 100 * UIScreen.MainScreen.Bounds.Size.Height / 1536;
        }

        public override nfloat GetHeightForFooter(UITableView tableView, nint section)
        {
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
            {
                return 5;
            }

            return 10 * UIScreen.MainScreen.Bounds.Size.Height / 1536;
        }

        public override UIView GetViewForFooter(UITableView tableView, nint section)
        {
            return new UILabel { BackgroundColor = UIColor.Clear };
        }
    }
}