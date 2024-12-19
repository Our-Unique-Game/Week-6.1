using UnityEngine;
using UnityEngine.Tilemaps;

/**
 * This component manages the goat's interactions.
 * Handles player pickup, updates allowed tiles for movement, and ensures compatibility with the game system.
 */
public class Goat : MonoBehaviour {
    [SerializeField] AllowedTiles allowedTiles = null;

    [SerializeField] private bool isPickedUp = false; // Tracks whether the goat is picked up.

    /**
     * Handles the player's interaction with the goat.
     * Updates allowed tiles when the goat is picked up.
     * @param player The GameObject interacting with the goat.
     */
    public void OnPlayerInteraction(GameObject player) {
        if (!isPickedUp) {
            Debug.Log("Goat picked up by player!");
            isPickedUp = true;
            UpdateAllowedTilesForGoat();
        } else {
            Debug.Log("Goat is already being carried!");
        }
    }

    /**
     * Updates the allowed tiles to include goat-friendly terrain when picked up.
     */
    private void UpdateAllowedTilesForGoat() {
        TileBase[] goatAllowedTiles = { /* Add specific tiles here (e.g., grass) */ };
        allowedTiles.UpdateAllowedTiles(goatAllowedTiles);
        Debug.Log("Allowed tiles updated for goat movement.");
    }

    /**
     * Resets the goat's state when dropped by the player.
     * Updates allowed tiles back to the default state.
     * @param player The GameObject dropping the goat.
     */
    public void OnPlayerDrop(GameObject player) {
        if (isPickedUp) {
            Debug.Log("Goat dropped by player.");
            isPickedUp = false;
            ResetAllowedTiles();
        }
    }

    private void ResetAllowedTiles() {
        TileBase[] defaultTiles = allowedTiles.Get();
        
        if (allowedTiles != null) {
            allowedTiles.UpdateAllowedTiles(defaultTiles); // Ensure this method matches the type
            Debug.Log("Allowed tiles reset after boat drop.");
        } else {
            Debug.LogError("AllowedTiles reference is null!");
        }
    }
}
