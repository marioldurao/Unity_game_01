using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    [SerializeField]
    private GameObject player;

    private Vector3 offset;
    private Vector3 finalOffset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
        finalOffset = offset;
    }


    private void LateUpdate()
    {
        Rotate();
        transform.position = player.transform.position + finalOffset;
        transform.LookAt(player.transform.position);

    }

    void Rotate()
    {
        finalOffset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 4f, Vector3.up) * finalOffset;
    }
}
