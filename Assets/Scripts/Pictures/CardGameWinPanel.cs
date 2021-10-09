using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardGameWinPanel : MonoBehaviour
{
    [SerializeField]
    private string nextSuccessSceneName;

    public void OnAppearingEnd()
    {
        // 다음 씬 넘어가기
        SceneManager.LoadScene(nextSuccessSceneName);
        //Debug.Log("다음 씬 넘어가기 코드 넣기");
    }
}
