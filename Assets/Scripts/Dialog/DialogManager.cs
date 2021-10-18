using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

/// <summary>
/// Dialog Manager´Â Dialog¾À¸¶´Ù ¹èÄ¡ÇÕ´Ï´Ù.
/// CanvasÀÇ Animator¸¦ ÂüÁ¶ÇÏ¿© ´ëÈ­¸¦ ÁøÇàÇÕ´Ï´Ù. (¾Æ¸¶ Canvas¿¡ ºÙÀÌ´Â°Ô ³ªÀ»µí)
/// AnimatorÀÇ State°¡ ¾îµð±îÁö µÆ´ÂÁöµµ Ã¼Å©ÇÏ¿© À¯ÁöÇÕ´Ï´Ù.
/// </summary>
public class DialogManager : SimpleSingletonBehaviour<DialogManager>
{
    [SerializeField /*DEBUG*/]
    public int currDialogIndex = 0;

    [SerializeField]
    [Range(0f, 1f)]
    public float allowMoveToNextRatio;


    [SerializeField]
    public DialogSpriteSwapper backgroundImage;

    [SerializeField]
    public DialogSpriteSwapper characterOneImage;

    [SerializeField]
    public DialogSpriteSwapper characterTwoImage;

    [SerializeField]
    public DialogPlaceText placeText;

    [SerializeField]
    public RectTransform dialogPanel;

    [SerializeField]
    public RectTransform backgroundPanel;

    [SerializeField]
    public RectTransform characterPanel1;

    [SerializeField]
    public RectTransform characterPanel2;

    [SerializeField]
    public RectTransform alertPanel;

    [SerializeField]
    public TextMeshProUGUI dialogContentText;

    [SerializeField]
    public TextMeshProUGUI dialogCharacterNameText;

    [SerializeField]
    public List<DialogData> dialogDatas;

    [SerializeField]
    public AudioSource currSfx;

    [SerializeField]
    public string nextSceneName;

    [SerializeField]
    public string retrySceneName;

    [SerializeField]
    public string titleSceneName;

    [SerializeField]
    public DialogGameOverPanel gameOverPanel;

    [SerializeField]
    public DialogGameClearPanel gameClearPanel;

    [SerializeField]
    private AudioClip sirenClip;

    [SerializeField]
    private AudioClip kissClip;

    [SerializeField]
    public Text screenSizeDebug;

    public void PlaySirenAudioClip()
    {
        if (currSfx != null)
            Destroy(currSfx.gameObject);

        var audioSource = new GameObject();
        currSfx = audioSource.AddComponent<AudioSource>();
        audioSource.GetComponent<AudioSource>().volume = 0.7f;
        var clip = SoundDB.GetAudioClip(SoundEnum.Siren);
        audioSource.GetComponent<AudioSource>().PlayOneShot(clip);
        Destroy(audioSource, clip.length);

    }


    protected override void Awake()
    {
        base.Awake();

        ScreenFixedResolution.SetFixedResolution();

        //HandleAlertPanelPosition();
        //HandleDialogPanelSize();
        //HandleCharacterPanelsPosition();

        if(screenSizeDebug != null)
            screenSizeDebug.text = Screen.width + ":" + Screen.height; 
    }

    private void Update()
    {
        //// DEBUG
        ////dialogPanel.sizeDelta = new Vector2(0f, Screen.height - 1300f);

        //HandleAlertPanelPosition();
        //HandleDialogPanelSize();
        //HandleCharacterPanelsPosition();
        //HandleBackgroundSize();
    }

    private void HandleBackgroundSize()
    {
        if (backgroundPanel != null)
        {
            if (Mathf.Abs(Screen.height - 2160f) > Mathf.Epsilon)
            {
                backgroundPanel.sizeDelta = new Vector2(1080f, 1250f);
            }
            else // 길쭉한 해상도
            {
                backgroundPanel.sizeDelta = new Vector2(1424.69f, 1508.7f);
            }
        }
    }


