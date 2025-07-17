using System;
using UnityEngine;

public class Player : MonoBehaviour, IInteractable
{
    [SerializeField] private CollisionHandler _collisionHandler;
    //[SerializeField] private PlayerMover _playerMover;
    //[SerializeField] private InputReader _inputReader;
    //[SerializeField] private ; 
    //[SerializeField] private ;

    public event Action OnDead;

    private void OnEnable() =>
            _collisionHandler.CollisionDetected += HandleСollision;

    private void OnDisable() =>
        _collisionHandler.CollisionDetected -= HandleСollision;


    public void HandleСollision(IInteractable interactable)
    {
        if (interactable is BulletPlayer bulletPlayer)
        {
            return;
        }
        else if (interactable is Bullet bullet)
        {
            Debug.Log("Я столкнулся с Bullet");
            //Нанести получить урон от пули. 
            OnDead?.Invoke();
        }
        else if (interactable is Thorns thorns)
        {
            Debug.Log("Я столкнулся с Thorns");
            //Нанести урон от шипов
            OnDead?.Invoke();
        }
        else if (interactable is Enemy enemy)
        {
            Debug.Log("Я столкнулся с Enemy");
            //Нанести урон от столкновения с enemy
            OnDead?.Invoke();
        }
    }
}
