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
            _collisionHandler.CollisionDetected += Handle�ollision;

    private void OnDisable() =>
        _collisionHandler.CollisionDetected -= Handle�ollision;


    public void Handle�ollision(IInteractable interactable)
    {
        if (interactable is BulletPlayer bulletPlayer)
        {
            return;
        }
        else if (interactable is Bullet bullet)
        {
            Debug.Log("� ���������� � Bullet");
            //������� �������� ���� �� ����. 
            OnDead?.Invoke();
        }
        else if (interactable is Thorns thorns)
        {
            Debug.Log("� ���������� � Thorns");
            //������� ���� �� �����
            OnDead?.Invoke();
        }
        else if (interactable is Enemy enemy)
        {
            Debug.Log("� ���������� � Enemy");
            //������� ���� �� ������������ � enemy
            OnDead?.Invoke();
        }
    }
}
