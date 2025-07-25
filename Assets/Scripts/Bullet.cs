using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour, IInteractable, IExistInPool
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private CollisionHandler _collisionHandler;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private bool _isRight;
    [SerializeField] private float _lifeTime = 20f;

    private int _swapValue = -1;
    private WaitForSeconds _waitForSecondsLifeTime;

    protected Action _onDead;

    private void OnEnable() =>
        _collisionHandler.CollisionDetected += Handle—ollision;

    private void OnDisable() =>
        _collisionHandler.CollisionDetected -= Handle—ollision;

    private void Start()
    {
        _rigidbody2D.gravityScale = 0;
        _waitForSecondsLifeTime = new WaitForSeconds(_lifeTime);
        StartCoroutine(DieOnTime());
    }

    private void Update()
    {
        if (_isRight)
            _rigidbody2D.velocity = transform.right * _speed;
        else
            _rigidbody2D.velocity = (transform.right * _swapValue) * _speed;
    }

    public void Initialize(Action onDead) =>
        _onDead = onDead;

    public virtual void Handle—ollision(IInteractable interactable)
    {
        if (interactable is Enemy enemy || interactable is Bullet bullet)
        {
            return;
        }
        else if (interactable is BulletPlayer bulletPlayer)
        {
            _onDead?.Invoke();
        }
        else if (interactable is Thorns thorns)
        {
            _onDead?.Invoke();
        }
        else if (interactable is Player player)
        {
            _onDead?.Invoke();
        }
    }

    private IEnumerator DieOnTime()
    {
        yield return _waitForSecondsLifeTime;
        _onDead?.Invoke();
    }
}
