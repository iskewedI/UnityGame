using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    private float mouseSensibility = 400f;

    private Transform player;
    // Start is called before the first frame update
    private void Start()
    {
        player = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensibility * Time.deltaTime;

        player.Rotate(Vector3.up, mouseX);
    }
}