    private void HandleDialogPanelSize()
    {
        if (dialogPanel != null)
        {
            dialogPanel.sizeDelta = new Vector2(0f, Screen.height - 1250f);

            //float heightOverflowRatio = (Screen.height / (float)Screen.width) / (1920f / 1080f);
            //if (Mathf.Abs(Screen.height - 1920f) > Mathf.Epsilon) // 길쭉한 해상도
            //{
            //    dialogPanel.sizeDelta = new Vector2(0f, Screen.height - 1250f);
            //}
            //else 
            //{
            //    dialogPanel.sizeDelta = new Vector2(0f, 670f);
            //}
        }
    }

    private void HandleCharacterPanelsPosition()
    {
        if (characterPanel1 != null)
        {
            if (Mathf.Abs(Screen.height - 2160f) > Mathf.Epsilon)
            {
                characterPanel1.anchoredPosition = new Vector2(0f, 239f);
            }
            else
            {
                characterPanel1.anchoredPosition = new Vector2(0f, 434f);
            }
        }
        if (characterPanel2 != null)
        {
            if (Mathf.Abs(Screen.height - 2160f) > Mathf.Epsilon)
            {
                characterPanel2.anchoredPosition = new Vector2(0f, 203f);
            }
            else
            {
                characterPanel2.anchoredPosition = new Vector2(0f, 426f);
            }
        }

    }

    private void HandleAlertPanelPosition()
    {
        if (alertPanel != null)
        {
            if (Mathf.Abs(Screen.height - 2160f) > Mathf.Epsilon)
            {
                alertPanel.anchoredPosition = new Vector2(0f, 215f);
            }
            else
            {
                alertPanel.anchoredPosition = new Vector2(0f, 0f);
            }
        }
    }

    public void PlayDialogWithIndex(int index)
    {
        if(dialogDatas.Count <= index)
        {
            GetComponent<Animator>().SetTrigger("End");
            return;
        }

        dialogContentText.text = dialogDatas[index].dialogContent;
        dialogCharacterNameText.text = DialogData.characterNameMap[dialogDatas[index].dialogCharacterName];
        characterOneImage.SwapSprite(dialogDatas[index].characterOneImage);
        characterTwoImage.SwapSprite(dialogDatas[index].characterTwoImage);
        backgroundImage.SwapSprite(dialogDatas[index].backgroundImage);
        //placeText.ShowPlaceText(dialogDatas[index].placeName);


        if (currSfx != null)
            Destroy(currSfx.gameObject);

        if(dialogDatas[index].sfx != null)
        {
            var audioSource = new GameObject();
            currSfx = audioSource.AddComponent<AudioSource>();
            audioSource.GetComponent<AudioSource>().volume = 0.5f;
            audioSource.GetComponent<AudioSource>().PlayOneShot(dialogDatas[index].sfx);
            Destroy(audioSource, dialogDatas[index].sfx.length);
        }
    }


    public void SetPlaceText(int index)
    {
        placeText.ShowPlaceText(dialogDatas[index].placeName);
        dialogContentText.text = dialogDatas[index].dialogContent;
        dialogCharacterNameText.text = DialogData.characterNameMap[dialogDatas[index].dialogCharacterName];
        characterOneImage.SwapSprite(dialogDatas[index].characterOneImage);
        characterTwoImage.SwapSprite(dialogDatas[index].characterTwoImage);
        backgroundImage.SwapSprite(dialogDatas[index].backgroundImage);
    }

    public void EndScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    public void PlayKissSound()
    {
        if (currSfx != null)
            Destroy(currSfx.gameObject);

        var audioSource = new GameObject();
        audioSource.AddComponent<AudioSource>();
        audioSource.GetComponent<AudioSource>().volume = 0.7f;
        var clip = SoundDB.GetAudioClip(SoundEnum.Kiss);
        audioSource.GetComponent<AudioSource>().PlayOneShot(clip);
        Destroy(audioSource, clip.length);
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetPanel(
            () => SceneManager.LoadScene(retrySceneName),
            () => SceneManager.LoadScene(titleSceneName)
        );
    }

    public void ShowGameClearPanel()
    {
        gameClearPanel.SetPanel(
            () => SceneManager.LoadScene(nextSceneName),
            () => SceneManager.LoadScene(titleSceneName)
        );
    }

}
