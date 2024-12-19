using UnityEngine;
using UnityEngine.Tilemaps;

/**
 * This component manages the boat's interactions.
 * Handles player pickup, updates allowed tiles for movement, and ensures compatibility with the game system.
 */
public class Boat : MonoBehaviour {
    [SerializeField] AllowedTiles allowedTiles = null;

    private bool isPickedUp = false; // Tracks whether the boat is picked up.

    /**
     * Handles the player's interaction with the boat.
     * Updates allowed tiles when the boat is picked up.
     * @param player The GameObject interacting with the boat.
     */
    public void OnPlayerInteraction(GameObject player) {
        if (!isPickedUp) {
            Debug.Log("Boat picked up by player!");
            isPickedUp = true;
            UpdateAllowedTilesForBoat();
        } else {
            Debug.Log("Boat is already being carried!");
        }
    }

    /**
     * Updates the allowed tiles to include water tiles when the boat is picked up.
     */
    private void UpdateAllowedTilesForBoat() {
        TileBase[] waterTiles = { /* Add the specific water tiles here */ };
        allowedTiles.UpdateAllowedTiles(waterTiles);
        Debug.Log("Allowed tiles updated for boat movement.");
    }

    /**
     * Resets the boat's state when dropped by the player.
     * Updates allowed tiles back to the default state.
     * @param player The GameObject dropping the boat.
     */
    public void OnPlayerDrop(GameObject player) {
        if (isPickedUp) {
            Debug.Log("Boat dropped by player.");
            isPickedUp = false;
            ResetAllowedTiles();
        }
    }

    /**
     * Resets the allowed tiles back to the default state.
     */
    private void ResetAllowedTiles() {
        TileBase[] defaultTiles = { /* Add default tiles here */ };
        allowedTiles.UpdateAllowedTiles(defaultTiles);
        Debug.Log("Allowed tiles reset after boat drop.");
    }
}
