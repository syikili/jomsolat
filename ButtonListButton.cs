using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListButton : MonoBehaviour {

    [SerializeField]
    private Text myText;
    private string myTextString;
    [SerializeField]
    private ButtonListControl buttonControl;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setText(string textString) {       

        myText.text = textString;
        myTextString = textString;

    }
    public void OnClick() {
        buttonControl.ButtonClicked(myTextString);
    }
}
