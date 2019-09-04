using UnityEngine;
using UnityEngine.UI;

public class HeartHealth : MonoBehaviour
{
    [Header("Player Stats")]
    public float curHealth;
    public float maxHealth;
    [Header("Heart Slots")]
    public Image[] heartSlots;
    public Sprite[] heartSprite;
    private float healthPerSection;

    private void Start()
    {
        //calculate the health points per heart section
        healthPerSection = maxHealth / (heartSlots.Length * 4);
    }

    private void Update()
    {
        UpdateHeart();
    }

    void UpdateHeart()
    {
        for (int i = 0; i < heartSlots.Length; i++)
        {
            //if out health is greater or equal to thos slot amout
            if (curHealth >= (healthPerSection * 4) + healthPerSection * 4 * i)
            {
                heartSlots[i].sprite = heartSprite[0];
            }
            else if (curHealth >= (healthPerSection * 3) + healthPerSection * 4 * i)
            {
                heartSlots[i].sprite = heartSprite[1];
            }
            else if (curHealth >= (healthPerSection * 2) + healthPerSection * 4 * i)
            {
                heartSlots[i].sprite = heartSprite[2];
            }
            else if (curHealth >= (healthPerSection * 1) + healthPerSection * 4 * i)
            {
                heartSlots[i].sprite = heartSprite[3];
            }
            else
            {
                heartSlots[i].sprite = heartSprite[4];
            }
        }
    }
}
