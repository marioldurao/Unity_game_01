using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class On_Click_Button : MonoBehaviour
{

    private string myText = "BANANA";
  
    public Image mImage;

    public void VerifyMatch()
    {
        GameObject textObject = GameObject.Find("/Player/Canvas/Panel/guessWord");
        TextMesh textword = textObject.GetComponent<TextMesh>();

        int compareRes = string.Compare(textword.text, myText);

        if (0==compareRes)
        {
            mImage = GetComponent<Image>();
            Sprite msprite = Resources.Load<Sprite>("Correcto");
            mImage.sprite = msprite;
          
            Debug.Log("correct banana");
        }
        else
        {
            mImage = GetComponent<Image>();
            Sprite msprite = Resources.Load<Sprite>("Incorrecto");
            mImage.sprite = msprite;

        
            Debug.Log("wrong banana");
        }
    }


}
