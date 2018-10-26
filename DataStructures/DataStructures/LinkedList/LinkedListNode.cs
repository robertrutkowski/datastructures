namespace DataStructures.LinkedList
{
    public class LinkedListNode<T>
    {
        public T Item { get; private set; }
        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode(T item)
        {
            this.Item = item;
        }
    }
}
