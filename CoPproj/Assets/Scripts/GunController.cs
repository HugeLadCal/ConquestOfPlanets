using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GunController : MonoBehaviour
{
    //add colliders to all targets (enemies)
    public GameObject Weapon;
    public bool canAttack = true;
    public float timeBetweenAttacks = 1.0f;
    public bool isAttacking = false;

    public int damage = 1;
    public float range = 100f;

    public int maxAmmo = 360;
    private int currentAmmo;

    public Camera fpsCam;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(currentAmmo > 0)
            {
                if (canAttack)
                {
                    Attack();
                }
            }          
        }
    }

    public void Attack()
    {
        currentAmmo--;
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            GruntAI grunt = hit.transform.GetComponent<GruntAI>();
            RangeGruntAI rangeGrunt = hit.transform.GetComponent<RangeGruntAI>();
            BossAI boss = hit.transform.GetComponent<BossAI>();

            if(grunt != null)
            {
                grunt.TakeDamage(damage);
            }
            if (rangeGrunt != null)
            {
                rangeGrunt.TakeDamage(damage);
            }
            if (boss != null)
            {
                boss.TakeDamage(damage);
            }
        }
    }
}
