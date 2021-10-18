using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterNames
{
    Narration,
    Sasu,
    GyaGya,
    AlertSound,
    Neighbors,
    Hero,
    FemaleCharacter,
    MaleCharacter,
}

[CreateAssetMenu (fileName = "New Dialog Data", menuName = "Dialog Data/New Dialog Data", order = 0)]
public class DialogData : ScriptableObject
{
    public static Dictionary<CharacterNames, string> characterNameMap
        = new Dictionary<CharacterNames, string>()
    {
        { CharacterNames.Narration, "나레이션" },
        { CharacterNames.GyaGya, "갸갸" },
        { CharacterNames.Sasu, "사수" },
        { CharacterNames.Hero, "용사" },
        { CharacterNames.Neighbors, "주변 사람들" },
        { CharacterNames.AlertSound, "경고음" },
        { CharacterNames.FemaleCharacter, "여자주인공" },
        { CharacterNames.MaleCharacter, "남자주인공" },
    };

    [SerializeField]
    public Sprite backgroundImage;

    [SerializeField]
    public Sprite characterOneImage;

    [SerializeField]
    public Sprite characterTwoImage;

    [SerializeField]
    public string dialogContent;

    [SerializeField]
    public CharacterNames dialogCharacterName;

    [SerializeField]
    public string placeName;

    [SerializeField]
    public bool isAllowToSkipWithTouch = true;

    [SerializeField]
    public AudioClip sfx;
}
