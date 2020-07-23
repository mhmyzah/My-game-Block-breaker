using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config
    [SerializeField] AudioClip blockBreakSound ;
    [SerializeField] GameObject vxEffect;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites; 

    //cach
    Level level ;
    GameStatus status;
    //sate vars
    [SerializeField] int timesHits;
    private void Start()
    {
        CountBreakableBlocks();
        status = FindObjectOfType<GameStatus>();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "BreakableBlocks")
        {
            level.CountBreakAbleBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandelHits();

    }

    private void HandelHits()
    {
        if (tag == "BreakableBlocks")
        {

            timesHits++;
            if (timesHits >= maxHits)
            {
                DestroyBlock();
            }
            else
                ShowNextHitSprites();

        }
    }

    private void ShowNextHitSprites()
    {
      
            int spritesIndex = timesHits - 1;
        if (hitSprites[spritesIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spritesIndex];
        }
        else
        {
            Debug.LogError("There is eror inm sporite"+ gameObject.name);
        }
        }

    private void DestroyBlock()
    {
        PlaySparkel();
        AudioSource.PlayClipAtPoint(blockBreakSound, Camera.main.transform.position);
        Destroy(gameObject, 0);
        level.BlockDistroyed();
        status.AddScore();
    }
    private void PlaySparkel()
    {
        GameObject sparke = Instantiate(vxEffect, transform.position, transform.rotation);
        Destroy(sparke,2f);


    }
}
