public class CacheOverflowException : Exception
{
    public CacheOverflowException(string message) : base(message) {}
}

public class Cache<K, V>
{
    private readonly int _maxSize;
    private readonly LinkedList<(K key, V value)> _items; 
    private readonly Dictionary<K, LinkedListNode<(K key, V value)>> _map;
    
    public Cache(int maxSize)
    {
        if (maxSize <= 0) 
            throw new ArgumentException("Максимальный размер кэша должен быть больше нуля.");
        
        _maxSize = maxSize;
        _items = new LinkedList<(K, V)>();
        _map = new Dictionary<K, LinkedListNode<(K key, V value)>>();
    }

    public void Add(K key, V value)
    {
        // Если ключ уже есть — удаляем старый нод, чтобы обновить порядок
        if (_map.TryGetValue(key, out var existingNode))
        {
            _items.Remove(existingNode);
            _map.Remove(key);
        }
        else if (_items.Count == _maxSize)
        {
            // FIFO: удаляем самый старый (первый в списке)
            var oldest = _items.First;
            if (oldest == null)
                throw new CacheOverflowException("Невозможно добавить элемент: кэш переполнен и не удалось удалить старейший элемент.");

            _map.Remove(oldest.Value.key);
            _items.RemoveFirst();
        }

        var node = _items.AddLast((key, value));
        _map[key] = node;
    }

    public bool TryGet(K key, out V value)
    {
        if (_map.TryGetValue(key, out var node))
        {
            value = node.Value.value;
            return true;
        }

        value = default;
        return false;
    }

    public void Remove(K key)
    {
        if (_map.TryGetValue(key, out var node))
        {
            _items.Remove(node);
            _map.Remove(key);
        }
    }

    public int Count => _items.Count;

    public void Clear()
    {
        _items.Clear();
        _map.Clear();
    }
}

// Пример проверки работы
public static class Program
{
    public static void Main()
    {
        var cache = new Cache<string,int>(3);
        cache.Add("one", 1);
        cache.Add("two", 2);
        cache.Add("three", 3);

        if (cache.TryGet("two", out int val))
            Console.WriteLine($"Значение для 'two': {val}");
        else
            Console.WriteLine("Ключ 'two' не найден");

        // Должно удалить "one"
        cache.Add("four", 4);

        if (cache.TryGet("one", out val))
            Console.WriteLine($"Значение для 'one': {val}");
        else
            Console.WriteLine("Ключ 'one' не найден");
        
        if (cache.TryGet("four", out val))
            Console.WriteLine($"Значение для 'four': {val}");
        else
            Console.WriteLine("Ключ 'four' не найден");
        
        Console.WriteLine($"Count: {cache.Count}");
        cache.Clear();
        Console.WriteLine($"Count after Clear: {cache.Count}");
    }
}
