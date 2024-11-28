using UnityEngine;
using UnityEngine.InputSystem;

/**
 * This component spawns the given object whenever the player clicks a given key.
 */
public class ClickSpawner: MonoBehaviour
{
    [SerializeField] protected InputAction spawnAction = new InputAction(type: InputActionType.Button);
    [SerializeField] protected GameObject prefabToSpawn;
    [SerializeField] protected Vector3 velocityOfSpawnedObject;

    
    [SerializeField] public bool isOnlyOneLaserShot = true;

    void OnEnable()
    {
        spawnAction.Enable();
    }

    void OnDisable()
    {
        spawnAction.Disable();
    }

    public void Start3LasersTemporary()
    {
        isOnlyOneLaserShot = false;

        Invoke("BackToOneLaserShot", 5f);
    }    

    void BackToOneLaserShot()
    {
        isOnlyOneLaserShot = true;
    }


    protected virtual GameObject spawnObject()
    {
        //Debug.Log("Spawning a new object");

        // Step 1: spawn the new object.
        Vector3 positionOfSpawnedObject = transform.position;  // span at the containing object position.
        Quaternion rotationOfSpawnedObject = Quaternion.identity;  // no rotation.
        GameObject newObject = Instantiate(prefabToSpawn, positionOfSpawnedObject, rotationOfSpawnedObject);

        // Step 2: modify the velocity of the new object.
        Mover newObjectMover = newObject.GetComponent<Mover>();
        if (newObjectMover)
        {
            newObjectMover.SetVelocity(velocityOfSpawnedObject);
        }

        return newObject;
    }


    protected virtual GameObject[] spawn3Objects() {
        //Debug.Log("Spawning a new object");
        GameObject[] newGameObjects = new GameObject[3];

        int index = 0;
        for (int deltaX = -2; deltaX<=2; deltaX=deltaX+2)
        {
            // Step 1: spawn the new object.
            Vector3 pos = new Vector3(transform.position.x + deltaX, transform.position.y, transform.position.z);
            Vector3 positionOfSpawnedObject = pos;  // span at the containing object position.
            Quaternion rotationOfSpawnedObject = Quaternion.identity;  // no rotation.
            newGameObjects[index] = Instantiate(prefabToSpawn, positionOfSpawnedObject, rotationOfSpawnedObject);

            // Step 2: modify the velocity of the new object.
            Mover newObjectMover = newGameObjects[index].GetComponent<Mover>();
            if (newObjectMover) {
                newObjectMover.SetVelocity(velocityOfSpawnedObject);
            }

            index++;
        }

        return newGameObjects;
    }


    private void Update() {
        if (spawnAction.WasPressedThisFrame()) {

            if (isOnlyOneLaserShot)
            {
                spawnObject();
            }
            else
            {

                spawn3Objects();
            }

        }
    }
}
