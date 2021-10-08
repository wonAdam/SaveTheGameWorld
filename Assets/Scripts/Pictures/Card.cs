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
