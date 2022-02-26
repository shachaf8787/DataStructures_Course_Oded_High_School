using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures_Course_Oded_High_School
{
    class BinNode<T>
    {
        private BinNode<T> right;
        private T value;
        private BinNode<T> left;

        public BinNode(BinNode<T> left, T value, BinNode<T> right)
        {
            this.left = left;
            this.value = value;
            this.right = right;
        }

        public BinNode<T> GetLeft()
        {
            return this.left;
        }
        public T GetValue()
        {
            return this.value;
        }
        public BinNode<T> GetRight()
        {
            return this.right;
        }
        public void SetLeft(BinNode<T> left)
        {
            this.left = left;
        }
        public void SetValue(T value)
        {
            this.value = value;
        }
        public void SetRight(BinNode<T> right)
        {
            this.right = right;
        }
        public bool HasLeft()
        {
            return this.left != null;
        }
        public bool HasRight()
        {
            return this.right != null;
        }
        public override string ToString()
        {
            return this.value + " --> " + this.right;
        }

    }
}
