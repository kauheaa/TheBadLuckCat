using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class levelManager : MonoBehaviour
{
    public static levelManager instance;

    public Transform respawnPoint;
    public GameObject playerPrefab;

    

    private void Awake()
    {
        instance = this;
    }
    public void Respawn()
    {
        GameObject kissa = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
        
    }
}
