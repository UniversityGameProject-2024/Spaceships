using UnityEngine;

public class DestroyWhenOutOfView : MonoBehaviour
{
    [SerializeField] public Camera mainCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = mainCamera.WorldToViewportPoint(transform.position);
        //Check that this gameobject is below the screen bottom
        if (screenPos.y < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
