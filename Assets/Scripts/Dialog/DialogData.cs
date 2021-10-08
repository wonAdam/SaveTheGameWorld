using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChacterNames
{
    나래이션,
    사수,
    갸갸,
    경고음,

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
