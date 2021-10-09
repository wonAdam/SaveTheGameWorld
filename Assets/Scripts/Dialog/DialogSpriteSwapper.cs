using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSpriteSwapper : MonoBehaviour
{
    [SerializeField] 
    private Image imageOne;

    [SerializeField] 
    private Image imageTwo;

    [SerializeField]
    private float swapSeconds;

    private Image backgroundImage;


    // Start is called before the first frame update
    void Start()
    {
        backgroundImage = GetComponent<Image>();
        imageOne.preserveAspect = true;
        imageTwo.preserveAspect = true;
    }
    
    public void ChangeImage(Sprite newImage)
    {
        backgroundImage.sprite = newImage;
    }


    public void SwapSprite(Sprite newSprite)
    {
        StopAllCoroutines();

        if (GetCurrentSprite() == newSprite)
        {
            return;
        }

        if(imageOne.color.a == 0f)
        {
            StartCoroutine(SwapSpriteCoroutine(imageTwo, imageOne, newSprite));
        }
        else
        {
            StartCoroutine(SwapSpriteCoroutine(imageOne, imageTwo, newSprite));
        }
    }

    private Sprite GetCurrentSprite()
    {
        if (imageOne.color.a > 0f)
        {
            return imageOne.sprite;
        }
        else
        {
            return imageTwo.sprite;
        }
    }

    private IEnumerator SwapSpriteCoroutine(Image imageToTurnOff, Image imageToTurnOn, Sprite newSprite)
    {
        float turnOnAlpha = 0.0f;
        float currSeconds = 0.0f;
        imageToTurnOn.sprite = newSprite;
        while (turnOnAlpha < 1f)
        {
            turnOnAlpha = Mathf.Min(currSeconds / swapSeconds, 1f);
            imageToTurnOff.color = new Color(imageToTurnOff.color.r, imageToTurnOff.color.g, imageToTurnOff.color.b, 1f - turnOnAlpha);
            imageToTurnOn.color = new Color(imageToTurnOff.color.r, imageToTurnOff.color.g, imageToTurnOff.color.b, turnOnAlpha);

            currSeconds += Time.deltaTime;
            yield return null;
        }
    }

}
