namespace P09.LinkedListTraversal
{
    using System.Collections;
    using System.Collections.Generic;

    public class CustomLinkedList<T> : IEnumerable<T>
    {
        private Node<T> Head;

        public int Count { get; private set; }

        public CustomLinkedList(Node<T> head)
        {
            this.Head = head;
            this.Count = 1;
        }

        public CustomLinkedList()
        {

        }

        public void Add(T element)
        {
            Node<T> newNode = new Node<T>(element);

            Node<T> currentNode = this.Head;

            while (currentNode.NextNode != null)
            {
                currentNode = currentNode.NextNode;
            }
            this.Count++;
            newNode.PreviousNode = currentNode;
            currentNode.NextNode = newNode;
        }

        public void Remove(T element)
        {
            Node<T> parent = null;
            Node<T> current = this.Head;

            while (current != null)
            {
                if (current.Value.Equals(element))
                {
                    if (current == this.Head)
                    {
                        this.Head = this.Head.NextNode;
                        this.Head.PreviousNode = null;
                    }
                    else
                    {
                        current.PreviousNode.NextNode = current.NextNode;
                        current.NextNode.PreviousNode = current.PreviousNode;
                    }
                    this.Count--;
                    return;
                }

                current = current.NextNode;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = this.Head;

            while (current != null)
            {
                yield return current.Value;
                current = current.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class Node<T>
    {
        public T Value;
        public Node<T> PreviousNode;
        public Node<T> NextNode;

        public Node(T value)
        {
            this.Value = value;
        }
    }
}
