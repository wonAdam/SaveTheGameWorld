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
    }
    
    public void ChangeImage(Sprite newImage)
    {
        backgroundImage.sprite = newImage;
    }


    public void SwapSprite(Sprite newSprite)
    {
        StopAllCoroutines();
        if(imageOne.color.a == 0f)
        {
            StartCoroutine(SwapSpriteCoroutine(imageTwo, imageOne, newSprite));
        }
        else
        {
            StartCoroutine(SwapSpriteCoroutine(imageOne, imageTwo, newSprite));
        }
    }

    private IEnumerator SwapSpriteCoroutine(Image imageToTurnOff, Image imageToTurnOn, Sprite newSprite)
    {
        float turnOnAlpha = 0.0f;
        float currSeconds = 0.0f;
        while(true)
        {
            turnOnAlpha = currSeconds / swapSeconds;
            //imageToTurnOff.color.a = 1f - turnOnAlpha;
            //imageToTurnOn.color.a = 1f - turnOnAlpha;
            //imageToTurnOn.SetSprite

            currSeconds += Time.deltaTime;
            yield return null;
        }
    }

}
