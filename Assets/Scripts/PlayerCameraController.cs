using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    private GameObject Player;

    [SerializeField]
    private GunController Gun;
    
    private Vector2 lookingPosition;
    [SerializeField]
    private float Sensitivity = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Player = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputRotation = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        lookingPosition += inputRotation;

        transform.localRotation = Quaternion.AngleAxis(lookingPosition.y, Vector3.right);
        Player.transform.localRotation = Quaternion.AngleAxis(lookingPosition.x, Player.transform.up);
        
        //Gun.SetPosition(transform.rotation);
    }
}
