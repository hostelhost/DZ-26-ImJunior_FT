using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMover : MonoBehaviour
{

    [SerializeField] private float _jumpForce;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxRotationAroundAxisZ;
    [SerializeField] private float _minRotationAroundAxisZ;
    [SerializeField] private float _rotationSpeed;

    private Rigidbody2D _rigidbody2D;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationAroundAxisZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationAroundAxisZ);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            transform.rotation = _maxRotation;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_moveSpeed, _rigidbody2D.velocity.y);
    }
}
