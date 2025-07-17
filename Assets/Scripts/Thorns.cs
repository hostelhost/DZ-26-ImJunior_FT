using UnityEngine;

public class Thorns : MonoBehaviour, IInteractable
{
    [SerializeField] BoxCollider2D _boxCollider2D;
    private void Start() =>
    _boxCollider2D.isTrigger = true;

    public void HandleÑollision(IInteractable interactable)
    {
        return;
    }
}
