using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player2DBombSpawner : MonoBehaviour
{
    public Tilemap activePlayingTilemap;
    public GameObject bombPrefab;

    public float spawnCooldown = 1f;
    private float cooldownTimer = 0f;

    private void Update()
    {
        // Decrease the cooldown timer over time
        cooldownTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E) && cooldownTimer <= 0f)
        {
            SpawnBomb();
            // Reset the cooldown timer after spawning the bomb
            cooldownTimer = spawnCooldown;
        }
    }

    private void SpawnBomb()
    {
        Vector3 facingDirection = GetFacingDirection();

        Vector3 worldPos = transform.position;
        Vector3Int cell = activePlayingTilemap.WorldToCell(worldPos);
        Vector3 cellCenterPos = activePlayingTilemap.GetCellCenterLocal(cell);

        GameObject bomb = Instantiate(bombPrefab, cellCenterPos, Quaternion.identity);

        bomb.GetComponent<Bomb>().DelayedCollisionEnabled();

        // Optional: Add velocity to the bomb if needed
        Rigidbody2D bombRigidbody = bomb.GetComponent<Rigidbody2D>();
        if (bombRigidbody != null)
        {
            float bombSpeed = 5f; // Adjust speed as needed
            bombRigidbody.velocity = facingDirection * bombSpeed;
        }
    }

    private Vector3 GetFacingDirection()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) direction += Vector3.up;
        if (Input.GetKey(KeyCode.S)) direction += Vector3.down;
        if (Input.GetKey(KeyCode.A)) direction += Vector3.left;
        if (Input.GetKey(KeyCode.D)) direction += Vector3.right;
        // Normalize the direction to ensure consistent magnitude
        return direction.normalized;
    }
}