using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBtn : MonoBehaviour
{
    [SerializeField] Bar bar;
    [SerializeField] Animator animator;

    public void RightBtn()  //  바 오른쪽으로 움직이기
    {
        bar.vec_bar = 1;
        animator.SetInteger("state", 1);
    }
    public void LeftBtn()   //  바 왼쪽으로 움직이기
    {
        bar.vec_bar = -1;
        animator.SetInteger("state", 1);
    }
    public void stopBtn()   //  바 멈춰!
    {
        bar.vec_bar = 0;
        animator.SetInteger("state", 0);
    }
}
