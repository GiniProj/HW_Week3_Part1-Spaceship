using UnityEngine;

/**
 * This component spawns the given object at fixed time-intervals at its object position.
 */
public class TimedSpawner : MonoBehaviour
{
    [SerializeField] Mover prefabToSpawn;
    [SerializeField] Vector3 velocityOfSpawnedObject;
    [SerializeField] float secondsBetweenSpawns = 1f;

    void Start()
    {
        SpawnRoutine();
        Debug.Log("Start finished");
    }

    async void SpawnRoutine()
    {
        while (true)
        {
            GameObject newObject = Instantiate(prefabToSpawn.gameObject, transform.position, Quaternion.identity);
            newObject.GetComponent<Mover>().SetVelocity(velocityOfSpawnedObject);
            await Awaitable.WaitForSecondsAsync(secondsBetweenSpawns);
        }
    }
}