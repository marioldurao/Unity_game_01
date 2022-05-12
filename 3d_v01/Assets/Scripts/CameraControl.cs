using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    [SerializeField]
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
    }


    private void LateUpdate()
    {
        transform.position = player.transform.position - player.transform.forward * 30;
        transform.LookAt(player.transform.position);
        transform.position = new Vector3(transform.position.x, transform.position.y +2 , transform.position.z);
    }

}
