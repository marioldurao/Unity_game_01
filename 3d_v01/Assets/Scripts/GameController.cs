using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameController
{

    // Start is called before the first frame update
    public static void Start_Controller()
    {
        Debug.Log("start controller");
        //Hide Second and third sillabus
        GameObject.Find("/Targets/SIL_2").GetComponent<Renderer>().enabled = false;
        GameObject.Find("/Targets/SIL_2").GetComponent<SphereCollider>().enabled = false;
        GameObject.Find("/Targets/SIL_3").GetComponent<Renderer>().enabled = false;
        GameObject.Find("/Targets/SIL_3").GetComponent<SphereCollider>().enabled = false;

        //Hide buttons until 3 sillabus are gathered
        GameObject.Find("/Player/Canvas/Panel/Button_0").SetActive(false);
        GameObject.Find("/Player/Canvas/Panel/Button_1").SetActive(false);
        GameObject.Find("/Player/Canvas/Panel/Button_2").SetActive(false);

        
    }

    // Update is called once per frame
    public static void Update_Controller()
    {
        int debug_out = 1;
        switch (Globals.gameState)
        {
            case gameStateEnum.WORD_1:
                // code block
                if (1 == debug_out)
                {
                    Debug.Log("update controller Case " + Globals.gameState);
                    debug_out = 0;
                }
                break;
            case gameStateEnum.WORD_2:
                debug_out = 1;
                if (1 == debug_out)
                {
                    Debug.Log("update controller Case " + Globals.gameState);
                }

                GameObject.Find("/Targets/SIL_1").SetActive(true);
                GameObject.Find("/Targets/SIL_2").SetActive(true);
                GameObject.Find("/Targets/SIL_3").SetActive(true);

                GameObject.Find("/Targets/SIL_1").GetComponent<TextMesh>().text = "MA";
                GameObject.Find("/Targets/SIL_2").GetComponent<TextMesh>().text = "CA";
                GameObject.Find("/Targets/SIL_3").GetComponent<TextMesh>().text = "CO";
                //reveal SIL 1
                GameObject.Find("/Targets/SIL_1").GetComponent<Renderer>().enabled = true;
                GameObject.Find("/Targets/SIL_1").GetComponent<SphereCollider>().enabled = true;
                //Hide SIL 1 and 2
                GameObject.Find("/Targets/SIL_2").GetComponent<Renderer>().enabled = false;
                GameObject.Find("/Targets/SIL_2").GetComponent<SphereCollider>().enabled = false;
                GameObject.Find("/Targets/SIL_3").GetComponent<Renderer>().enabled = false;
                GameObject.Find("/Targets/SIL_3").GetComponent<SphereCollider>().enabled = false;
                // code block
                break;
            case gameStateEnum.WORD_3:

                debug_out = 1;
                if (1 == debug_out)
                {
                    Debug.Log("update controller Case " + Globals.gameState);
                }
                
                GameObject.Find("/Targets/SIL_1").SetActive(true);
                GameObject.Find("/Targets/SIL_2").SetActive(true);
                GameObject.Find("/Targets/SIL_3").SetActive(true);

                GameObject.Find("/Targets/SIL_1").GetComponent<TextMesh>().text = "BIS";
                GameObject.Find("/Targets/SIL_2").GetComponent<TextMesh>().text = "COI";
                GameObject.Find("/Targets/SIL_3").GetComponent<TextMesh>().text = "TO";

                //reveal SIL 1
                GameObject.Find("/Targets/SIL_1").GetComponent<Renderer>().enabled = true;
                GameObject.Find("/Targets/SIL_1").GetComponent<SphereCollider>().enabled = true;
                //Hide SIL 1 and 2
                GameObject.Find("/Targets/SIL_2").GetComponent<Renderer>().enabled = false;
                GameObject.Find("/Targets/SIL_2").GetComponent<SphereCollider>().enabled = false;
                GameObject.Find("/Targets/SIL_3").GetComponent<Renderer>().enabled = false;
                GameObject.Find("/Targets/SIL_3").GetComponent<SphereCollider>().enabled = false;
                // code block
                break;
            default:
                // code block
                break;
        }

    }
}
