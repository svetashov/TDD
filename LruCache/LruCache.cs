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
                _nodesDict[key].Value.Value = value;
            }
        }

        public V Add(K key, V value)
        {
            var node = _priorityList.AddFirst(new LruCacheNode<K, V>(key, value));
            _nodesDict.Add(key, node);

            if (_priorityList.Count > _maxSize)
            {
                _nodesDict.Remove(_priorityList.Last.Value.Key);
                _priorityList.RemoveLast();
            }

            return value;
        }

        public bool Contains(K key)
        {
            throw new System.NotImplementedException();
        }

        public int Count()
        {
            return _priorityList.Count;
        }
    }
}