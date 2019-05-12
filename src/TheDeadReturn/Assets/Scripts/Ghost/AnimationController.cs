    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator GhostAnimation;
    public Ghost gh;
    // Start is called before the first frame update
    void Start()
    {
        GhostAnimation = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo AInfo = GhostAnimation.GetCurrentAnimatorStateInfo(0);
        if(AInfo.normalizedTime>=0.8f)
        {
            SetShouldAttackFalse(gh.type);
        }
    }

    public void AttackAnimationOnce(GhostType type)
    {
        if(type == GhostType.GT_Green)
            GhostAnimation.Play("Solider_Green_Attack");
        else if(type == GhostType.GT_Blue)
            GhostAnimation.Play("Solider_Blue_Attack");
        else if(type == GhostType.GT_Red)
            GhostAnimation.Play("Solider_Red_Attack");
        //GhostAnimation.SetBool("ShouldPlayAttack", true);
        Invoke("Test", 0.15f);
        //Debug.Log(GhostAnimation.GetBool("ShouldPlayAttack"));
        //anima.Play("Solider_Green_Attack");
    }

    public void SetShouldAttackFalse(GhostType type)
    {
        //GhostAnimation.SetBool("ShouldPlayAttack", false);
        if(type==GhostType.GT_Green)
            GhostAnimation.Play("Solider_Green");
        else if(type==GhostType.GT_Blue)
            GhostAnimation.Play("Solider_Blue");
        else if(type==GhostType.GT_Red)
            GhostAnimation.Play("Solider_Red");
    }

    void Test()
    {

    }
}
