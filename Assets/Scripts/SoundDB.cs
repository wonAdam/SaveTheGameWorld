using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundEnum
{
    Button,
    Block,
    Card,
    Kiss,
    Siren,
    Smash,
    Sword,
    GameOver,
    GameClear,
}

[CreateAssetMenu (fileName = "AudioDB", menuName = "AudioDB", order = 0)]
public class SoundDB : ScriptableObject
{
    [SerializeField]
    public AudioClip buttonClip;

    [SerializeField]
    public AudioClip blockClip;

    [SerializeField]
    public AudioClip cardClip;

    [SerializeField]
    public AudioClip kissClip;

    [SerializeField]
    public AudioClip sirenClip;

    [SerializeField]
    public AudioClip smashClip;

    [SerializeField]
    public AudioClip swordClip;

    [SerializeField]
    public AudioClip gameOverClip;

    [SerializeField]
    public AudioClip gameClearClip;

    private static bool isInit = false;
    public static AudioClip GetAudioClip(SoundEnum soundType)
    {
        if (!isInit)
        {
            isInit = true;
            Init();
        }

        soundDictionary.TryGetValue(soundType, out AudioClip result);
        return result;
    }

    private static void Init()
    {
        SoundDB db = Resources.Load<SoundDB>("AudioDB");
        soundDictionary = new Dictionary<SoundEnum, AudioClip>()
        {
            { SoundEnum.Button, db.buttonClip },
            { SoundEnum.Block, db.blockClip },
            { SoundEnum.Card, db.cardClip },
            { SoundEnum.Kiss, db.kissClip },
            { SoundEnum.Siren, db.sirenClip },
            { SoundEnum.Smash, db.smashClip },
            { SoundEnum.Sword, db.swordClip },
            { SoundEnum.GameOver, db.gameOverClip },
            { SoundEnum.GameClear, db.gameClearClip },
        };
    }

    private static Dictionary<SoundEnum, AudioClip> soundDictionary;

}
