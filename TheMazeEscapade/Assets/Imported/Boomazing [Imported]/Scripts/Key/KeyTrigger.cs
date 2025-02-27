using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrigger : MonoBehaviour
{
    // Hover Properties
    public Transform target;


    [SerializeField] private float amplitude = 0.5f;
    [SerializeField] private float frequency = 0.5f;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = target.position;
    }

    private void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * frequency) * amplitude;
        target.position = new Vector3(startPosition.x, newY, startPosition.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LevelObjectives.Instance.hasKey = true;
            Destroy(gameObject);
        }
    }
}