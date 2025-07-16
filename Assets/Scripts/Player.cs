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
        _collisionHandler.CollisionDetected += Handle�ollision;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= Handle�ollision;
    }

    private void Handle�ollision(IInteractable interactable)
    {
        if (interactable is BulletPlayer BulletPlayer)
        {
            return;
        }
        else if (interactable is Bullet bullet)
        {
            Debug.Log("� ���������� � Bullet");
            //������� �������� ���� �� ����. 
            GameOver?.Invoke();
        }
        else if (interactable is Thorns thorns)
        {
            Debug.Log("� ���������� � Thorns");
            //������� ���� �� �����
            GameOver?.Invoke();
        }
        else if (interactable is Enemy enemy)
        {
            Debug.Log("� ���������� � Enemy");
            //������� ���� �� ������������ � enemy
            GameOver?.Invoke();
        }
    }
}
