using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogGameClearPanel : MonoBehaviour
{
    [SerializeField]
    private Button nextChapterButton;

    [SerializeField]
    private Button titleButton;

    public void SetPanel(UnityAction onClickNextChapter, UnityAction onClickTitle)
    {
        gameObject.SetActive(true);

        nextChapterButton.onClick.AddListener(onClickNextChapter);
        titleButton.onClick.AddListener(onClickTitle);
    }
}
