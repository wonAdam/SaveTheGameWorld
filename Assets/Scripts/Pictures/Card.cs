using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    //�̹��� ��ȣ
    int imgNum = 1;

    //ī�� �޸� �̹��� ��ȣ
    int backNum = 1;

    //���µ� ī���� �Ǻ�
    bool cardOpen = false;

    Animator anim;

    public bool isFront = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    //ī�� �ո� �̹��� ��������
    public void ShowImage()
    {
        isFront = true;
        //transform.GetComponent<Renderer>().material.mainTexture = Resouces.Load("CARD" + imgNum) as Texture2D;
    }
    //ī�� �޸� �̹��� ��������
    public void BackImage()
    {
        isFront = false;
        //transform.GetComponent<Renderer>().material.mainTexture = Resouces.Load("BACK" + backNum) as Texture2D;
    }
}
