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

    public bool badLedge = false;


    // Start is called before the first frame update
    void Start()
    {
        maxStamina = stamina;
        staminaSlider.maxValue = maxStamina;

    }

    // Update is called once per frame
    void Update()
    {
        //movement();
       // Jump();
        staminaSlider.value = stamina;
        if (badLedge == true)
        {
            LedgeDecreaseEnergy();
        }
    }

  

    //private void movement()
    //{
    //    {
    //        if (input.getkey(keycode.w) || (input.getkey(keycode.a) || (input.getkey(keycode.s) || input.getkey(keycode.d))))
    //            decreaseenergy();
    //        else if (stamina != maxstamina)
    //            increaseenergy();
             
    //        staminaslider.value = stamina;
    //    }
    //}

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

    public void DecreaseEnergy()
    {
        if(stamina != 0)
            stamina -= dValue * Time.deltaTime; 
    }

    private void JumpDecreaseEnergy()
    {
        if (stamina != 0)
            stamina -= 0f;
    }

    private void LedgeDecreaseEnergy()
    {
        if (stamina != 0)
            stamina -= dValue * Time.deltaTime * 2f;
    }
    public void ChangeStamina(float staminaAmount)
    {
        stamina += staminaAmount * Time.deltaTime;
    }

    private void IncreaseEnergy()
    {
            stamina += dValue * Time.deltaTime * 1f;     
    }
}
