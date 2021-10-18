using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CardGameManager : MonoBehaviour
{
    public static bool notTheSameCard = false;

    public static bool isPlaying = false;

    public Text gameTimeUI;

    [SerializeField]
    private GameObject GameOver;

    [SerializeField]
    private GameObject GameStartPanel;

    [SerializeField]
    private GameObject GameWinPanel;

    //ÀüÃ¼ Á¦ÇÑ ½Ã°£ 
    [SerializeField]
    private float setTime = 60f;
    
    private float sec = 0f;

    [SerializeField]
    public Card[] cards;

    [SerializeField]
    public Sprite[] cardSprites;


    void Start()
    {
        gameTimeUI.text = "남은 시간 : " + (int)setTime + "초";

        GameStartPanel.SetActive(true);

        MakeStage();
    }


    void Update()
    {
        if(isPlaying)
        {
            //³²Àº ½Ã°£À» °¨¼Ò½ÃÄÑÁØ´Ù.
            setTime -= Time.deltaTime;

            // ÀüÃ¼½Ã°£ÀÌ 60ÃÊ ¹Ì¸¸ÀÏ ¶§
            if (setTime < 60f)
            {
                gameTimeUI.text = "남은 시간 : " + (int)setTime + "초";
            }

            // ³²Àº ½Ã°£ÀÌ 0º¸´Ù ÀÛ¾ÆÁú ¶§
            if (setTime <= 0)
            {
                // UI ÅØ½ºÆ®¸¦ 0ÃÊ·Î °íÁ¤½ÃÅ´.
                gameTimeUI.text = "남은 시간 : 0초";

                // °ÔÀÓ ¿À¹ö ·ÎÁ÷
                StartCoroutine(GameOverAfterSeconds(1f, 0.5f));
            }

        }
    }

    private IEnumerator GameOverAfterSeconds(float secondsBeforePanel, float secondsBeforeSceneLoad)
    {
        // flipÀ» ¸·°í
        FindObjectsOfType<Card>().ToList().ForEach(card => card.flipLocked = true);

        // seconds¸¸Å­ ¸ØÃß°í
        yield return new WaitForSeconds(secondsBeforePanel);

        // °ÔÀÓ¿À¹ö ÆÐ³ÎÀ» º¸¿©ÁÜ
        GameOver.SetActive(true);
    }



    //½ºÅ×ÀÌÁö ¸¸µé±â
    public void MakeStage()
    {
        Shuffling();

        for(int i = 0; i < cards.Length; ++i)
        {
            cards[i].frontImage.sprite = cardSprites[i];
            cards[i].cardGameManager = this;
        }
    }


    //Ä«µå ¼¯±â
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

    private bool CheckIfAllCardFlipped()
    {
        // ¸ðµç Ä«µå°¡ flipLockedÀÌ¸é ÀüºÎ ¸Â°Ô µÚÁýÀº°ÍÀÌ´Ù.
        foreach(var card in cards)
        {
            if(!card.flipLocked)
                return false;
        }

        return true;
    }

    [HideInInspector]
    private Card cardOnFrontFace = null;
    //Á¤´ä È®ÀÎ
    public void CheckIfSameCardFlipped(Card cardFlipped)
    {
        // ÀÌÀü¿¡ µÚÁýÀº Ä«µå°¡ ÀÖ°í
        if(cardOnFrontFace != null)
        {
            // ¹æ±Ý µÚÁýÀº Ä«µå¿Í ÀÌÀü¿¡ µÚÁýÀº Ä«µå°¡ °°Àº Ä«µå¶ó¸é
            if(Card.IsSameCards(cardFlipped, cardOnFrontFace))
            {
                cardFlipped.flipLocked = true;
                cardOnFrontFace.flipLocked = true;
                cardOnFrontFace = null;
                    
                notTheSameCard = false;

                if(CheckIfAllCardFlipped())
                {
                    // °ÔÀÓ ½Â¸® ·ÎÁ÷
                    GameWinPanel.SetActive(true);

                    SaveManager.SavePlayer(new PlayerData(1));

                    isPlaying = false;
                }
            }
            else
            {
                // °°Àº Ä«µå°¡ ¾Æ´Ï´Ï
                // µÑ´Ù µÚÁý°í
                // ÀÌÀü¿¡ µÚÁýÀº Ä«µå¸¦ null·Î 
                notTheSameCard = true;
                cardOnFrontFace = null;
            }
        }
        // ÀÌÀü¿¡ µÚÁýÀº Ä«µå°¡ ¾ø´Ù¸é
        else
        {
            cardOnFrontFace = cardFlipped;
            notTheSameCard = false;
        }
    }

    //µµÀü ½ÇÆÐ
    public void DestroyStage()
    {
        //for (int i = 1; i <= 12; i++) //³²Àº Ä«µå ¾Õ¸é Ç¥½Ã
        //{
        //    if (arrHit[i] == 1)
        //    {
        //        continue;
        //    }
        //    GameObject card = GameObject.FindWithTag("CARD" + i);

        //    //yield WaitForSeconds(0.25);
        //}

        //GameOver.text = "You Failed";

        ////°ÔÀÓ Ã³À½À¸·Î ÀÌµ¿
        //SceneManager.LoadScene("GameTitle");

    }


}
