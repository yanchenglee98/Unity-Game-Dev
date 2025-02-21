﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SkeletonEnemy : Enemy1
{
    public Animator animator;



    public override void TakeDamage(int damage)
    {
        health -= damage;
        VirtualCamera.GetComponent<SimpleCameraShakeInCinemachine>().smallshake();

        if (health <= 0)
        {
            animator.Play("Skeleton_Death");
            Die();
        } else
        {
            animator.Play("Skeleton_Damage");
        }
    }

    public override void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject, 1f); // delay destroying of enemy to allow animation to play
        camRipple.RippleEffect();
        VirtualCamera.GetComponent<SimpleCameraShakeInCinemachine>().shake();

    }


}