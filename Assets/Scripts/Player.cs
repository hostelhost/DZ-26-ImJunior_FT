using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CollisionHandler _collisionHandler;
    //[SerializeField] private PlayerMover _playerMover;
    //[SerializeField] private InputReader _inputReader;
    //[SerializeField] private ; 
    //[SerializeField] private ;

    public event Action GameOver;

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += HandleСollision;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= HandleСollision;
    }

    private void HandleСollision(IInteractable interactable)
    {
        if (interactable is BulletPlayer BulletPlayer)
        {
            return;
        }
        else if (interactable is Bullet bullet)
        {
            Debug.Log("Я столкнулся с Bullet");
            //Нанести получить урон от пули. 
            GameOver?.Invoke();
        }
        else if (interactable is Thorns thorns)
        {
            Debug.Log("Я столкнулся с Thorns");
            //Нанести урон от шипов
            GameOver?.Invoke();
        }
        else if (interactable is Enemy enemy)
        {
            Debug.Log("Я столкнулся с Enemy");
            //Нанести урон от столкновения с enemy
            GameOver?.Invoke();
        }
    }
}
