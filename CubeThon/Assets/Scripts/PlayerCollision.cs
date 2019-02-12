using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public PlayerMovement movement;   // A reference to our PlayerMovement script
    public bool isOnGround = true;

    // This function runs when we hit another object
    // to get information about the collosion
    void OnCollisionEnter(Collision collisionInfo)
    {
        // The function will be triggered whenever we collided with an Obstacle tag
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;  // Disable the players movement.
            FindObjectOfType<GameManager>().EndGame();
        }

        // The function will be triggered whenever the player is touching the ground and not mid air
        // used for the jumping mechanic
        if (collisionInfo.collider.tag == "Ground")
        {
            Debug.Log("I'm on the ground");
            isOnGround = true;
            //FindObjectOfType<PlayerMovement>().setJumpCounter(FindObjectOfType<PlayerMovement>().getMaxAmountOfJumps());
            FindObjectOfType<PlayerMovement>().SetJumpCounter(0);
        }
    }

    //setters and getters
    public bool GetIsOnGround()
    {
        return isOnGround;
    }

    public void SetIsOnGround(bool flyCondition)
    {
        isOnGround = flyCondition;
    }
}
