using TMPro;
using UnityEngine;

/**
 * This component updates the TextMesh to display the current player score from GAME_STATUS.
 * Attach this script to the TextMesh GameObject intended to show the final score in the Game Over scene.
 */
[RequireComponent(typeof(TextMeshPro))]
public class TextScoreUpdate : MonoBehaviour
{
    private TextMeshPro textMesh;
    void Start()
    {
        // Get the TextMesh component attached to this GameObject
        textMesh = GetComponent<TextMeshPro>();
        if (textMesh == null)
        {
            Debug.LogError("TextMesh component not found on " + gameObject.name);
        }
    }

    void Update()
    {
        if (textMesh != null)
        {
            // Update the TextMesh with the current player score from GAME_STATUS
            textMesh.text = "Score: " + GAME_STATUS.playerScore.ToString();
        }
    }
}