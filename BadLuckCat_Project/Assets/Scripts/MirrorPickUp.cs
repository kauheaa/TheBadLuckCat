using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MirrorPickUp : MonoBehaviour
{
    public int mirrorPiece = 0;
    public GameObject winScreen;
    public MirrorController mirrorController;
    public Image mirrorFrame;


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "MirrorPiece")
        {
            mirrorPiece++;
            mirrorController.AddPieceToMirror(mirrorPiece);
            Destroy(other.transform.parent.gameObject);
            FMODUnity.RuntimeManager.PlayOneShot("event:/MirrorPickUp", GetComponent<Transform>().position);

            if (mirrorPiece == 7)
            {
                winScreen.SetActive(true);
                Time.timeScale = 0f;
                mirrorFrame.GetComponent<Image>().enabled = false;
            }
        }
    }
}