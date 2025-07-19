using UnityEngine;
[RequireComponent(typeof(Transform))]

public abstract class Attacker<T> : MonoBehaviour where T : MonoBehaviour, IExistInPool
{
    [SerializeField] private T _bulletPrefab;
    [SerializeField] protected Vector3 _pointOfShot;
    
    protected Transform _thisTransform;
    protected Pool<T> _pool = new();

    private void Start()
    {
        _thisTransform = this.GetComponent<Transform>();
        _pool.CreatePool(_bulletPrefab);
    }

    protected virtual void Attack()
    {
        T bullet = _pool.Get();
        bullet.transform.position = _thisTransform.position + _pointOfShot;
    }
}
