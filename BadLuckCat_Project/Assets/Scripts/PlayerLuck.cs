using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLuck : MonoBehaviour
{
   
    [SerializeField]
    public Slider luckBar;

    public float startingLuck = 20f;
    public float maxLuck = 100f;
    public float minLuck = 0;
    [HideInInspector] public float currentLuck;

    private Animator animator;

    private int charms = 0;
    public TextMeshProUGUI textCharms;

    private void Start()
    {
        luckBar.value = startingLuck;
        currentLuck = luckBar.value;
        //Lisää Listener, method joka tarkistaa sliderin arvon
        luckBar.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        animator = GetComponentInChildren<Animator>();
    }

    //Tapahtuu vain sliderin arvon muuttuessa
    private void ValueChangeCheck()
    {
        Debug.Log(luckBar.value);
    }

    private void Update()
    {
        if (currentLuck <= 0)
        {
            PlayerDeath();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("LuckItem"))
        {
            charms++;
            textCharms.text = charms.ToString();
            Destroy(col.gameObject);
            luckBar.value += col.gameObject.GetComponent<LuckItem>().luckAmount;
            FMODUnity.RuntimeManager.PlayOneShot("event:/CharmPickUp", GetComponent<Transform>().position);
            currentLuck = luckBar.value;
        }

        if (col.gameObject.name == "Ladder")
        {
            luckBar.value -= 30f;
            currentLuck = luckBar.value;
        }
        //if (col.gameObject.tag == "Enemy")
        //{
        //    luckBar.value -= 1f;
        //    currentLuck = luckBar.value;
        //}
    }

    public void PlayerDeath()
    {        
        Destroy(this.gameObject);
        SceneSwitcher.instance.OnDeath();       
    }

}

