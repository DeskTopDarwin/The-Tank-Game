using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock : MonoBehaviour
{
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // serves the purpose of not having a visible cursor and keep it in the middle of the screen unless
        // pressing left alt to allow interaction with UI.
        Cursor.lockState = CursorLockMode.Locked;
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
