using UnityEngine;

public class AttackerPlayer : Attacker<BulletPlayer>
{
    [SerializeField] private InputReader _inputReader;

    private void OnEnable() =>
        _inputReader.Mouse0KeyHasPressed += Attack;

    private void OnDisable() =>
        _inputReader.Mouse0KeyHasPressed -= Attack;

    protected override void Attack()
    {
        BulletPlayer bullet = _pool.Get();
        bullet.transform.position = _thisTransform.position + _pointOfShot;
        bullet.GetQuaternion(_thisTransform.rotation);
    }
}
