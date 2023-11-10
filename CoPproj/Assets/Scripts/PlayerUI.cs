// KHOGDEN 001115381
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayerUI : MonoBehaviour
    {
        // KH - UI gameobject references.
        [SerializeField] TextMeshProUGUI tips;
        [SerializeField] TextMeshProUGUI ammo;
        [SerializeField] TextMeshProUGUI weaponName;
        [SerializeField] Slider healthSlider;

        // KH - Variables for displaying player's health.
        private float health = 100f;
        [SerializeField][Range(0.001f, 10f)] float healthBarLerpMultiplier = 5f;

        // KH - Alpha values for controlling grouped UI transparency.
        private float tipsAlpha;
        private float decreaseTipsAlphaTime;
        private float inventoryAlpha;
        private float decreaseInventoryAlphaTime;
        [SerializeField][Range(0.001f, 10f)] float fadeOutMultiplier = 0.2f;

        // KH - Canvas groups used for outputting alpha values.
        [SerializeField] CanvasGroup tipsCanvasGroup;
        [SerializeField] CanvasGroup inventoryCanvasGroup;

        // Update is called once per frame
        void Update()
        {
            // KH - Display the health amount on the health bar slider.
            float hl = Time.deltaTime * healthBarLerpMultiplier;
            healthSlider.value = Mathf.Lerp(healthSlider.value, health, hl);

            // KH - When this timer reaches zero, tips text will fade out.
            if (decreaseTipsAlphaTime > 0f)
                decreaseTipsAlphaTime -= Time.deltaTime;
            else
            {
                // KH - Make the tips text fade out.
                if (tipsAlpha > 0f)
                {
                    tipsAlpha -= Time.deltaTime * fadeOutMultiplier;

                    // KH - Prevent from going into negative values.
                    if (tipsAlpha < 0f)
                        tipsAlpha = 0f;
                }
            }

            // KH - When this timer reaches zero, inventory UI will fade out.
            if (decreaseInventoryAlphaTime > 0f)
                decreaseInventoryAlphaTime -= Time.deltaTime;
            else
            {
                // KH - Make the inventory UI fade out.
                if (inventoryAlpha > 0f)
                {
                    inventoryAlpha -= Time.deltaTime * fadeOutMultiplier;

                    // KH - Prevent from going into negative values.
                    if (inventoryAlpha < 0f)
                        inventoryAlpha = 0f;
                }
            }

            // KH - Output alpha value into the canvas group components.
            tipsCanvasGroup.alpha = tipsAlpha;
            inventoryCanvasGroup.alpha = inventoryAlpha;
        }

        // KH - Functions for displaying information on the player UI.

        // KH - Update the health bar to share a inputted value.
        public void DisplayHealth(float newHealth)
        {
            health = newHealth;
        }

        // KH - Display ammunition information on the UI.
        public void DisplayAmmo(int currentMagAmmo, int bulletsLeft)
        {
            ammo.text = currentMagAmmo + "/" + bulletsLeft;
        }

        // KH - Display a weapon's name within the inventory UI.
        public void DisplayWeaponName(string name)
        {
            decreaseInventoryAlphaTime = 3f;
            inventoryAlpha = 1f;
            weaponName.text = name;
        }

        // KH - Display a tip through the 'tips' text.
        public void DisplayTip(string tipMessage)
        {
            // Set the delay time for tips text fading out.
            decreaseTipsAlphaTime = 3f;
            tipsAlpha = 1f;
            tips.text = tipMessage;
        }
    }
}