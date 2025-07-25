using System;
using UnityEngine;

public class Player : MonoBehaviour, IInteractable
{
    [SerializeField] private CollisionHandler _collisionHandler;

    public event Action OnDead;

    private void OnEnable() =>
        _collisionHandler.CollisionDetected += Handle�ollision;

    private void OnDisable() =>
        _collisionHandler.CollisionDetected -= Handle�ollision;


    public void Handle�ollision(IInteractable interactable)
    {
        if (interactable is BulletPlayer bulletPlayer)
        {
            return;
        }
        else if (interactable is BulletEnemy bulletEnemy)
        {
            Debug.Log($"� {name} ���������� � Bullet");
            OnDead?.Invoke();
        }
        else if (interactable is Thorns thorns)
        {
            Debug.Log($"� {name} ���������� � Thorns");
            OnDead?.Invoke();
        }
        else if (interactable is Enemy enemy)
        {
            Debug.Log($"� {name} ���������� � Enemy");
            OnDead?.Invoke();
        }
    }
}
