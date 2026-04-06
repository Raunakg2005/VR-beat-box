using UnityEngine;

public class BeatBlock : MonoBehaviour
{
    // How fast the block flies at you
    public float speed = 4f; 
    
    // We will type "LeftHand" or "RightHand" in the Unity Editor
    public string correctHandTag; 

    // Update runs every single frame
    void Update()
    {
        // This moves the block along the Z-axis towards the player
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    // This runs the exact millisecond something touches the block
    void OnTriggerEnter(Collider other)
    {
        // If the thing touching it has the correct tag (LeftHand for Red, RightHand for Blue)
        if (other.CompareTag(correctHandTag))
        {
            Debug.Log("PERFECT PUNCH!");
            FindObjectOfType<GameManager>().AddScore(10);
            Destroy(gameObject); // Destroys the block
        }
        // If it was hit by the WRONG hand
        else if (other.CompareTag("LeftHand") || other.CompareTag("RightHand"))
        {
            Debug.Log("WRONG HAND!");
            Destroy(gameObject); 
        }
    }
}