using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : SimpleSingletonBehaviour<DialogManager>
{
    [SerializeField /*DEBUG*/] 
    private int currDialogIndex = 0;

    [SerializeField]
    private Canvas mainCanvas;

    //[SerializeField]
    //private DialogPanel dialogPanel;

    //[SerializeField]
    //private CharacterPanel characterPanel;


    protected override void Awake()
    {
        base.Awake();   
    }

    private void Start()
    {
        
    }
}
