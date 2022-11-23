using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>(); // or this.GetComponent<Animator>() or transform.GetComponent<Animator>()
    }
    public void Walk(bool move)
    {
        anim.SetBool(AnimationTags.MOVEMENT, move);
    }

    public void Punch_1()
    {
        anim.SetTrigger(AnimationTags.PUNCH1);
    }

    public void Punch_2()
    {
        anim.SetTrigger(AnimationTags.PUNCH2);
    }

    public void Punch_3()
    {
        anim.SetTrigger(AnimationTags.PUNCH3);
    }

    public void Kick_1()
    {
        anim.SetTrigger(AnimationTags.KICK1);
    }

    public void Kick_2()
    {
        anim.SetTrigger(AnimationTags.KICK2);
    }

    public void Death()
    {
        anim.SetTrigger(AnimationTags.DEATH_TRIGGER);
    }


    //Enemy animation
    public void EnemyAttack(int attack)
    {
        if (attack == 0)
        {
            anim.SetTrigger(AnimationTags.ATTACK1);
        }
        if (attack == 1)
        {
            anim.SetTrigger(AnimationTags.ATTACK2);
        }
        if (attack == 2)
        {
            anim.SetTrigger(AnimationTags.ATTACK3);
        }
    } //enemy attack

    public void Play_IdleAnimation()
    {

        anim.Play(AnimationTags.IDLE_ANIMATION);
    } //enemy idle



    public void KnockDown()
    {
        anim.SetTrigger(AnimationTags.KNOCK_DOWN_TRIGGER);
    } //enemy knockDown

    public void StandUp()
    {
        anim.SetTrigger(AnimationTags.STAND_UP_TRIGGER);
    } //enemy standUp

    public void Hit()
    {
        anim.SetTrigger(AnimationTags.HIT_TRIGGER);
    } //enemy hit
}//class
