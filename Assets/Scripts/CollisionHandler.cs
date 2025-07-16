using System;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _boxCollider2D;

    public event Action<IInteractable> CollisionDetected;

    private void Awake()
    {
        _boxCollider2D.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IInteractable>(out IInteractable interactable))           
            CollisionDetected?.Invoke(interactable);        
    }
}
