namespace registration
{
    public class ListTransaction
    {
        public ListTransaction()
        {
        }

        public ListTransaction(ListItemViewModel listItem, int transactionAtIndex = 0, string transactionType = "")
        {
            item = listItem;
            TransactionType = transactionType;
            TransactionAtIndex = transactionAtIndex;
        }

        public string TransactionType
        {
            get;
            set;
        }

        public int TransactionAtIndex
        {
            get;
            set;
        }

        public ListItemViewModel item
        {
            get;
            set;
        }
    }
}
