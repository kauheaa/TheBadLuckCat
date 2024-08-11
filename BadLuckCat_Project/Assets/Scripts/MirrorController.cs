using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MirrorController : MonoBehaviour
{
    public Sprite[] mirrorPieces;
    public Image mirrorFrame;


    private void Start()
    {
        mirrorFrame = GetComponent<Image>();

    }

    public void AddPieceToMirror(int mirrorAmount)
    {
        mirrorFrame.sprite = mirrorPieces[mirrorAmount];
    }
}