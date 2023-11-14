using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

//https://www.youtube.com/watch?v=f81F2onEtY8

public class Stamina : MonoBehaviour
{

    public float stamina;
    float maxStamina;
    public float gravity = 20.0f;


    public Slider staminaSlider;
    public float dValue = 10f;


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
            if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.S) ||  Input.GetKey(KeyCode.D))))
                DecreaseEnergy();
            else if (stamina != maxStamina)
                IncreaseEnergy();

            staminaSlider.value = stamina;
        }
        Jump();
        staminaSlider.value = stamina;
    }

    private void Jump()
    {
        {
            if (Input.GetKeyDown(KeyCode.Space))
                DecreaseEnergyJump();
        }

        staminaSlider.value = stamina;

    }

    private void DecreaseEnergyJump()
    {
        if (stamina != 0)
            stamina -= 15f; 
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
            stamina -= 40f;

    }

    private void IncreaseEnergy()
    {
            stamina += dValue * Time.deltaTime * 1f;
        
    }

    private void Dead()
    {
        if (stamina == 0)
        {

        }
            
    }

 
}
