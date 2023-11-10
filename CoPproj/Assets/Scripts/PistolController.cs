using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolController : MonoBehaviour
{
    //add colliders to all targets (enemies)
    public GameObject Weapon;
    public bool canAttack = true;
    public float timeBetweenAttacks = 1.0f;
    public bool isAttacking = false;
    public AudioSource source;
    public AudioClip shot;
    public AudioClip enemyHit;
    public AudioClip missHit;

    public int damage = 1;
    public float range = 100f;


    public Camera fpsCam;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(canAttack)
                {
                Attack();
            }
        }
    }

    public void Attack()
    {
        RaycastHit hit;
        source.PlayOneShot(shot);
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            GruntAI grunt = hit.transform.GetComponent<GruntAI>();
            RangeGruntAI rangeGrunt = hit.transform.GetComponent<RangeGruntAI>();
            BossAI boss = hit.transform.GetComponent<BossAI>();

            if (grunt != null)
            {
                grunt.TakeDamage(damage);
                source.PlayOneShot(enemyHit);
            }
            if (rangeGrunt != null)
            {
                rangeGrunt.TakeDamage(damage);
                source.PlayOneShot(enemyHit);
            }
            if (boss != null)
            {
                boss.TakeDamage(damage);
                source.PlayOneShot(enemyHit);
            }
            else
            {
                source.PlayOneShot(missHit);
            }
        }
    }
}
