// KHOGDEN 001115381
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UI;

namespace interactable
{
    public class Turret : MonoBehaviour
    {
        [SerializeField] float interactDistance = 3f;
        [SerializeField] GameObject cannonBeam;
        [SerializeField] GameObject explosion;

        private Transform player;
        private PlayerUI playerUI;
        private float dist;
        private bool shownTip;

        public AudioSource source;
        public AudioClip explosionSound;

        // KH - Called before 'void Start()'.
        void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            playerUI = FindObjectOfType<PlayerUI>();
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
        void FixedUpdate()
        {
            // KH - Calculate distance with player and turret.
            dist = Vector3.Distance(player.position, transform.position);

            // KH - Check that player is in interacting distance with turret.
            if(dist < interactDistance)
            {
                // KH - Has the game told the player to press E yet?
                if(!shownTip)
                {
                    shownTip = true;
                    playerUI.DisplayTip("Press E to fire cannon.");
                }

                // KH - Check that player has pressed E.
                if(Input.GetKey(KeyCode.E))
                {
                    // KH - Display the explosion.
                    cannonBeam.SetActive(true);
                    explosion.SetActive(true);

                    source.PlayOneShot(explosionSound);
                }
            }
        }
    }
}