using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeGruntAI : MonoBehaviour
{    
    public GameObject Alien;
    public UnityEngine.AI.NavMeshAgent agent;
    public Transform player;
    public LayerMask groundDetection, playerDetection;
    CharControl playerCode;
    //public GameObject pivot; will need this if it decides to fall through the floor

    //Patrol variables
    public Vector3 patrolPoint;
    bool patrolPointSet;
    public float patrolPointRange;

    //Attacking variables
    public float timeBetweenAttacks;
    bool hasAttacked;

    //State deciding variables
    public float chaseRange, attackRange; //set attack range in inspector, make long for range
    public bool playerInChaseRange, playerInAttackRange;

    //Enemy stats
    public int health = 5;
    public int dmgDealt = 5;

    public Transform projectileSpawner; //empty game object on enemy, where projectile spawns from
    public GameObject projectileObject; //prefabbed projectile
    public float projectileSpeed = 5; //change for balancing

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        playerCode = player.GetComponent<CharControl>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Update()
    {
        playerInChaseRange = Physics.CheckSphere(transform.position, chaseRange, playerDetection);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerDetection);

        if (!playerInChaseRange && !playerInAttackRange)
        {
            Patrolling();
        }
        else if (playerInChaseRange && !playerInAttackRange)
        {
            chasePlayer();
        }
        else if (playerInChaseRange && playerInAttackRange)
        {
            AttackPlayer();
        }
        //pivot.transform.LookAt(player);
        gameObject.transform.rotation = new Quaternion(0f, transform.rotation.y, 0f, transform.rotation.w);
    }

    private void Patrolling()
    {
        if (patrolPointSet)
        {
            GeneratePatrolPoint();
        }

        if (patrolPointSet)
        {
            agent.SetDestination(patrolPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - patrolPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            patrolPointSet = false;
        }
    }

    private void GeneratePatrolPoint()
    {
        float randomZ = Random.Range(-patrolPointRange, patrolPointRange);
        float randomX = Random.Range(-patrolPointRange, patrolPointRange);

        patrolPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(patrolPoint, -transform.up, 2f, groundDetection))
        {
            patrolPointSet = true;
        }
    }

    private void chasePlayer()
    {
        agent.SetDestination(player.position);
        //insert animation bollocks here
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        //more animation BS (if melee no further code needed here)

        if (!hasAttacked)
        {
            var projectile = Instantiate(projectileObject, projectileSpawner.position, projectileSpawner.rotation);
            projectile.GetComponent<Rigidbody>().velocity = projectileSpawner.forward * projectileSpeed;
            //audio
            hasAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        hasAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        print(health); //debugging only, remove for final product
        if (health <= 0)
        {
            DestroyRangeGrunt();
        }
    }

    public void DestroyRangeGrunt()
    {
        Destroy(gameObject);
    }

    //in case of errnoeous player damage, send this to the shadowlands
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided"); //debugging only again
        if (other.tag == "Player")
        {
            playerCode.TakeDamage(dmgDealt);
        }
    }
}
