using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardGameOverPanel : MonoBehaviour
{
    [SerializeField]
    private string nextFailSceneName;

    public void OnAppearingEnd()
    {
        // 다음 씬 넘어가기
        SceneManager.LoadScene(nextFailSceneName);
        //Debug.Log("다음 씬 넘어가기 코드 넣기");
    }
}

