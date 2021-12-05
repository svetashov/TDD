using System.Collections.Generic;

namespace LruCache
{
    public class LruCache<K, V> : ILruCache<K, V>
    {
        private readonly int _maxSize;
        private readonly Dictionary<K, LinkedListNode<LruCacheNode<K, V>>> _nodesDict;
        private readonly LinkedList<LruCacheNode<K, V>> _priorityList;

        public LruCache(int size)
        {
            _maxSize = size;
            _nodesDict = new Dictionary<K, LinkedListNode<LruCacheNode<K, V>>>();
            _priorityList = new LinkedList<LruCacheNode<K, V>>();
        }

        public V this[K key] 
        { 
            get
            {
                if (_priorityList.Count == 0)
                {
                    throw new CacheEmptyException();
                }
                return _nodesDict[key].Value.Value;
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public V Add(K key, V value)
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(K key)
        {
            throw new System.NotImplementedException();
        }

        public int Count()
        {
            throw new System.NotImplementedException();
        }
    }
}