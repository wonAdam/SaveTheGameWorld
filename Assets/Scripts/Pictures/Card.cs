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

    public bool isFront = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    //카드 앞면 이미지 가져오기
    public void ShowImage()
    {
        isFront = true;
        //transform.GetComponent<Renderer>().material.mainTexture = Resouces.Load("CARD" + imgNum) as Texture2D;
    }
    //카드 뒷면 이미지 가져오기
    public void BackImage()
    {
        isFront = false;
        //transform.GetComponent<Renderer>().material.mainTexture = Resouces.Load("BACK" + backNum) as Texture2D;
    }
}
