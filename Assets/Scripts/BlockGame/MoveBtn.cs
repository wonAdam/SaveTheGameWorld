using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBtn : MonoBehaviour
{
    [SerializeField] Bar bar;

    public void RightBtn()
    {
        bar.velocity_bar = 1;
    }
    public void LeftBtn()
    {
        bar.velocity_bar = -1;

    }
    public void stopBtn()
    {
        bar.velocity_bar = 0;
    }
}
