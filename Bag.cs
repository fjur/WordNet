using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordNet
{
    public class Bag<Item> : IEnumerable<Item>
    {
        private Node<Item> first;
        private int n;

        //helper linker list class
        private class Node<Item>
        {
            internal Item item;
            internal Node<Item> next;
        }

        public Bag()
        {
            first = null;
            n = 0;
        }

        public int size()
        {
            return n;
        }

        public void add(Item item)
        {
            Node<Item> oldfirst = first;
            first = new Node<Item>();
            first.item = item;
            first.next = oldfirst;
            n++;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return new ListIterator<Item>(first);
            //return new ListIterator<Item>();

        }

        private class ListIterator<Item> : IEnumerator<Item>
        {
            private Node<Item> _current;
            private Node<Item> _first;

            public Item Current { get { return _current.item; } }

            object IEnumerator.Current { get { return Current; } }

            public ListIterator(Node<Item> first)
            {
                _first = first;
                _current = null;
            }

            public ListIterator()
            {
                _current = null;
            }

            public void Dispose()
            {
                // Dispose of unmanaged resources.
                // Dispose(true);
                // Suppress finalization.
                GC.SuppressFinalize(this);
            }

            public void Reset()
            {
                _current = _first;
            }

            public bool hasNext()
            {
                return _current != null && _current.next != null;
            }

            public bool MoveNext()
            {
                if (_current == null && _first != null)
                {
                    _current = _first;
                    return true;
                }

                if (!hasNext()) return false;
                _current = _current.next;
                return true;
            }
        }
    }
}
