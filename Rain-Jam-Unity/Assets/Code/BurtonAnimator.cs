using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurtonAnimator : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public List<Sprite> sprites;
    
    public float secondsBetweenFrames;

    public void Start()
    {
        StartCoroutine(LoopIdle());
    }

    private IEnumerator LoopIdle()
    { 
        for (int i = 0; i < sprites.Count; i++) 
        {
            spriteRenderer.sprite = sprites[i];
            yield return new WaitForSeconds(secondsBetweenFrames);
        }
        StartCoroutine(LoopIdle());
    }
}
