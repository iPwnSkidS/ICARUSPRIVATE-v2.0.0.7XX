using System.Collections;
using System.Windows.Forms;

namespace ShitarusPrivate
{
    public class ListViewColumnSorter : IComparer
    {
        private int _columnToSort;

        private SortOrder _orderOfSort;

        private readonly CaseInsensitiveComparer _objectCompare;

        public int SortColumn
        {
            get
            {
                return _columnToSort;
            }
            set
            {
                _columnToSort = value;
            }
        }

        public SortOrder Order
        {
            get
            {
                return _orderOfSort;
            }
            set
            {
                _orderOfSort = value;
            }
        }

        public ListViewColumnSorter()
        {
            _columnToSort = 0;
            _orderOfSort = SortOrder.None;
            _objectCompare = new CaseInsensitiveComparer();
        }

        public int Compare(object x, object y)
        {
            ListViewItem listViewItem = (ListViewItem)x;
            ListViewItem listViewItem2 = (ListViewItem)y;
            if (!(listViewItem.SubItems[0].Text == "..") && !(listViewItem2.SubItems[0].Text == ".."))
            {
                int num = _objectCompare.Compare(listViewItem.SubItems[_columnToSort].Text, listViewItem2.SubItems[_columnToSort].Text);
                if (_orderOfSort == SortOrder.Ascending)
                {
                    return num;
                }
                if (_orderOfSort == SortOrder.Descending)
                {
                    return -num;
                }
                return 0;
            }
            return 0;
        }
    }
}