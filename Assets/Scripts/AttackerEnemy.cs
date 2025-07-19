using UnityEngine;

public class AttackerEnemy : Attacker<Bullet>
{
    [SerializeField] private float _attackPauseTime;

    private float _timer = 0;

    private void Update() //не проверено
    {
        if (_timer >= _attackPauseTime)
        {
            Attack();
            _timer = 0;
        }

        _timer += Time.deltaTime;
    }
}
