using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    
    public Text gameTimeUI, GameOver;

    //전체 제한 시간 
    float setTime = 60;
    float sec;

    //직전의 카드 번호
    int lastNum = 0;

    //클릭한 카드 번호
    int cardNum = 0;

    //터치한 횟수
    int touchCnt = 0;

    //맞춘 카드 수
    int hitCnt = 0;

    int arrCards = new int[13]; //카드 번호
    int arrHit = new int[13]; //카드 앞뒤 구별
 
    void Start()
    {
        ClearStage();
        MakeStage();
        CheckCard();
        DestroyStage();
        NextStage();
    }

    
    void Update()
    {
        // 남은 시간을 감소시켜준다.
        setTime -= Time.deltaTime;
      
        // 전체시간이 60초 미만일 때
        if (setTime < 60f)
        {
            gameTime.text = "남은 시간 : " + (int)setTime + "초";
        }

        // 남은 시간이 0보다 작아질 때
        if (setTime <= 0)
        {
            // UI 텍스트를 0초로 고정시킴.
            gameTime.text = "남은 시간 : 0초";
        }
    }

    //스테이지 초기화
    public void ClearStage()
    {
        touchCnt = 0;
        cardNum = 0;
        lastNum = 0;
        hitCnt = 0;

        MakeStage();
    }


    //스테이지 만들기
    public void MakeStage()
    {
        Shuffling();

        var x = 0; //시작카드의 x좌표
        var z = 0; //시작카드의 y좌표

        for (int i = 1; i <= 12; i++)
        {
            var card = Instantiate(Resources.Load("Prefab/Card")); //Resources폴더에 있는 Prefab 오브젝트 호출
            
            card.transform.position = Vector3(x, 0, z); //카드배치

            //태그 설정
            card.tag = "CARD" + arrCards[i];

            
            if (i % 3 == 0)
            {

            }

            yield WaitForSeconds(0.025);

    }
    }

    //카드 섞기
    public void Shuffling()
    {
        for(int i = 1; i <= 12; i++)
        {
            arrCards[i] = i; //카드 번호 넣기
            arrHit[i] = 0; //모든 카드 뒤집은 상태
        }

        for (i= 1; i <= 10; i++)//카드 섞기(10회)
        {
            int r1 = Random.Range(1, 13);
            int r2 = Random.Range(1, 13);

            //값 교환하기
            int temp = arrCards[r1];
            arrCards[r1] = arrCards[r2];
            arrCards[r2] = temp;

        }


    }
    

    //정답 확인
    public void CheckCard()
    {
        touchCnt++;

        if(lastNum==0)
        {
            //현재 카드 보존
            lastNum = cardNum; 
            return;
        }

        
        int img1 = (cardNum + 1) / 2; //현재 카드 그림 번호
        int img2 = (lastNum + 1) / 2; //직전 카드 그림 번호

        //다른 카드일 경우
        if (img1 != img2)
        {
            lastNum = 0;
            return;
        }

        //같은 카드일 경우
        hitCnt += 2;

        //카드가 모두 열리면 스테이지 클리어
        if(hitCnt==12)
        {
            SetClear();
        }
        
    }

    //도전 실패
    public void DestroyStage()
    {
        for (int i = 1; i <= 12; i++) //남은 카드 앞면 표시
        {
            if(arrHit[i]==1)
            {
                continue;
            }
            GameObject card = GameObject.FindWithTag("CARD" + i);
            
            yield WaitForSeconds(0.25);    
        }
        
        GameOver.text = "You Failed";
        
        //게임 처음으로 이동
        SceneManager.LoadScene("GameTitle");

    }

    //다음 스테이지로 이동
    public void NextStage()
    {
        for (int i = 1; i <= 12; i++)
        {
            GameObject card = GameObject.FindWithTag("CARD" + i);
            Destroy(card);
        }
    }

}
