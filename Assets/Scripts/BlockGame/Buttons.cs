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
    public void retry()
    {
        // 게임 재시작
        SceneManager.LoadScene("BlockGame");
    }
    public void gameOver()  //일단 게임 오버 문구 출력 후 화면 아무데나 클릭하면 재시작 혹은 타이틀로 메뉴 띄워두게 해놨음
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Feature_DialogC2Fail");

    }
    public void gameClear()  //일단 게임 클리어 문구 출력 후 화면 아무데나 클릭하면 다음챕터 혹은 타이틀로 메뉴 띄워두게 해놨음
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Feature_DialogC2Success");
    }
    public void gameStart()
    {
        Time.timeScale = 1;
        gameStartBtn.SetActive(false);
        ball.vec_Ball = Vector2.down;
        ball.initVec = (ball.vec_Ball * ball.velocity_Ball).normalized * ball.speed;
        ball.rigid_Ball.velocity = ball.initVec;
        ball.curVec = ball.initVec;
    }
}