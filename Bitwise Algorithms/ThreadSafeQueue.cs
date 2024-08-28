using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitwise_Algorithms
{
    public class ThreadSafeQueue<T>
    {
        private readonly ConcurrentQueue<T> _queue = new ConcurrentQueue<T>();

        public void Enqueue(T item)
        {
            _queue.Enqueue(item);
        }

        public bool TryDequeue(out T item)
        {
            return _queue.TryDequeue(out item);
        }

        public int Count => _queue.Count;
    }
}
