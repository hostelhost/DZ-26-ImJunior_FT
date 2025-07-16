using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour, IExistInPool
{
    private Queue<T> _pool = new();
    private T _prefab;

    public int CountActive { get; private set; }
    public int CountTotal { get; private set; }

    public void CreatePool(T prefab)
    {
        _prefab = prefab;
    }

    public T Get()
    {
        T item = _pool.Count > 0 ? _pool.Dequeue() : CreateNew();

        item.gameObject.SetActive(true);
            
        return item;
    }

    public void Release(T item)
    {
        item.gameObject.SetActive(false);
        _pool.Enqueue(item);
    }

    private T CreateNew()
    {
        T instance = UnityEngine.Object.Instantiate(_prefab);
        instance.Initialize(() => Release(instance));
        return instance;
    }
}
