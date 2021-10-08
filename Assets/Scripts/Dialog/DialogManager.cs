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
    [Range(0f, 1f)]
    public float allowMoveToNextRatio;

    [SerializeField]
    public DialogSpriteSwapper backgroundImage;

    [SerializeField]
    public DialogSpriteSwapper characterOneImage;

    [SerializeField]
    public DialogSpriteSwapper characterTwoImage;

    [SerializeField]
    public DialogPlaceText placeText;

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
        dialogContentText.text = dialogDatas[index].dialogContent;
        dialogCharacterNameText.text = dialogDatas[index].dialogCharacterName.ToString();
        characterOneImage.SwapSprite(dialogDatas[index].characterOneImage);
        characterTwoImage.SwapSprite(dialogDatas[index].characterTwoImage);
        backgroundImage.SwapSprite(dialogDatas[index].backgroundImage);
        placeText.ShowPlaceText(dialogDatas[index].placeName);
    }


    public void SetPlaceText(int index)
    {
        placeText.ShowPlaceText(dialogDatas[index].placeName);
        dialogContentText.text = dialogDatas[index].dialogContent;
        dialogCharacterNameText.text = dialogDatas[index].dialogCharacterName.ToString();
        characterOneImage.SwapSprite(dialogDatas[index].characterOneImage);
        characterTwoImage.SwapSprite(dialogDatas[index].characterTwoImage);
        backgroundImage.SwapSprite(dialogDatas[index].backgroundImage);
    }

}
