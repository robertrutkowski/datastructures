namespace DataStructures.HashTable
{
    public class HashTableNodePair<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public HashTableNodePair(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
            this.Value = value;
        }
    }
}
