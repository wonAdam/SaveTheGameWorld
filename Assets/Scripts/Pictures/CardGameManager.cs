using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CardGameManager : MonoBehaviour
{

    public Text gameTimeUI, GameOver;

    //��ü ���� �ð� 
    float setTime = 60;
    float sec;

    //������ ī�� ��ȣ
    int lastNum = 0;

    //Ŭ���� ī�� ��ȣ
    int cardNum = 0;

    //��ġ�� Ƚ��
    int touchCnt = 0;

    //���� ī�� ��
    int hitCnt = 0;

    int[] arrCards = new int[13]; //ī�� ��ȣ
    int[] arrHit = new int[13]; //ī�� �յ� ����

    [SerializeField]
    public Card[] cards;

    [SerializeField]
    public Sprite[] cardSprites;

    void Start()
    {
        InitStage();
        MakeStage();
    }


    void Update()
    {
        // ���� �ð��� ���ҽ����ش�.
        //setTime -= Time.deltaTime;

        //// ��ü�ð��� 60�� �̸��� ��
        //if (setTime < 60f)
        //{
        //    gameTimeUI.text = "���� �ð� : " + (int)setTime + "��";
        //}

        //// ���� �ð��� 0���� �۾��� ��
        //if (setTime <= 0)
        //{
        //    // UI �ؽ�Ʈ�� 0�ʷ� ������Ŵ.
        //    gameTimeUI.text = "���� �ð� : 0��";
        //}
    }

    //�������� �ʱ�ȭ
    public void InitStage()
    {
        touchCnt = 0;
        cardNum = 0;
        lastNum = 0;
        hitCnt = 0;
    }


    //�������� �����
    public void MakeStage()
    {
        Shuffling();

        for(int i = 0; i < cards.Length; ++i)
        {
            cards[i].frontImage.sprite = cardSprites[i];
        }
    }


    //ī�� ����
    public void Shuffling()
    {
        for (int i = 0; i < cardSprites.Length; ++i)
        {
            int rand = Random.Range(0, 12);
            Sprite temp = cardSprites[i];
            cardSprites[i] = cardSprites[rand];
            cardSprites[rand] = temp;
        }

    }


    //���� Ȯ��
    public void CheckCard()
    {
        touchCnt++;

        if (lastNum == 0)
        {
            //���� ī�� ����
            lastNum = cardNum;
            return;
        }


        int img1 = (cardNum + 1) / 2; //���� ī�� �׸� ��ȣ
        int img2 = (lastNum + 1) / 2; //���� ī�� �׸� ��ȣ

        //�ٸ� ī���� ���
        if (img1 != img2)
        {
            lastNum = 0;
            return;
        }

        //���� ī���� ���
        hitCnt += 2;

        //ī�尡 ��� ������ �������� Ŭ����
        if (hitCnt == 12)
        {
            //SetClear();
        }

    }

    //���� ����
    public void DestroyStage()
    {
        for (int i = 1; i <= 12; i++) //���� ī�� �ո� ǥ��
        {
            if (arrHit[i] == 1)
            {
                continue;
            }
            GameObject card = GameObject.FindWithTag("CARD" + i);

            //yield WaitForSeconds(0.25);
        }

        GameOver.text = "You Failed";

        //���� ó������ �̵�
        SceneManager.LoadScene("GameTitle");

    }


}
