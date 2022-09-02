using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    private Vector3 moveDelta;
    

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float  x = Input.GetAxisRaw("Horizontal"); 
        // Input.GetAxisRaw("Horizontal") is going to return either a -1, 0, or 1
        // -1 = A (Left arrow)
        // 0 = Not any keys
        // 1 = D (Right arrow)
        float y = Input.GetAxisRaw("Vertical");
        
        // Reset theMoveDelta
        moveDelta = new Vector3(x,y, 0);
        
        // Swap sprite direction, whether you're going right or left
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        
        // Make everything move
        transform.Translate(moveDelta * Time.deltaTime);
        // Since FixedUpdate runs every frame, frame rate is different on faster/slower devices. Multiplying
        // the moveDelta by deltaTime is going to regulate the speed of movement across all devices
    }
}
