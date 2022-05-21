using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class On_Click_Button : MonoBehaviour
{

    private string myText;
    public Image mImage;

    public void VerifyMatch()
    {
        Debug.Log("On click button - verify match ");
        GameObject textObject = GameObject.Find("/Player/Canvas/Panel/guessWord");
        TextMesh textword = textObject.GetComponent<TextMesh>();
        mImage = GetComponent<Image>();
        myText = mImage.sprite.name;

        int compareRes = string.Compare(textword.text, myText);

        if (0 == compareRes)
        {
            Sprite msprite = Resources.Load<Sprite>("Correcto");
            mImage.sprite = msprite;

            switch (Globals.gameState)
            {
                case gameStateEnum.WORD_1:
                    Globals.gameState = gameStateEnum.WORD_2;
                    // code block
                    break;
                case gameStateEnum.WORD_2:
                    Globals.gameState = gameStateEnum.WORD_3;
                    // code block
                    break;
                case gameStateEnum.WORD_3:
                    Globals.gameState = gameStateEnum.WORD_1;
                    // code block
                    break;
                default:
                    // code block
                    break;
            }
            //Changes the word to find upon state machine
            GameController.Update_Controller();
            textObject.GetComponent<TextMesh>().text = "";
            Debug.Log("correct " + myText);
        }
        else
        {
            Sprite msprite = Resources.Load<Sprite>("Incorrecto");
            textObject.GetComponent<TextMesh>().text = "";
            mImage.sprite = msprite;

            Debug.Log("wrong " + myText);
        }
        //clear when click on incorrect
        if (myText == "incorrecto")
        {
            mImage.sprite.name = "MACACO";
        }
    }

}
