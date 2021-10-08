using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField] GameObject gameMeue;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject gameClearText;
    [SerializeField] GameObject gameClearMenu;
    private void Start()
    {
        gameMeue.SetActive(false);
    }
    public void pauseBtn()
    {
        gameMeue.SetActive(true);
        Time.timeScale = 0;
    }
    public void resumeBtn()
    {
        gameMeue.SetActive(false);
        Time.timeScale = 1;
    }
    public void titleBtn()
    {
        // Ÿ��Ʋ�� ���ư��� ��ư
    }
    public void endGame()
    {
        //���� ���� ��ư

    }
    public void retry()
    {
        // ���� �����
    }
    public void gameOver()  //�ϴ� ���� ���� ���� ��� �� ȭ�� �ƹ����� Ŭ���ϸ� ����� Ȥ�� Ÿ��Ʋ�� �޴� ����ΰ� �س���
    {
        gameOverText.SetActive(false);
        // ���� ������ ��ȭ ���
        gameOverMenu.SetActive(true);
    }
    public void gameClear()  //�ϴ� ���� Ŭ���� ���� ��� �� ȭ�� �ƹ����� Ŭ���ϸ� ����é�� Ȥ�� Ÿ��Ʋ�� �޴� ����ΰ� �س���
    {
        gameClearText.SetActive(false);
        // ���� Ŭ����� ��ȭ ���
        gameClearMenu.SetActive(true);
    }
    public void nextChapter()
    {
        // ���� é�ͷ� �̵�
    }
}
