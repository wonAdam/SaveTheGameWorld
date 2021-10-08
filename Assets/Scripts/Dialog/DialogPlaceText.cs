using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogPlaceText : MonoBehaviour
{
    [SerializeField]
    private Image panelImage;

    [SerializeField]
    private TextMeshProUGUI placeText;

    [SerializeField]
    private float appearingSeconds;

    [SerializeField]
    private float stayingSeconds;

    [SerializeField]
    private float disappearingSeconds;

    public void SetText(string content)
    {
        placeText.text = content;
    }

    public void ShowPlaceText(string placeText)
    {
        if(placeText == string.Empty)
        {
            return;
        }

        StartCoroutine(ShowPlaceTextCoroutine(placeText));
    }

    private IEnumerator ShowPlaceTextCoroutine(string placeText)
    {
        this.placeText.text = placeText;

        float waitSeconds = appearingSeconds;
        while (waitSeconds > 0f)
        {
            waitSeconds -= Time.deltaTime;

            float newAlpha = waitSeconds / appearingSeconds - 1f;
            panelImage.color = new Color(panelImage.color.r, panelImage.color.g, panelImage.color.b, newAlpha);
            yield return null;
        }

        yield return new WaitForSeconds(stayingSeconds);

        waitSeconds = disappearingSeconds;
        while (waitSeconds > 0f)
        {
            waitSeconds -= Time.deltaTime;

            float newAlpha = waitSeconds / appearingSeconds;
            panelImage.color = new Color(panelImage.color.r, panelImage.color.g, panelImage.color.b, newAlpha);
            yield return null;
        }
    }
}
