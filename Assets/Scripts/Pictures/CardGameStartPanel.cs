using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameStartPanel : MonoBehaviour
{

    public void OnPanelDisappearingEnd()
    {
        CardGameManager.isPlaying = true;
        gameObject.SetActive(false);
    }
}
