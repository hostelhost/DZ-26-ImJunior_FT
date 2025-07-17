using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class MoverPlayer : MonoBehaviour
{

    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxRotationAroundAxisZ;
    [SerializeField] private float _minRotationAroundAxisZ;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Start()
    {
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationAroundAxisZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationAroundAxisZ);
    }

    private void OnEnable()
    {
        _inputReader.SpaceKeyHasPressed += Jump;
    }

    private void OnDisable()
    {
        _inputReader.SpaceKeyHasPressed -= Jump;
    }

    private void Jump()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
        _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        transform.rotation = _maxRotation;
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_speed, _rigidbody2D.velocity.y);

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }
}
