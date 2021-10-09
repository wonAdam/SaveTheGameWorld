using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] GameObject gameMeue;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject gameClearText;
    [SerializeField] GameObject gameClearMenu;
    [SerializeField] GameObject gameStartBtn;
    [SerializeField] Ball ball;
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
        // 타이틀로 돌아가는 버튼
    }
    public void endGame()
    {
        //게임 종료 버튼

    }
    public void retry()
    {
        // 게임 재시작
    }
    public void gameOver()  //일단 게임 오버 문구 출력 후 화면 아무데나 클릭하면 재시작 혹은 타이틀로 메뉴 띄워두게 해놨음
    {
        gameOverText.SetActive(false);
        // 게임 오버시 대화 출력
        gameOverMenu.SetActive(true);
    }
    public void gameClear()  //일단 게임 클리어 문구 출력 후 화면 아무데나 클릭하면 다음챕터 혹은 타이틀로 메뉴 띄워두게 해놨음
    {
        gameClearText.SetActive(false);
        // 게임 클리어시 대화 출력
        gameClearMenu.SetActive(true);
    }
    public void nextChapter()
    {
        // 다음 챕터로 이동
    }
    public void gameStart()
    {
        Destroy(gameStartBtn);
        ball.vec_Ball = Vector2.down;
        ball.initVec = (ball.vec_Ball * ball.velocity_Ball).normalized * ball.speed;
        ball.rigid_Ball.velocity = ball.initVec;
        ball.curVec = ball.initVec;
    }
}
