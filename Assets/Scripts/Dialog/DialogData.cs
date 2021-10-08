using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChacterNames
{
    �����̼�,
    ���,
    ����,
    �����,

}

[CreateAssetMenu (fileName = "New Dialog Data", menuName = "Dialog Data/New Dialog Data", order = 0)]
public class DialogData : ScriptableObject
{
    [SerializeField]
    public Sprite backgroundImage;

    [SerializeField]
    public Sprite characterOneImage;

    [SerializeField]
    public Sprite characterTwoImage;

    [SerializeField]
    public string dialogContent;

    [SerializeField]
    public ChacterNames dialogCharacterName;

    [SerializeField]
    public string placeName;

    [SerializeField]
    public bool isAllowToSkipWithTouch = true;
}
