using UnityEngine;
using System.Collections;
/**
 * This component moves its object in a fixed velocity.
 * NOTE: velocity is defined as speed+direction.
 *       speed is a number; velocity is a vector.
 */
public class Mover : MonoBehaviour
{
    [Tooltip("Movement vector in meters per second")]
    [SerializeField] Vector3 velocity;

    [Tooltip("Y position where object will be destroyed")]
    [SerializeField] private float enemyDeadZone = -7f;  // Added a Dead Zone for Enemies
    [SerializeField] private float laserDeadZone = 7f;  // Added a Dead Zone for Lasers

    [Tooltip("Time in seconds to wait before destroying the object")]
    [SerializeField] private float destroyDelay = 2f;

    private bool shouldMove = true;  // Added a Flag to Prevent Multiple Coroutines:
    private bool isDestroying = false;  // Added a Flag to Prevent Multiple Coroutines:

    void Update()
    {
        if (shouldMove)
        {
            transform.position += velocity * Time.deltaTime;
            if (!isDestroying)
            {
                if (gameObject.tag == "Enemy" && transform.position.y < enemyDeadZone)
                {
                    shouldMove = false;
                    StartCoroutine(DestroyAfterDelay());
                }
                else if (gameObject.tag == "Laser" && transform.position.y > laserDeadZone)
                {
                    shouldMove = false;
                    StartCoroutine(DestroyAfterDelay());
                }
            }
        }
    }

    IEnumerator DestroyAfterDelay()
    {
        isDestroying = true;
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }

    public void SetVelocity(Vector3 newVelocity)
    {
        this.velocity = newVelocity;
    }
}
