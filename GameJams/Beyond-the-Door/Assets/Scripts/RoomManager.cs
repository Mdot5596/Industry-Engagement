using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject keyPrefab;       // Reference to the key prefab
    public Transform keySpawnPoint;    // Position where the key will spawn
    private int enemiesInRoom;         // Track number of enemies in the room
    private bool keySpawned = false;   // Flag to check if key has spawned

    void Start()
    {
        // Initialize the number of enemies in the room when the scene starts
        InitializeEnemies();
    }

    void InitializeEnemies()
    {
        // Get all enemy objects that are children of this room
        EnemyAI[] enemies = GetComponentsInChildren<EnemyAI>();
        enemiesInRoom = enemies.Length;

        // Debugging: Check how many enemies are initialized
        Debug.Log("Enemies in room: " + enemiesInRoom);

        // Link each enemy to the room manager (optional, depending on your logic)
        foreach (EnemyAI enemy in enemies)
        {
            enemy.roomManager = this;
        }
    }

    // This method is called when an enemy is defeated
    public void EnemyDefeated()
    {
        // Decrease the enemy count when one is defeated
        enemiesInRoom--;

        // Debugging: Check if the enemy count is being updated correctly
        Debug.Log("Enemy defeated. Enemies left: " + enemiesInRoom);

        // Check if all enemies are defeated and the key has not yet spawned
        if (enemiesInRoom <= 0 && !keySpawned)
        {
            keySpawned = true; // Mark that the key has been spawned
            DropKey(); // Spawn the key at the end
        }
    }

    // Method to spawn the key after the final enemy is defeated
    private void DropKey()
    {
        Instantiate(keyPrefab, keySpawnPoint.position, Quaternion.identity); // Spawn the key
        Debug.Log("Key dropped after the last enemy defeated.");
    }

    // Method to reset the room (called when the player dies or the room is reset)
    public void ResetRoom()
    {
        // Reset the key spawn flag and the enemy count
        keySpawned = false;
        
        // Reinitialize the enemies (e.g., respawn them or reset their count)
        InitializeEnemies();

        // Debugging: Make sure the room is reset correctly
        Debug.Log("Room reset. Enemies in room: " + enemiesInRoom);
    }
}
