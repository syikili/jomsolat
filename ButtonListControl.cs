using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListControl : MonoBehaviour {

    [SerializeField]
    private GameObject buttonTemplate;


    // Use this for initialization
    void Start() {
        for (int i = 1; i <= 20; i++) {

            // string[] tutorialList = new string[] { "WUDHU","RUKUN WUDHU","MARI MENUNAIKAN SOLAT SUBUH", "MARI MENUNAIKAN SOLAT ZOHOR", "MARI MENUNAIKAN SOLAT ASAR" ,
            // "MARI MENUNAIKAN SOLAT MAGHRIB", "MARI MENUNAIKAN SOLAT ISYAK", "DOA SELEPAS SOLAT", "AMALAN SUNNAH" };

            string[] tutorialList = new string[9];
            tutorialList[0] = "WUDHU";
            tutorialList[1] = "RUKUN WUDHU";
            tutorialList[2] = "MARI MENUNAIKAN SOLAT SUBUH";
            tutorialList[3] = "MARI MENUNAIKAN SOLAT ZOHOR";
            tutorialList[4] = "MARI MENUNAIKAN SOLAT ASAR";
            tutorialList[5] = "MARI MENUNAIKAN SOLAT MAGHRIB";
            tutorialList[6] = "MARI MENUNAIKAN SOLAT ISYAK";
            tutorialList[7] = "DOA SELEPAS SOLAT";
            tutorialList[8] = "AMALAN SUNNAH";

            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);

            //foreach (string x in tutorialList)
            for (int x = 0; x < tutorialList.Length; x++)
            {
                string s = tutorialList[x++];
                button.GetComponent<ButtonListButton>().setText("Tutorial " + i + ": " + s);
            }

            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }

    public void ButtonClicked(string myTextString)
    {
        Debug.Log(myTextString);
    }
	}


