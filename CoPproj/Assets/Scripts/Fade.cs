// KHOGDEN 001115381
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class Fade : MonoBehaviour
    {
        public static Fade instance;
        [SerializeField] bool fadeOut;

        private Animator anim;

        // KH - Called before 'void Start()'.
        void Awake()
        {
            instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            anim.SetBool("FadeOut", fadeOut);
        }
    }
}