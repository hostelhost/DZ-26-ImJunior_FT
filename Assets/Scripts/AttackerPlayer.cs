using UnityEngine;

public class AttackerPlayer : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private BulletPlayer _prefab;
    [SerializeField] private Vector3 _pointOfShot;
    [SerializeField] private Transform _player;

    private Pool<BulletPlayer> _pool = new();

    private void OnEnable() =>
        _inputReader.Mouse0KeyHasPressed += Attack;

    private void OnDisable() =>
        _inputReader.Mouse0KeyHasPressed -= Attack;

    private void Start()
    {
        _pool.CreatePool(_prefab);
    }

    private void Attack()
    {
        BulletPlayer bullet = _pool.Get();
        bullet.transform.position = _player.position + _pointOfShot;     
    }
}
