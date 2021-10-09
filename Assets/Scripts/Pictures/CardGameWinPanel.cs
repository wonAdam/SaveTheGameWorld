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
        // ���� �� �Ѿ��
        SceneManager.LoadScene(nextSuccessSceneName);
        //Debug.Log("���� �� �Ѿ�� �ڵ� �ֱ�");
    }
}
