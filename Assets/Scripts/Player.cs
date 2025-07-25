using System;
using UnityEngine;

public class Player : MonoBehaviour, IInteractable
{
    [SerializeField] private CollisionHandler _collisionHandler;

    public event Action OnDead;

    private void OnEnable() =>
        _collisionHandler.CollisionDetected += HandleÑollision;

    private void OnDisable() =>
        _collisionHandler.CollisionDetected -= HandleÑollision;


    public void HandleÑollision(IInteractable interactable)
    {
        if (interactable is BulletPlayer bulletPlayer)
        {
            return;
        }
        else if (interactable is BulletEnemy bulletEnemy)
        {
            Debug.Log($"ß {name} ñòîëêíóëñÿ ñ Bullet");
            OnDead?.Invoke();
        }
        else if (interactable is Thorns thorns)
        {
            Debug.Log($"ß {name} ñòîëêíóëñÿ ñ Thorns");
            OnDead?.Invoke();
        }
        else if (interactable is Enemy enemy)
        {
            Debug.Log($"ß {name} ñòîëêíóëñÿ ñ Enemy");
            OnDead?.Invoke();
        }
    }
}
