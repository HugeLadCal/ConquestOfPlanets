// KHOGDEN 001115381
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace interactable
{
    public class TipTrigger : MonoBehaviour
    {
        [SerializeField] string inputTipMessage;
        private PlayerUI playerUI;

        // KH - Called before 'void Start()'.
        private void Awake()
        {
            playerUI = FindObjectOfType<PlayerUI>();
        }

        // KH - Called when entering a trigger collider.
        private void OnTriggerEnter(Collider other)
        {
            playerUI.DisplayTip(inputTipMessage);
        }
    }
}