using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PuzzleObject))]
public class PuzzleObjectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        PuzzleObject puzzleObject = (PuzzleObject)target;

        // Tampilkan default Inspector
        DrawDefaultInspector();

        // Tambahkan custom GUI di bawah default Inspector
        EditorGUILayout.Space(); // Membuat spasi antara default Inspector dan custom GUI

        EditorGUILayout.LabelField("Custom Settings", EditorStyles.boldLabel);

        puzzleObject.isPuzzleNeedItem = EditorGUILayout.Toggle("Requires Item", puzzleObject.isPuzzleNeedItem);

        if (puzzleObject.isPuzzleNeedItem)
        {
            puzzleObject.itemName = EditorGUILayout.TextField("Item Name", puzzleObject.itemName);
            puzzleObject.destroyItem = EditorGUILayout.Toggle("Destroy Item", puzzleObject.destroyItem);

            if (puzzleObject.destroyItem)
            {
                puzzleObject.destroyItemInventory = (DestroyItemInventory)EditorGUILayout.ObjectField(
                    "Destroy Item Inventory", puzzleObject.destroyItemInventory, typeof(DestroyItemInventory), true);
            }
        }

        puzzleObject.realPuzzle = (GameObject)EditorGUILayout.ObjectField("Real Puzzle", puzzleObject.realPuzzle, typeof(GameObject), true);
        puzzleObject.puzzleStats = (PuzzleStats)EditorGUILayout.ObjectField("Puzzle Stats", puzzleObject.puzzleStats, typeof(PuzzleStats), true);
    }
}
