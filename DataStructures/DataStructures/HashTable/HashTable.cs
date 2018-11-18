namespace DataStructures.HashTable
{
    public class HashTable<TKey, TValue>
    {
        private readonly float maxFillFactor = 0.75f;
        private int maxCount = 0;

        private HashTableArray<TKey, TValue> array;

        public HashTable(int count)
        {

        }
    }
}
