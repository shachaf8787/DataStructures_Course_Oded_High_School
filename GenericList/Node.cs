using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures_Course_Oded_High_School
{
    class Node<T>
    {
        private T value;
        private Node<T> next;

        public Node(T value)
        {
            this.value = value;
            this.next = null;
        }
        public Node(T value, Node<T> next)
        {
            this.value = value;
            this.next = next;
        }
        public T GetValue()
        {
            return this.value;
        }
        public Node<T> GetNext()
        {
            return this.next;
        }
        public void SetValue(T value)
        {
            this.value = value;
        }
        public void SetNext(Node<T> next)
        {
            this.next = next;
        }
        public bool HasNext()
        {
            if (this.next == null)
                return false;
            else
                return true;
        }
        public void SetNull()
        {
            this.next = null;
        }
        public override string ToString()
        {
            return this.value + ", " + this.next;
        }
    }
}
