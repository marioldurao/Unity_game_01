using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class On_Click_Button : MonoBehaviour
{

    private string myText = "BANANA";
  
    public void VerifyMatch()
    {
        GameObject textObject = GameObject.Find("/Player/Canvas/Panel/guessWord");
        TextMesh textword = textObject.GetComponent<TextMesh>();

        int compareRes = string.Compare(textword.text, myText);

        if (0==compareRes)
        {
            Debug.Log("correct banana");
        }
        else
        {
            Debug.Log("wrong banana");
        }
    }


}
