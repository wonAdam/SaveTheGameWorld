using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public string dialogCharacterName;
}
