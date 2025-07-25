using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IInteractable, IExistInPool
{
    [SerializeField] private CollisionHandler _collisionHandler;
    
    private Transform _player;
    private float _offsetOnDead = 10;

    private void OnEnable() =>
        _collisionHandler.CollisionDetected += HandleÑollision;

    private void OnDisable() =>
        _collisionHandler.CollisionDetected -= HandleÑollision;

    private Action _onDead;

    private void Update()
    {
        DespawnBehindPlayer();
    }

    public void Initialize(Action onDead)
    {
        _onDead = onDead;
    }

    public void HandleÑollision(IInteractable interactable)
    {
        if (interactable is Bullet bullet)
            return;
        else if (interactable is BulletPlayer bulletPlayer)
            _onDead?.Invoke();
        else if (interactable is Player player)
            _onDead?.Invoke();
    }

    public void GetTransformForDespawn(Transform transform) =>   
        _player = transform;
    
    private void DespawnBehindPlayer()
    {
        if (_player.position.x > transform.position.x + _offsetOnDead)
            _onDead?.Invoke();
    }
}
