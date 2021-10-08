using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CardGameManager : MonoBehaviour
{
    public static bool notTheSameCard = false;

    public Text gameTimeUI;

    [SerializeField]
    private GameObject GameOver;

    //��ü ���� �ð� 
    [SerializeField]
    private float setTime = 60f;
    
    private float sec = 0f;

    [SerializeField]
    public Card[] cards;

    [SerializeField]
    public Sprite[] cardSprites;

    void Start()
    {
        MakeStage();
    }


    void Update()
    {
        //���� �ð��� ���ҽ����ش�.
        setTime -= Time.deltaTime;

        // ��ü�ð��� 60�� �̸��� ��
        if (setTime < 60f)
        {
            gameTimeUI.text = "���� �ð� : " + (int)setTime + "��";
        }

        // ���� �ð��� 0���� �۾��� ��
        if (setTime <= 0)
        {
            // UI �ؽ�Ʈ�� 0�ʷ� ������Ŵ.
            gameTimeUI.text = "���� �ð� : 0��";

            // ���� ���� ����
            StartCoroutine(GameOverAfterSeconds(1f));
        }
    }

    private IEnumerator GameOverAfterSeconds(float seconds)
    {
        // flip�� ����
        FindObjectsOfType<Card>().ToList().ForEach(card => card.flipLocked = true);

        // seconds��ŭ ���߰�
        yield return new WaitForSeconds(seconds);

        // ���ӿ��� �г��� ������
        GameOver.SetActive(true);
    }



    //�������� �����
    public void MakeStage()
    {
        Shuffling();

        for(int i = 0; i < cards.Length; ++i)
        {
            cards[i].frontImage.sprite = cardSprites[i];
            cards[i].cardGameManager = this;
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


    [HideInInspector]
    private Card cardOnFrontFace = null;
    //���� Ȯ��
    public void CheckIfSameCardFlipped(Card cardFlipped)
    {
        // ������ ������ ī�尡 �ְ�
        if(cardOnFrontFace != null)
        {
            // ��� ������ ī��� ������ ������ ī�尡 ���� ī����
            if(Card.IsSameCards(cardFlipped, cardOnFrontFace))
            {
                cardFlipped.flipLocked = true;
                cardOnFrontFace.flipLocked = true;
                cardOnFrontFace = null;
                    
                notTheSameCard = false;
            }
            else
            {
                // ���� ī�尡 �ƴϴ�
                // �Ѵ� ������
                // ������ ������ ī�带 null�� 
                notTheSameCard = true;
                cardOnFrontFace = null;
            }
        }
        // ������ ������ ī�尡 ���ٸ�
        else
        {
            cardOnFrontFace = cardFlipped;
            notTheSameCard = false;
        }
    }

    //���� ����
    public void DestroyStage()
    {
        //for (int i = 1; i <= 12; i++) //���� ī�� �ո� ǥ��
        //{
        //    if (arrHit[i] == 1)
        //    {
        //        continue;
        //    }
        //    GameObject card = GameObject.FindWithTag("CARD" + i);

        //    //yield WaitForSeconds(0.25);
        //}

        //GameOver.text = "You Failed";

        ////���� ó������ �̵�
        //SceneManager.LoadScene("GameTitle");

    }


}
