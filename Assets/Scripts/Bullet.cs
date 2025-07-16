using System;
using Unity.Mathematics;
using UnityEngine;

public class Bullet : MonoBehaviour, IInteractable, IExistInPool
{
    [SerializeField] Rigidbody2D _rigidbody2D;

    private float _speed = 3f;
    private Action _onDead;

    private void Update()
    {
        //transform.Translate(Vector3.right * _speed * Time.deltaTime);
        _rigidbody2D.velocity = transform.right * _speed;
        
    }

    

    public void Initialize(Action onDead)
    {
        _onDead = onDead;
        _rigidbody2D.gravityScale = 0;
    }
}
