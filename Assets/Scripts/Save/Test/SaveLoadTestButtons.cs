using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadTestButtons : MonoBehaviour
{
    [SerializeField]
    public int progress;

    [SerializeField]
    private Button button;

    [SerializeField]
    private GameObject continuePanel;

    public void OnClickTestSaveButton()
    {
        SaveManager.SavePlayer(new PlayerData(progress));
        Debug.Log($"OnClickTestSaveButton");

        continuePanel.SetActive(true);
        continuePanel.SetActive(false);
    }

    public void OnClickTestLoadButton()
    {
        Debug.Log($"OnClickTestLoadButton {SaveManager.LoadPlayer().chapterProgress}");
    }
}
