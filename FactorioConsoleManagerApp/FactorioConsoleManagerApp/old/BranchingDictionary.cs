using System;
using System.Runtime.Serialization;
using System.Text;

namespace System.Collections.Generic
{
    public class BranchingDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary<TKey, TValue>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>, IReadOnlyDictionary<TKey, TValue>, ICollection, IDictionary, IDeserializationCallback, ISerializable
    {
        private readonly dynamic node;

        public BranchingDictionary()
        {
            // Need dynamic node
            // set name of the node to the value of the root
            node = new BranchingDictionary<TKey, BranchingDictionary<TKey, TValue>>();
        }
    }
}
