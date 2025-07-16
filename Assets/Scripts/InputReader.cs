using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action SpaceKeyHasPressed;
    public event Action Mouse0KeyHasPressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SpaceKeyHasPressed.Invoke();

        if (Input.GetKeyDown(KeyCode.Mouse0))
            Mouse0KeyHasPressed.Invoke();
    }
}
