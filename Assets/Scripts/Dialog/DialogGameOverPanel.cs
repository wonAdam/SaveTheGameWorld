using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogGameOverPanel : MonoBehaviour
{
    [SerializeField]
    private Button titleButton;

    [SerializeField]
    private Button retryButton;

    public void SetPanel(UnityAction onClickRetry, UnityAction onClickTitle)
    {
        gameObject.SetActive(true);

        retryButton.onClick.AddListener(onClickRetry);
        titleButton.onClick.AddListener(onClickTitle);
    }
}
