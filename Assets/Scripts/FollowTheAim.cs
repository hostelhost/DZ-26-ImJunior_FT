using UnityEngine;

public class FollowTheAim : MonoBehaviour
{
    [SerializeField] private Transform _aim;
    [SerializeField] private float _offsetX = 5.5f;
    [SerializeField] private float _offsetZ = -10;

    private void Update()
    {
        if (_aim == null)
            Destroy(gameObject);
        else if (transform.position.x + _offsetX != _aim.position.x)
            NextPosition();
    }

    private void NextPosition()
    {
        Vector3 offset = _aim.position;
        offset.x += _offsetX;
        offset.z = _offsetZ;
        transform.position = offset;
    }
}
