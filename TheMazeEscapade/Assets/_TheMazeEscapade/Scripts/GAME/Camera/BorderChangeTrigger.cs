using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderChangeTrigger : MonoBehaviour
{
    private SmoothCameraFollow smoothCameraFollow => SmoothCameraFollow.Instance;

    public Vector2 newMinBounds, newMaxBounds;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            smoothCameraFollow.maxBounds = newMaxBounds;
            smoothCameraFollow.minBounds = newMinBounds;
        }
    }
}