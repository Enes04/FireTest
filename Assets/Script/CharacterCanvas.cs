using System;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCanvas : MonoBehaviour
{
    public Slider armor;
    public Slider health;

    public Health characterHealth;
    private void Awake()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
        characterHealth = GetComponentInParent<Health>();
    }

    private void FixedUpdate()
    {
        armor.value = characterHealth.armor;
        health.value = characterHealth.health;
        
       transform.rotation = Quaternion.LookRotation(transform.position-Camera.main.transform.position);
    }
}
