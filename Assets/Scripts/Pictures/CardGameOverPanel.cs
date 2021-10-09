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
        // ���� �� �Ѿ��
        SceneManager.LoadScene(nextFailSceneName);
        //Debug.Log("���� �� �Ѿ�� �ڵ� �ֱ�");
    }
}

