namespace LruCache
{
    internal class LruCacheNode<K, V>
    {
        public LruCacheNode(K key, V value)
        {
            Key = key;
            Value = value;
        }

        public K Key { get; }
        public V Value { get; set; }
    }
}