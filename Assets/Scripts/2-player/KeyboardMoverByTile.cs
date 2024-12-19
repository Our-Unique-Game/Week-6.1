using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

/**
 * This component allows the player to move using the arrow keys,
 * but only if the new position is on an allowed tile. 
 * It also handles interactions with items like the boat and goat.
 */
public class KeyboardMoverByTile : KeyboardMover {
    [SerializeField] Tilemap tilemap = null;
    [SerializeField] AllowedTiles allowedTiles = null;
    [SerializeField] private bool isCarryingItem = false; // Tracks whether the player is carrying an item.

    /**
     * Gets the tile at a given world position.
     * @param worldPosition The world position to check.
     * @return The TileBase object at the specified position.
     */
    private TileBase TileOnPosition(Vector3 worldPosition) {
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
        return tilemap.GetTile(cellPosition);
    }

    /**
     * Updates player movement and handles interactions with items.
     */
    [SerializeField] private Pickaxe pickaxe = null; // Reference to the pickaxe script

    void Update() {
        Vector3 newPosition = NewPosition();
        TileBase tileOnNewPosition = TileOnPosition(newPosition);

        if (allowedTiles.Contains(tileOnNewPosition)) {
            transform.position = newPosition;

            // Interact with items if present
            HandleInteraction(tileOnNewPosition);
        }

        // Handle pickaxe use
        if (pickaxe != null && Input.GetKeyDown(KeyCode.Space)) {
            pickaxe.TryTransformTile(transform.position);
        }
    }


    /**
     * Handles interactions when the player moves onto a tile with an item.
     * @param tile The tile that the player has moved onto.
     */
    private void HandleInteraction(TileBase tile) {
        // Example interaction logic:
        if (tile.name == "Boat") { // Replace with the actual name of the boat tile.
            Debug.Log("Player picked up the boat!");
            isCarryingItem = true;
            UpdateAllowedTilesForBoat();
        } else if (tile.name == "Goat") { // Replace with the actual name of the goat tile.
            Debug.Log("Player picked up the goat!");
            isCarryingItem = true;
            UpdateAllowedTilesForGoat();
        }
    }

    /**
     * Updates allowed tiles for when the player carries the boat.
     */
    private void UpdateAllowedTilesForBoat() {
        TileBase[] newAllowedTiles = { /* Add water and other relevant tiles here */ };
        allowedTiles.UpdateAllowedTiles(newAllowedTiles);
        Debug.Log("Allowed tiles updated for carrying the boat.");
    }

    /**
     * Updates allowed tiles for when the player carries the goat.
     */
    private void UpdateAllowedTilesForGoat() {
        TileBase[] newAllowedTiles = { /* Add grass and other relevant tiles here */ };
        allowedTiles.UpdateAllowedTiles(newAllowedTiles);
        Debug.Log("Allowed tiles updated for carrying the goat.");
    }
}
