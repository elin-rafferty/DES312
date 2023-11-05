using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//https://www.youtube.com/watch?v=f81F2onEtY8

public class Stamina : MonoBehaviour
{

    public float stamina;
    float maxStamina;
    public float gravity = 20.0f;
    private float currentGravity;

    public Slider staminaSlider;
    public float dValue;

    private object collision;

    // Start is called before the first frame update
    void Start()
    {
        maxStamina = stamina;
        staminaSlider.maxValue = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        {
            if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.S) || (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.D)))))
                DecreaseEnergy();
            else if (stamina != maxStamina)
                IncreaseEnergy();

            staminaSlider.value = stamina;
        }

    }

    public void Collision(Collision collision)
    {
        if (collision.gameObject.tag == "jumpBoost")
            if (Input.GetKey(KeyCode.Space))
        {
            JumpDecreaseEnergy();
        }
    }

    private void DecreaseEnergy()
    {
        if(stamina != 0)
            stamina -= dValue * Time.deltaTime; 
    }

    private void JumpDecreaseEnergy()
    {
        if (stamina != 0)
            stamina -= dValue * Time.deltaTime * Time.deltaTime;
    }

    private void IncreaseEnergy()
    {
            stamina += dValue * Time.deltaTime;
    }

    private void Dead()
    {
        if (stamina == 0)
        {

        }
            
    }

 
}
