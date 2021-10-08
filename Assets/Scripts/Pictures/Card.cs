using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
{
    public static bool IsAnyCardOpening = false;

    [HideInInspector] 
    public bool flipLocked = false;

    private Animator anim;

    [SerializeField /*DEBUG*/]
    public bool isFront = false;

    [SerializeField]
    private Sprite backImage;

    [SerializeField] 
    public SpriteRenderer frontImage;

    [HideInInspector] 
    public CardGameManager cardGameManager;

    void Start()
    {
        anim = GetComponent<Animator>();

        ShowBackImage();

        GetComponent<SpriteRenderer>().sprite = backImage;
        TurnOnBackFace();
    }

    public static bool IsSameCards(Card card1, Card card2)
    {
        return card1.frontImage.sprite == card2.frontImage.sprite;
    }

    //카드 앞면 이미지 가져오기
    public void ShowFrontImage()
    {
        isFront = true;

        // Front로 뒤집는 애니메이션 플레이
        anim.SetBool("IsOpen", true);
    }

    //카드 뒷면 이미지 가져오기
    public void ShowBackImage()
    {
        isFront = false;

        // Back로 뒤집는 애니메이션 플레이
        anim.SetBool("IsOpen", false);
    }

    // Animation Event
    public void TurnOnFrontFace()
    {
        frontImage.color = new Color(1f, 1f, 1f, 1f);
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
    }

    // Animation Event
    public void TurnOnBackFace()
    {
        frontImage.color = new Color(1f, 1f, 1f, 0f);
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }

    public void OnBeginOfCardAction()
    {
        if(CardGameManager.notTheSameCard)
        {
            StartCoroutine(ReverseFrontCardDelay());
        }
        else
        {
            IsAnyCardOpening = true;
        }
    }

    private IEnumerator ReverseFrontCardDelay()
    {
        yield return new WaitForSeconds(0.5f);

        CardGameManager.notTheSameCard = false;
        FindObjectsOfType<Card>()
            .Where(card => card.anim.GetBool("IsOpen") == true && card.flipLocked == false).ToList()
            .ForEach(card => card.anim.SetBool("IsOpen", false));

        IsAnyCardOpening = true;

    }

    public void OnEndOfCardAction()
    {
        IsAnyCardOpening = false;
    }

    private void OnMouseDown()
    {
        // 아무 카드도 열리고 있지않을때만 열리게
        if(!IsAnyCardOpening && !flipLocked)
        {
            anim.SetBool("IsOpen", !anim.GetBool("IsOpen"));
            cardGameManager.CheckIfSameCardFlipped(this);
        }
    }
}
