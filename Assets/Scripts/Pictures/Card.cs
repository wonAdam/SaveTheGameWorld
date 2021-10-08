using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    //이미지 번호
    int imgNum = 1;

    //카드 뒷면 이미지 번호
    int backNum = 1;

    //오픈된 카드의 판별
    bool cardOpen = false;

    Animator anim;

    [SerializeField /*DEBUG*/]
    public bool isFront = false;

    [SerializeField]
    private Sprite backImage;

    [SerializeField] 
    public SpriteRenderer frontImage;

    void Start()
    {
        anim = GetComponent<Animator>();

        ShowBackImage();

        GetComponent<SpriteRenderer>().sprite = backImage;
        TurnOnBackFace();
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

    public void TurnOnFrontFace()
    {
        frontImage.color = new Color(1f, 1f, 1f, 1f);
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
    }

    public void TurnOnBackFace()
    {
        frontImage.color = new Color(1f, 1f, 1f, 0f);
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }

}
