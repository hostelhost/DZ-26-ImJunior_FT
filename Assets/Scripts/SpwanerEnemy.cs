using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanerEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _prifab;
    [SerializeField] private Transform _player;
    [SerializeField] private float _offsetPositionX;
    [SerializeField] private float _offsetPositionMinimumY;
    [SerializeField] private float _offsetPositionMaximumY;
    [SerializeField] private float _spawnTime;

    private WaitForSeconds _waitForSecondsSpawnTime;
    private Pool<Enemy> _pool = new();

    private void Start()
    {
        _pool.CreatePool(_prifab);
        _waitForSecondsSpawnTime = new(_spawnTime);
        StartCoroutine(StartGeme());
    }

    private IEnumerator StartGeme()
    {
        while (enabled)
        {
            Spawn();
            yield return _waitForSecondsSpawnTime;
        }
    }

    private void Spawn()
    {
        Enemy enemy = _pool.Get();
        enemy.transform.position = GetNewPosition();
        enemy.GetTransformForDespawn(_player);
    }

    private Vector3 GetNewPosition() =>
        new Vector3(_player.position.x + _offsetPositionX, GetNewY());

    private float GetNewY() =>
       Random.Range(_offsetPositionMinimumY, _offsetPositionMaximumY);
}
