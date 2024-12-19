using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

/**
 * This component manages a list of allowed tiles.
 * The list can be updated dynamically based on game interactions.
 */
public class AllowedTiles : MonoBehaviour  {
    [SerializeField] TileBase[] allowedTiles = null;

    /**
     * Checks if a tile is in the allowed tiles list.
     * @param tile The tile to check.
     * @return True if the tile is allowed, otherwise false.
     */
    public bool Contains(TileBase tile) {
        return allowedTiles.Contains(tile);
    }

    /**
     * Retrieves the current list of allowed tiles.
     * @return An array of allowed tiles.
     */
    public TileBase[] Get() { 
        return allowedTiles;  
    }

    /**
     * Updates the allowed tiles dynamically during gameplay.
     * @param newTiles An array of TileBase objects to set as the new allowed tiles.
     */
    public void UpdateAllowedTiles(TileBase[] newTiles) {
        if (newTiles == null || newTiles.Length == 0) {
            Debug.LogError("New allowed tiles array is null or empty!");
            return;
        }
        allowedTiles = newTiles;
        Debug.Log("Allowed tiles updated successfully!");
    }
}
