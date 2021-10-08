using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Dialog Manager는 Dialog씬마다 배치합니다.
/// Canvas의 Animator를 참조하여 대화를 진행합니다. (아마 Canvas에 붙이는게 나을듯)
/// Animator의 State가 어디까지 됐는지도 체크하여 유지합니다.
/// </summary>
public class DialogManager : SimpleSingletonBehaviour<DialogManager>
{
    [SerializeField /*DEBUG*/]
    public int currDialogIndex = 0;

    [SerializeField]
    public Image backgroundImage;

    [SerializeField]
    public Image characterOneImage;

    [SerializeField]
    public Image characterTwoImage;

    [SerializeField]
    public TextMeshProUGUI dialogContentText;

    [SerializeField]
    public TextMeshProUGUI dialogCharacterNameText;

    [SerializeField]
    public List<DialogData> dialogDatas;


    protected override void Awake()
    {
        base.Awake();   
    }

    public void PlayDialogWithIndex(int index)
    {
        // 우선 그냥 Set하는 거로... 나중에 애니메이션 추가할 예정
        dialogContentText.text = dialogDatas[index].dialogContent;
        dialogCharacterNameText.text = dialogDatas[index].dialogCharacterName;
        characterOneImage.sprite = dialogDatas[index].characterOneImage;
        characterTwoImage.sprite = dialogDatas[index].characterTwoImage;
        backgroundImage.sprite = dialogDatas[index].backgroundImage;
    }

}
