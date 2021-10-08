using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
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

    int arrCards = new int[13]; //ī�� ��ȣ
    int arrHit = new int[13]; //ī�� �յ� ����
 
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
        // ���� �ð��� ���ҽ����ش�.
        setTime -= Time.deltaTime;
      
        // ��ü�ð��� 60�� �̸��� ��
        if (setTime < 60f)
        {
            gameTime.text = "���� �ð� : " + (int)setTime + "��";
        }

        // ���� �ð��� 0���� �۾��� ��
        if (setTime <= 0)
        {
            // UI �ؽ�Ʈ�� 0�ʷ� ������Ŵ.
            gameTime.text = "���� �ð� : 0��";
        }
    }

    //�������� �ʱ�ȭ
    public void ClearStage()
    {
        touchCnt = 0;
        cardNum = 0;
        lastNum = 0;
        hitCnt = 0;

        MakeStage();
    }


    //�������� �����
    public void MakeStage()
    {
        Shuffling();

        var x = 0; //����ī���� x��ǥ
        var z = 0; //����ī���� y��ǥ

        for (int i = 1; i <= 12; i++)
        {
            var card = Instantiate(Resources.Load("Prefab/Card")); //Resources������ �ִ� Prefab ������Ʈ ȣ��
            
            card.transform.position = Vector3(x, 0, z); //ī���ġ

            //�±� ����
            card.tag = "CARD" + arrCards[i];

            
            if (i % 3 == 0)
            {

            }

            yield WaitForSeconds(0.025);

    }
    }

    //ī�� ����
    public void Shuffling()
    {
        for(int i = 1; i <= 12; i++)
        {
            arrCards[i] = i; //ī�� ��ȣ �ֱ�
            arrHit[i] = 0; //��� ī�� ������ ����
        }

        for (i= 1; i <= 10; i++)//ī�� ����(10ȸ)
        {
            int r1 = Random.Range(1, 13);
            int r2 = Random.Range(1, 13);

            //�� ��ȯ�ϱ�
            int temp = arrCards[r1];
            arrCards[r1] = arrCards[r2];
            arrCards[r2] = temp;

        }


    }
    

    //���� Ȯ��
    public void CheckCard()
    {
        touchCnt++;

        if(lastNum==0)
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
        if(hitCnt==12)
        {
            SetClear();
        }
        
    }

    //���� ����
    public void DestroyStage()
    {
        for (int i = 1; i <= 12; i++) //���� ī�� �ո� ǥ��
        {
            if(arrHit[i]==1)
            {
                continue;
            }
            GameObject card = GameObject.FindWithTag("CARD" + i);
            
            yield WaitForSeconds(0.25);    
        }
        
        GameOver.text = "You Failed";
        
        //���� ó������ �̵�
        SceneManager.LoadScene("GameTitle");

    }

    //���� ���������� �̵�
    public void NextStage()
    {
        for (int i = 1; i <= 12; i++)
        {
            GameObject card = GameObject.FindWithTag("CARD" + i);
            Destroy(card);
        }
    }

}
