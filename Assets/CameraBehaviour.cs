using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform PlayerTransform;

    private Transform CameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        CameraTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        CameraTransform.position = new Vector3(PlayerTransform.position.x - 2, CameraTransform.position.y, CameraTransform.position.z);
    }
}
