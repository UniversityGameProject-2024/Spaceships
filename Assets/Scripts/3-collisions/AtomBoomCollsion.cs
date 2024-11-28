using UnityEngine;

public class AtomBoomCollsion : MonoBehaviour
{
    //[Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    //[SerializeField] string triggeringTag;

    [SerializeField] GameObject scoreField;
    [SerializeField] int pointsForEachEnemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        scoreField = GameObject.Find("ScoreField");        
    }

      


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && enabled) {
            Debug.Log("Atom_boom: Player collided with me");

            int scorePointsToAdd = 0;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject enemy in enemies)
            {
                Destroy(enemy);
                scorePointsToAdd += pointsForEachEnemy;
            }

            if (scoreField!=null) {
                NumberField numberField = scoreField.GetComponentInChildren<NumberField>();
                numberField.AddNumber(scorePointsToAdd);
            }
            else
            {
                Debug.LogError("ScoreField is not attached to this script!");
            }
    
            Destroy(this.gameObject);  // Destroy the AtomBoom gameobject
        }
    }

}
