using System.Collections;
using System;

namespace LinkedList
{
    class LinkedList
    {
        private ListNode head;
        private ListNode tail;
        private int size;

        public LinkedList()
        {
            size = 0;
        }
        public string GetFirst()
        {
            return head.GetValue();
        }

        public string GetLast()
        {
            return tail.GetValue();
        }

        public int GetSize()
        {
            return size;
        }

        private bool CheckIndex(int index) {
            if(index >= 0 || index < size) {
                return false;
            }
            else {
                return true;
            }
        }
        
         private ListNode GetNodeByIndex(int index)
        {
            if(CheckIndex (index)) {
                return null;
            }

            ListNode nextNode = head;
            for (int i = 0; i < index; i++)
            {
                nextNode = nextNode.GetNextNode();
            }

            return nextNode;
        }

        public void Add(string value)
        {
            ListNode newNode = new ListNode(value);
            if (tail == null)
            {
                head = newNode;
            }
            else
            {
                tail.SetNextNode(newNode);
            }
            tail = newNode;
            size++;
        }

        public void AddFirst(string value)
        {
            ListNode newNode = new ListNode(value);
            if (head != null)
            {
                newNode.SetNextNode(head);
            }
            head = newNode;
            size++;
        }

        public void DeleteElement(int index)
        {
            if(CheckIndex(index)) {
                return;
            }

            size--;

            if (index == 0)
            {
                head = head.GetNextNode();
                return;
            }

            ListNode node = GetNodeByIndex(index - 1);
            node.SetNextNode(node.GetNextNode().GetNextNode());
        }

        public void ChangeElement(int index, string value)
        {
            if(CheckIndex(index)) {
                return;
            }
            GetNodeByIndex(index).SetValue(value);
        }
    }
}