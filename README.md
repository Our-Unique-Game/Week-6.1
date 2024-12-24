# **Goat, Boat, and Pickaxe Interaction System - README**

Link to game:
https://github.com/Our-Unique-Game/Week-6.1

## **Overview**  
This system allows the player to interact with the **Goat**, **Boat**, and **Pickaxe** to dynamically update their movement capabilities and modify tiles on the tilemap. The interactions include picking up and dropping items to gain specific movement abilities and using the pickaxe to transform specific tiles in the game world.

---

## **Features**  
- **Dynamic Tile Updates:** Adds or removes tiles the player can move on based on item interactions.  
- **Item Interactions:** Enables the player to pick up and drop items like the **Goat**, **Boat**, and **Pickaxe**.  
- **Tile Transformation:** Allows the player to transform **mountain tiles** into **grass tiles** using the pickaxe.  
- **Configurable Settings:** Easily set up tile lists and transformation behavior in the **Inspector**.  

---

## **Scripts**

### **KeyboardMoverByTile.cs (Player Script)**  
- **Purpose:** Handles player movement, item interactions, and tile transformations.  
- **Key Settings:**
  - **Tilemap:** Reference to the tilemap for movement and transformations.  
  - **AllowedTiles:** Default list of tiles the player can move on.  
  - **PickaxeAllowedTiles:** Additional tiles allowed when the pickaxe is picked up.  
  - **transformFromTile / transformToTile:** Tiles for the transformation feature (**mountain** to **grass**).  

### **AllowedTiles.cs (Utility Script)**  
- **Purpose:** Manages the list of tiles the player can walk on dynamically.  
- **Key Methods:**
  - **Contains(TileBase tile):** Checks if a tile is in the allowed list.  
  - **UpdateAllowedTiles(TileBase[] tiles):** Replaces the allowed tile list.  
  - **AddAllowedTiles(TileBase[] tiles):** Adds new tiles to the current list.  

---

## **How It Works**  
1. **Item Pickup and Drop:**  
   - When the player collides with an item (Goat, Boat, Pickaxe) and presses `Space`, the item is picked up.  
   - Picking up the item updates the **AllowedTiles** list dynamically.  
   - Dropping the item restores the player's allowed tiles to the default list.  

2. **Tile Transformation (Pickaxe):**  
   - If the pickaxe is picked up, pressing `T` transforms a **mountain tile** into a **grass tile** under the player's position.  
   - Validates that the tile under the player matches `transformFromTile` (**mountain**) before performing the transformation.  

3. **Movement Validation:**  
   - The player's movement is restricted to tiles in the current **AllowedTiles** list.

---

## **Setup Instructions**  
1. Add `Goat`, `Boat`, and `Pickaxe` objects to the scene.
2. Attach `Collider2D` components to each item and enable **IsTrigger**.
3. Tag the items as `Goat`, `Boat`, and `Pickaxe` appropriately.
4. Assign the following in the **Inspector**:
   - **Tilemap** to the `KeyboardMoverByTile` script.
   - **AllowedTiles** for the player and each item.
   - **transformFromTile** (mountain) and **transformToTile** (grass) for the pickaxe transformation.
5. Test the functionality:
   - Pick up items with `Space` and verify movement updates.
   - Use `T` to transform mountain tiles into grass tiles with the pickaxe.
   - Drop items with `Space` to reset allowed tiles.

---

## **Challenges and Solutions**  
- **Dynamic Updates:** Keeping the `AllowedTiles` list consistent when multiple items are picked up and dropped.  
  - **Solution:** Unified the logic in the `KeyboardMoverByTile` script.
- **Tile Transformation Validation:** Ensuring transformations occur only on valid tiles.  
  - **Solution:** Added checks in the `HandleTileTransformation()` method to verify tile types.

---

## **Conclusion**  
The Goat, Boat, and Pickaxe Interaction System integrates movement, item interactions, and tile transformations into a seamless experience. The pickaxe allows modifying the game world by transforming **mountains** into **grass**, creating new gameplay possibilities.