using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action SpaceKeyHasPressed;
    public event Action EnterKeyHasPressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SpaceKeyHasPressed.Invoke();
        if (Input.GetKey(KeyCode.KeypadEnter))
            EnterKeyHasPressed.Invoke();
    }
}
