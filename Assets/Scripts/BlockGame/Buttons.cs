using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] GameObject gameMeue;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject gameClearText;
    [SerializeField] GameObject gameStartBtn;
    [SerializeField] Ball ball;
    private void Start()
    {
        gameMeue.SetActive(false);
        gameStartBtn.SetActive(true);
    }
    public void pauseBtn()
    {
        gameMeue.SetActive(true);
    }
    public void resumeBtn()
    {
        gameMeue.SetActive(false);
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
        SceneManager.LoadScene("BlockGame");
    }
    public void gameOver()  //�ϴ� ���� ���� ���� ��� �� ȭ�� �ƹ����� Ŭ���ϸ� ����� Ȥ�� Ÿ��Ʋ�� �޴� ����ΰ� �س���
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Feature_DialogC2Fail");

    }
    public void gameClear()  //�ϴ� ���� Ŭ���� ���� ��� �� ȭ�� �ƹ����� Ŭ���ϸ� ����é�� Ȥ�� Ÿ��Ʋ�� �޴� ����ΰ� �س���
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Feature_DialogC2Success");
    }
    public void gameStart()
    {
        gameStartBtn.SetActive(false);
        ball.vec_Ball = Vector2.down;
        ball.initVec = (ball.vec_Ball * ball.velocity_Ball).normalized * ball.speed;
        ball.rigid_Ball.velocity = ball.initVec;
        ball.curVec = ball.initVec;
    }
}