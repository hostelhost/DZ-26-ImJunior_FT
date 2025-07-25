using System;
using UnityEngine;

public class BulletPlayer : Bullet
{
    public event Action ThornsCollision;

    public void GetQuaternion(Quaternion quaternion) =>
        transform.rotation = quaternion;

    public override void Handle—ollision(IInteractable interactable)
    {
        if (interactable is Player player || interactable is BulletPlayer bulletPlayer)
        {
            return;
        }
        else if (interactable is Bullet bullet)
        {
            _onDead?.Invoke();
        }
        else if (interactable is Thorns thorns)
        {
            ThornsCollision?.Invoke();
            _onDead?.Invoke();
        }
        else if (interactable is Enemy enemy)
        {
            _onDead?.Invoke();
        }
    }
}
