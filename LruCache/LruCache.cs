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
                if (!Contains(key))
                {
                    throw new KeyNotFoundException($"Key={key} not found in cache");
                }

                return ActualizeNode(key).Value;
            }
            set
            {
                if (!Contains(key))
                {
                    Add(key, value);
                }
                else
                {
                    ActualizeNode(key).Value = value;
                }
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
            return _nodesDict.ContainsKey(key);
        }

        public int Count()
        {
            return _priorityList.Count;
        }

        private LruCacheNode<K, V> ActualizeNode(K key)
        {
            var node = _nodesDict[key];
            if (_priorityList.First != node)
            {
                _priorityList.Remove(node);
                _priorityList.AddFirst(node);
            }

            return node.Value;
        }
    }
}