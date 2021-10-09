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

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip flipSound;


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

    //ī�� �ո� �̹��� ��������
    public void ShowFrontImage()
    {
        isFront = true;

        // Front�� ������ �ִϸ��̼� �÷���
        anim.SetBool("IsOpen", true);
    }

    //ī�� �޸� �̹��� ��������
    public void ShowBackImage()
    {
        isFront = false;

        // Back�� ������ �ִϸ��̼� �÷���
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

    public void PlayFlipSound()
    {
        audioSource.PlayOneShot(flipSound);
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
        // �ƹ� ī�嵵 ������ ������������ ������
        // �ش� ī�尡 �̹� �����ְų� �׷��� Lock�Ǿ�����
        // �׸��� ������ ���۵��� �ʾ����� ���ͷ�����������.
        if(!IsAnyCardOpening && !flipLocked && CardGameManager.isPlaying)
        {
            anim.SetBool("IsOpen", !anim.GetBool("IsOpen"));
            cardGameManager.CheckIfSameCardFlipped(this);
        }
    }
}
