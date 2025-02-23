using UnityEngine;
using System.Collections;

public class SmoothCameraFollow : MonoBehaviour
{
    #region SINGLETON
    public static SmoothCameraFollow Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public Transform target;  // Player to follow
    public float smoothSpeed = 5f;  // Adjust for smoothness
    public Vector2 minBounds, maxBounds;  // Camera limits

    private void FixedUpdate()
    {
        if (target == null) 
            return;

        // Compute target position with offset
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

        // Clamp within bounds
        targetPosition.x = Mathf.Clamp(targetPosition.x, minBounds.x, maxBounds.x);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minBounds.y, maxBounds.y);

        // Smoothly follow the target
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}