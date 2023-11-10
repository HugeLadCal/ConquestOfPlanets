// KHOGDEN 001115381
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace interactable
{
    public class Door : MonoBehaviour
    {
        // KH - The distance the player needs to be for the door to open.
        [SerializeField] float doorOpenDistance = 3f;
        [SerializeField] bool locked;
        private bool open;

        // KH - Reference for how far the player is to the door.
        private Transform player;
        private float playerDist;

        private Collider col;
        private Animator anim;

        // KH - Called before 'void Start()'.
        private void Awake()
        {
            col = GetComponent<Collider>();
            anim = GetComponent<Animator>();
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        // KH - Called on a constant timeline.
        private void FixedUpdate()
        {
            // KH - Open/close door based on how far the player is from it.
            playerDist = Vector3.Distance(player.position, transform.position);

            if (!locked)
                open = playerDist < doorOpenDistance;
            else
                open = false;

            // KH - Continously update parameters in animator for opening/closing door.
            anim.SetBool("Open", open);
        }
    }
}