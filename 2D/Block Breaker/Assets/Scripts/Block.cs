using System;
using UnityEngine;

public class Block : MonoBehaviour {

    //Configuration parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    //Cached reference
    //Every breakable block is going to call Level.CountBreakableBlocks() in the start method
    //so the Level class is going to know how many blocks are in the scene
    Level level;

    //State variables
    [SerializeField] int timesHit;  //TODO: Serialized for debugging purposes

    private void Start() {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable") {
            level.CountBreakableBlocks();
        }            
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (tag == "Breakable") {
            timesHit++;
            int maxHits = hitSprites.Length + 1;
            if (timesHit >= maxHits) {
                DestroyBlock();
            } else {
                int spriteIntex = timesHit - 1;
                if (hitSprites[spriteIntex] != null) {
                    GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIntex];
                } else {
                    Debug.LogError("Sprite is missing from array. " + gameObject.name);
                }
            }
        }
    }

    private void DestroyBlock() {
        //Add points when block is destroyed
        FindObjectOfType<GameSession>().AddToScore();

        //Creates an AudioSource which play sound in the specified vector (transform)
        AudioSource.PlayClipAtPoint(breakSound, transform.position);
        //AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);

        //Creates particle effect
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);

        //El parámetro collision contiene el game object (en este caso Ball) que hizo colisión con Block
        //Debug.Log(collision.gameObject.name);
        Destroy(gameObject);    //gameObject es en este caso 'this bock'

        //Tell the Level that the block was destroyed
        level.BlockDestroyed();

        //Destroy particle effect GO to avoid using so much memory
        Destroy(sparkles, 1);
    }
}
