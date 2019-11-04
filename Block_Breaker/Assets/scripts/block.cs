using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    //so it can be edited from unity too not only from here
    [SerializeField] AudioClip breakSound;

    Level level;

    void Start()
    {
        //find object and assign to level
        level = FindObjectOfType<Level>();

        //add 1 to breakableBlocoks
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        FindObjectOfType<GameStatus>().AddToScore();
        Destroy(this.gameObject);

        level.BlockDestroyed();
    }


}
