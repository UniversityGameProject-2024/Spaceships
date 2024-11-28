using UnityEngine;

public class CannonGiftCollission : MonoBehaviour
{
    //[Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    //[SerializeField] string triggeringTag;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
{ 

}
 // Update is called once per frame
void Update()
{

}
private void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == "Player" && enabled) {
        Debug.Log("Canon_gift: Player collided with me");
        LaserShooter scriptLaserShooter = other.gameObject.GetComponent<LaserShooter>();
        scriptLaserShooter.Start3LasersTemporary();
        Destroy(this.gameObject);  // Destroy the Cannon Gift
    }
}
    // [Tooltip("The number of seconds that the shield remains active")] [SerializeField] float duration;
    // private void OnTriggerEnter2D(Collider2D other) {
    //     if (other.tag == "Player") {
    //         Debug.Log("Shield triggered by player");
    //         var destroyComponent = other.GetComponent<DestroyOnTrigger2D>();
    //         if (destroyComponent) {
    //             ShieldTemporarily(destroyComponent);
    //             Destroy(this.gameObject);  // Destroy the shield itself - to prevent double-use
    //         }
    //     } else {
    //         Debug.Log("Shield triggered by " + other.name);
    //     }
    // }

    // private async void ShieldTemporarily(DestroyOnTrigger2D destroyComponent) {
    //     destroyComponent.enabled = false;
    //     for (float t = duration; t > 0; t--) {
    //         Debug.Log("Shield: " + t + " seconds remaining!");
    //         await Awaitable.WaitForSecondsAsync(1);
    //     }
    //     Debug.Log("Shield gone!");
    //     destroyComponent.enabled = true;
    // }


}
