using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToStart : MonoBehaviour
{
    [SerializeField] Transform startingPos; // equals where the player starts in the game
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // if the player touches this
        {
            collision.gameObject.transform.position = startingPos.position; // move them to startingPos location
            collision.gameObject.transform.rotation = startingPos.rotation; // match startingPos rotation
        }
    }
}
