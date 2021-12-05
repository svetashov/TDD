namespace Tests
{
    public interface ILruCache<K, V>
    {
        V this[K key]
        {
            get; set;
        }

        V Add(K key, V value);

        bool Contains(K key);

        int Count();
    }
}