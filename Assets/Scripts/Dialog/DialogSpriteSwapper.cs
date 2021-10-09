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

    [SerializeField /*DEBUG*/]
    bool one = true;


    // Start is called before the first frame update
    void Start()
    {
        backgroundImage = GetComponent<Image>();
        imageOne.preserveAspect = true;
        imageTwo.preserveAspect = true;

        imageOne.color = new Color(imageOne.color.r, imageOne.color.g, imageOne.color.b, 0f);
        imageTwo.color = new Color(imageTwo.color.r, imageTwo.color.g, imageTwo.color.b, 0f);
    }
    
    public void ChangeImage(Sprite newImage)
    {
        backgroundImage.sprite = newImage;
    }


    public void SwapSprite(Sprite newSprite)
    {
        StopAllCoroutines();

        if (GetCurrentSprite() == newSprite || newSprite == null)
        {
            return;
        }

        if(one)
        {
            one = !one;
            StartCoroutine(SwapSpriteCoroutine(imageTwo, imageOne, newSprite));
        }
        else
        {
            one = !one;
            StartCoroutine(SwapSpriteCoroutine(imageOne, imageTwo, newSprite));
        }
    }

    private Sprite GetCurrentSprite()
    {
        if (imageOne.color.a > 0f)
        {
            return imageOne.sprite;
        }
        else if(imageTwo.color.a > 0f)
        {
            return imageTwo.sprite;
        }
        else
        {
            return null;
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
            imageToTurnOff.color = new Color(
                imageToTurnOff.color.r, 
                imageToTurnOff.color.g, 
                imageToTurnOff.color.b, 
                imageToTurnOff.sprite != null ? 1f - turnOnAlpha : 0f);
            imageToTurnOn.color = new Color(
                imageToTurnOn.color.r,
                imageToTurnOn.color.g,
                imageToTurnOn.color.b,
                imageToTurnOn.sprite != null ? turnOnAlpha : 0f);

            currSeconds += Time.deltaTime;
            yield return null;
        }
    }

}
