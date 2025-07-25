using UnityEngine;

public class BulletEnemy : Bullet
{
    public override void HandleÑollision(IInteractable interactable)
    {
        if (interactable is Enemy enemy || interactable is BulletEnemy bulletEnemy)
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
}
