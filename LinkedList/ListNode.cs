namespace LinkedList
{
    class ListNode
    {
        private string value;
        private ListNode nextNode;

        public string GetValue()
        {
            return value;
        }

        public void SetValue(string value)
        {
            this.value = value;
        }

        public ListNode GetNextNode()
        {
            return nextNode;
        }

        public void SetNextNode(ListNode nextNode) {
            this.nextNode = nextNode;
        }

        public ListNode(string value)
        {
            this.value = value;
        }
    }
}