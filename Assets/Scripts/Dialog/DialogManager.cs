using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Dialog Manager�� Dialog������ ��ġ�մϴ�.
/// Canvas�� Animator�� �����Ͽ� ��ȭ�� �����մϴ�. (�Ƹ� Canvas�� ���̴°� ������)
/// Animator�� State�� ������ �ƴ����� üũ�Ͽ� �����մϴ�.
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
        // �켱 �׳� Set�ϴ� �ŷ�... ���߿� �ִϸ��̼� �߰��� ����
        dialogContentText.text = dialogDatas[index].dialogContent;
        dialogCharacterNameText.text = dialogDatas[index].dialogCharacterName;
        characterOneImage.sprite = dialogDatas[index].characterOneImage;
        characterTwoImage.sprite = dialogDatas[index].characterTwoImage;
        backgroundImage.sprite = dialogDatas[index].backgroundImage;
    }

}
