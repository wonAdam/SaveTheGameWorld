using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleContinueButton : MonoBehaviour
{
    //[SerializeField]
    private Button continueButton;

    // Start is called before the first frame update
    void Start()
    {
        continueButton = GetComponent<Button>();

        PlayerData playerData = SaveManager.LoadPlayer();

        if(playerData == null)
        {
            continueButton.interactable = false;
        }

        // progress > 0
        // interactable
        else if(playerData.chapterProgress > 0)
        {  
            continueButton.interactable = true;
        }

        // else
        // un-interactable
        else // progress == 0
        {
            continueButton.interactable = false;
        }

    }



}
