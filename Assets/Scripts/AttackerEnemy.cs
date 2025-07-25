using System.Collections;
using UnityEngine;

public class AttackerEnemy : Attacker<BulletEnemy>
{
    [SerializeField] private float _attackPauseTime;

    private float _timer = 0;

    private void Update()
    {
        if (_timer >= _attackPauseTime)
        {
            Attack();
            _timer = 0;
        }

        _timer += Time.deltaTime;      
    }
}
