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

    //전체 제한 시간 
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
            //남은 시간을 감소시켜준다.
            setTime -= Time.deltaTime;

            // 전체시간이 60초 미만일 때
            if (setTime < 60f)
            {
                gameTimeUI.text = "남은 시간 : " + (int)setTime + "초";
            }

            // 남은 시간이 0보다 작아질 때
            if (setTime <= 0)
            {
                // UI 텍스트를 0초로 고정시킴.
                gameTimeUI.text = "남은 시간 : 0초";

                // 게임 오버 로직
                StartCoroutine(GameOverAfterSeconds(1f, 0.5f));
            }

        }
    }

    private IEnumerator GameOverAfterSeconds(float secondsBeforePanel, float secondsBeforeSceneLoad)
    {
        // flip을 막고
        FindObjectsOfType<Card>().ToList().ForEach(card => card.flipLocked = true);

        // seconds만큼 멈추고
        yield return new WaitForSeconds(secondsBeforePanel);

        // 게임오버 패널을 보여줌
        GameOver.SetActive(true);
    }



    //스테이지 만들기
    public void MakeStage()
    {
        Shuffling();

        for(int i = 0; i < cards.Length; ++i)
        {
            cards[i].frontImage.sprite = cardSprites[i];
            cards[i].cardGameManager = this;
        }
    }


    //카드 섞기
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
        // 모든 카드가 flipLocked이면 전부 맞게 뒤집은것이다.
        foreach(var card in cards)
        {
            if(!card.flipLocked)
                return false;
        }

        return true;
    }

    [HideInInspector]
    private Card cardOnFrontFace = null;
    //정답 확인
    public void CheckIfSameCardFlipped(Card cardFlipped)
    {
        // 이전에 뒤집은 카드가 있고
        if(cardOnFrontFace != null)
        {
            // 방금 뒤집은 카드와 이전에 뒤집은 카드가 같은 카드라면
            if(Card.IsSameCards(cardFlipped, cardOnFrontFace))
            {
                cardFlipped.flipLocked = true;
                cardOnFrontFace.flipLocked = true;
                cardOnFrontFace = null;
                    
                notTheSameCard = false;

                if(CheckIfAllCardFlipped())
                {
                    // 게임 승리 로직
                    GameWinPanel.SetActive(true);

                    SaveManager.SavePlayer(new PlayerData(1));

                    isPlaying = false;
                }
            }
            else
            {
                // 같은 카드가 아니니
                // 둘다 뒤집고
                // 이전에 뒤집은 카드를 null로 
                notTheSameCard = true;
                cardOnFrontFace = null;
            }
        }
        // 이전에 뒤집은 카드가 없다면
        else
        {
            cardOnFrontFace = cardFlipped;
            notTheSameCard = false;
        }
    }

    //도전 실패
    public void DestroyStage()
    {
        //for (int i = 1; i <= 12; i++) //남은 카드 앞면 표시
        //{
        //    if (arrHit[i] == 1)
        //    {
        //        continue;
        //    }
        //    GameObject card = GameObject.FindWithTag("CARD" + i);

        //    //yield WaitForSeconds(0.25);
        //}

        //GameOver.text = "You Failed";

        ////게임 처음으로 이동
        //SceneManager.LoadScene("GameTitle");

    }


}
