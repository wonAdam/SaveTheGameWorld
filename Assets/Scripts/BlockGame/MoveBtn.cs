using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBtn : MonoBehaviour
{
    [SerializeField] Bar bar;

    public void RightBtn()
    {
        bar.vec_bar = 1;
    }
    public void LeftBtn()
    {
        bar.vec_bar = -1;

    }
    public void stopBtn()
    {
        bar.vec_bar = 0;
    }
}
