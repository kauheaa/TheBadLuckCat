using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{



   public int Respawn;

    private MirrorController mirrorController;
   
    void Start()
    {
        mirrorController = FindObjectOfType<MirrorController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Death"))
        {

            SceneSwitcher.instance.OnDeath();

        }

       
    }
}