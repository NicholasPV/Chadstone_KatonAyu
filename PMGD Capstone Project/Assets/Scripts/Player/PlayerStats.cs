using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    public float maxHealth;
    public float currentHealth;
    public float maxStamina;
    public float maxFreezing;
    public float freezingRecovery;
    public float currentFreezing;

    public bool isPlayerCanMove;
    public bool isPlayerInteract;
    public bool isPlayerDialogue;
    public bool isPlayerFreezing;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        isPlayerCanMove = true;
        currentHealth = maxHealth;
        currentFreezing = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPlayerInteract && !isPlayerDialogue)
        {
            isPlayerCanMove = true;
        }
        else
        {
            isPlayerCanMove = false;
            Debug.Log("Player cant move");
        }

        //Handle Freeze
        currentFreezing = Mathf.Clamp(currentFreezing, 0, maxFreezing);
        if(isPlayerFreezing == false)
        {
            currentFreezing -= freezingRecovery * Time.deltaTime;
        }
        
    }
}
