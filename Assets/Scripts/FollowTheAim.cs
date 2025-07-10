using UnityEngine;

public class FollowTheAim : MonoBehaviour
{
    [SerializeField] private Transform _aim;

    private float _offsetX = -5.5f;

    private void Update()
    {
        if (_aim == null)
            Destroy(gameObject);
        else if (transform.position.x + _offsetX != _aim.position.x)
            NextPosition();
    }

    private void NextPosition()
    {
        Vector2 offset = _aim.position;
        offset.x += _offsetX;
        transform.position = offset;
    }
}
