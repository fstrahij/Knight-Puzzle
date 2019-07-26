using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource knightMove;
    public AudioSource coinCollect;
    public AudioSource cantMove;
    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic.Play();
    }

    public void KnightMovePlay()
    {
        knightMove.Play();
    }

    public void CoinCollectPlay()
    {
        coinCollect.Play();
    }

    public void CantMove()
    {
        cantMove.Play();
    }
}
