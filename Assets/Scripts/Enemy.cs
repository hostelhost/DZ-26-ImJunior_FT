using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IInteractable, IExistInPool
{
    private Action _onDead;

    public void Initialize(Action onDead)
    {
        _onDead = onDead;
    }

    public void Handle—ollision(IInteractable interactable) 
    { 

    }
}
