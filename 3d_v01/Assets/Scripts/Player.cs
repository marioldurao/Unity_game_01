


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum gameStateEnum
{
    WORD_1,
    WORD_2,
    WORD_3,
    WORD_4
}

static class Constants
{
    public const float jumpPower_const = 6;
    public const float jumpPowerfactor_const = 2;
    public const int RotationSpeed_const = 2;
    public const int MovSpeed_const = 10;
}

public class Globals
{
    public static gameStateEnum gameState = gameStateEnum.WORD_1;
}



public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundChecktransform = null;
    [SerializeField] private LayerMask playerMask;

    private bool jumpKeyWasPressed = false;
    private Vector3 inputDir;
    private Rigidbody rigidBodyComponent;
    private int supperJumpsRemaining = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
        GameController.Start_Controller();

    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }

        //inputDir = new Vector3(Input.GetAxis("Horizontal") * Constants.MovSpeed_const, 0, Input.GetAxis("Vertical") * Constants.MovSpeed_const);
        inputDir = new Vector3(0, 0, Input.GetAxis("Vertical") * Constants.MovSpeed_const);
        inputDir = Camera.main.transform.TransformDirection(inputDir);
        
        //inputDir.Normalize();

        Rotation();
    }


    //fixed update is called once every fix update (every 100fps)
    private void FixedUpdate()
    {
        inputDir.y = GetComponent<Rigidbody>().velocity.y;
        rigidBodyComponent.velocity = inputDir;


        if (Physics.OverlapSphere(groundChecktransform.position, 0.1f, playerMask).Length == 1)
        {
            return;
        }

        if (supperJumpsRemaining > 0)
        {
            this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
        }
        else
        {
            this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        }

        if (jumpKeyWasPressed)
        {
            float jumpPower = Constants.jumpPower_const;
            if(supperJumpsRemaining > 0)
            {
                jumpPower *= Constants.jumpPowerfactor_const;
                supperJumpsRemaining--;       
                Debug.Log("game object color changed");
            }
       

            rigidBodyComponent.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            Debug.Log("space key pressed");
            jumpKeyWasPressed = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //Sillabus target
        if (other.gameObject.layer == 7)
        {
            Destroy(other.gameObject);
            supperJumpsRemaining++;
        }
        //Sillabus target
        if (other.gameObject.layer == 9)
        {
            GameObject textObject = GameObject.Find("/Player/Canvas/Panel/guessWord");
            TextMesh textword = textObject.GetComponent<TextMesh>();
            textword.text += other.GetComponent<TextMesh>().text;
            //textword.text = other.GetComponent<TextMesh>().text;
            Debug.Log("guessWord change text");


            if(other.name == "SIL_1")
            {

                other.GetComponent<Renderer>().enabled = false;
                other.GetComponent<SphereCollider>().enabled = false;
                GameObject.Find("/Targets/SIL_2").GetComponent<Renderer>().enabled = true;
                GameObject.Find("/Targets/SIL_2").GetComponent<SphereCollider>().enabled = true;
                Debug.Log("1st sillabus done");
            }
            else if (other.name == "SIL_2")
            {
                other.GetComponent<Renderer>().enabled = false;
                other.GetComponent<SphereCollider>().enabled = false;
                GameObject.Find("/Targets/SIL_3").GetComponent<Renderer>().enabled = true;
                GameObject.Find("/Targets/SIL_3").GetComponent<SphereCollider>().enabled = true;
                Debug.Log("2nd sillabus done");
            }
            else if (other.name == "SIL_3")
            {
                other.GetComponent<Renderer>().enabled = false;
                other.GetComponent<SphereCollider>().enabled = false;
                GameObject.Find("/Player/Canvas/Panel/Button_0").SetActive(true);
                GameObject.Find("/Player/Canvas/Panel/Button_1").SetActive(true);
                GameObject.Find("/Player/Canvas/Panel/Button_2").SetActive(true);
                Debug.Log("3rd sillabus done");
            }

            Debug.Log(other.name);

            
            //other.gameObject.SetActive(true);
            //Destroy(other.gameObject);
            supperJumpsRemaining++;
        }
      
    }

    void Rotation()
    {
        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * Constants.RotationSpeed_const, 0));
    }

}
