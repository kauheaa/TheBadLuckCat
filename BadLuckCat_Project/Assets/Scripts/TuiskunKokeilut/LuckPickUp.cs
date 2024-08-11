using UnityEngine;

public class LuckPickUp : MonoBehaviour
{
    PlayerLuck playerLuck;


    public float luckGain = 20f;

    private void Awake()
    {
        playerLuck = FindObjectOfType<PlayerLuck>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (playerLuck.currentLuck < playerLuck.maxLuck)
        {
            Destroy(gameObject);
            playerLuck.currentLuck = playerLuck.currentLuck + luckGain;

        }

    }

}
