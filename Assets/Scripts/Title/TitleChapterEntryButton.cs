using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleChapterEntryButton : MonoBehaviour
{
    [SerializeField]
    private int chapter;

    private Button chapterButton;

    [SerializeField]
    private string nextSceneName;

    // Start is called before the first frame update
    void Start()
    {
        ScreenFixedResolution.SetFixedResolution();

        chapterButton = GetComponent<Button>();

        chapterButton.onClick.AddListener(OnClickChapterButton);

        PlayerData playerData = SaveManager.LoadPlayer();

        if (playerData == null) // 그럴일없지만...
        {
            chapterButton.interactable = false;
        }

        else if (playerData.chapterProgress + 1 >= chapter)
        { 
            chapterButton.interactable = true;
        }

        else 
        {
            chapterButton.interactable = false;
        }
    }



    private void OnClickChapterButton()
    {
        SceneManager.LoadScene(nextSceneName);
    }

}
