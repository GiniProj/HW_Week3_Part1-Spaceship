using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoNextLevel : MonoBehaviour
{
    [Tooltip("Tag of the object that will trigger the scene change")]
    [SerializeField] private string triggeringTag;
    [Tooltip("Name of scene to move to when triggering the given tag")]
    [SerializeField] private string sceneName;

    [Tooltip("True - Position will be relative to the last scene position, False - Position will be independent of the last scene position")]
    [SerializeField] private bool relativeSpawnPosition = true;

    [Tooltip("With Relative Spawn Position = True, the spawn position will be relative to the last scene position (Last Scene Position + Spawn Point) Else, the spawn point will be as Spawn Position defined")]
    [SerializeField] private Vector3 spawnPoint;

    void Start()
    {
        if (gameObject.tag == "Player")
        {
            if (relativeSpawnPosition)
            {
                spawnPoint += transform.position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag)
        {
            TriggerSceneChange();

            if (other.tag == "Enemy" && gameObject.tag == "Player")
            {
                Debug.Log("Player collided with enemy");
                gameObject.SetActive(false);
                Debug.Log("Game over!");
            }
        }
    }

    // Method to trigger the scene change
    public void TriggerSceneChange()
    {
        Debug.Log("Triggering scene change");
        SceneManager.LoadScene(sceneName);
        Debug.Log("Scene changed to " + sceneName);
    }

}