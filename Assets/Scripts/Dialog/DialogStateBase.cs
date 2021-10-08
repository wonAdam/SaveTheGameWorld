using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class DialogStateBase : StateMachineBehaviour
{
    [SerializeField]
    protected Image backgroundImage;

    [SerializeField]
    protected Image characterImage;

    [SerializeField]
    protected string dialogText;

}
