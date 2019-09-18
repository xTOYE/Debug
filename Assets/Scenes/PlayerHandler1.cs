using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Errors 12
namespace Debugging.Player
{
    public class PlayerHandler1 : MonoBehaviour
    {
        [Header("Value Variables")]
        public float curHealth;
        public float curMana;
        public float curStamina;
        public float maxHealth;
        public float maxMana;
        public float maxStamina;
        [Header("Value Variables")]
        public Slider healthBar;
        public Slider manaBar;
        public Slider staminaBar;
        [Header("Damage Effect Variables")]
        public Image damageImage;
        public Image deathImage;
        public float flashSpeed = 5;
        public Color flashColour = new Color(1, 0, 0, 0.2f);
        public static bool isDead;
        bool damaged;

        [Header("Check Point")]
        public Transform curCheckPoint;

        void Update()
        {
            //Display Health
            if (healthBar.value != Mathf.Clamp01(curHealth / maxHealth))
            {
                curHealth = Mathf.Clamp(curHealth, 0, maxHealth);
                healthBar.value = Mathf.Clamp01(curHealth / maxHealth);
            }
            if (manaBar.value != Mathf.Clamp01(curMana / maxMana))
            {
                curMana = Mathf.Clamp(curMana, 0, maxMana);
                manaBar.value = Mathf.Clamp01(curMana / maxMana);
            }
            if (staminaBar.value != Mathf.Clamp01(curStamina / maxStamina))
            {
                curStamina = Mathf.Clamp(curStamina, 0, maxStamina);
                staminaBar.value = Mathf.Clamp01(curStamina / maxStamina);
            }
            if (curHealth <= 0 && !isDead)
            {
                Death();
            }
            //Damage

            if (Input.GetKeyDown(KeyCode.X))
            {
                damaged = true;
                curHealth -= 5;
            }

            if (damaged & !isDead)
            {
                damageImage.color = flashColour;
                damaged = false;
            }
            else
            {
                //Flash Damage Image
                damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            }

        }
        void Death()
        {
            //Set the death flag to this function isnt called again
            isDead = true;
            //Fade Canvas from transparent to Black
            deathImage.gameObject.GetComponent<Animator>().SetTrigger("isDead");
            Invoke("Revive", 3f);
        }
        void Revive()
        {
            isDead = false;
            curHealth = maxHealth;
            curMana = maxMana;
            curStamina = maxStamina;

            //more and rotate to spawn location
            this.transform.position = curCheckPoint.position;
            this.transform.rotation = curCheckPoint.rotation;
            //Fade Canvas from Black to transparent
            deathImage.gameObject.GetComponent<Animator>().SetTrigger("Revive");
        }
       
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("CheckPoint"))
            {
                curCheckPoint = other.transform;
            }
        }
    }
}
