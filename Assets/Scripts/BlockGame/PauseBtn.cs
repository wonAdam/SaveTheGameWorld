using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBtn : MonoBehaviour
{
    [SerializeField] GameObject gameMeue;
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
}
