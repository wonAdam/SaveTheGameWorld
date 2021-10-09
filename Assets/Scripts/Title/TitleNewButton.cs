using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleNewButton : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(
            () => SceneManager.LoadScene(nextSceneName)
            );
    }

}
