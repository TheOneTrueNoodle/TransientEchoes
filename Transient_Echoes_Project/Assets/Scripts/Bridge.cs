using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Physics2D.IgnoreLayerCollision(0, 6, true);
        if (other.GetComponent<PushBlock>())
        {
            other.GetComponent<PushBlock>().blockingWalls = LayerMask.GetMask("Wall");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Physics2D.IgnoreLayerCollision(0, 6, true);
             if (other.GetComponent<PushBlock>())
             {
                 other.GetComponent<PushBlock>().blockingWalls = LayerMask.GetMask("Wall");
             }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Physics2D.IgnoreLayerCollision(0, 6, false);
        if (other.GetComponent<PushBlock>())
        {
            other.GetComponent<PushBlock>().blockingWalls = LayerMask.GetMask("Dodgeable", "Wall");
        }
    }
}
