using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // This is a Reference to the Rigidbody component called "rb" used by the Player
    public Rigidbody rb;

    // Reference to PlayerCollision
    public PlayerCollision playerColl;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public float jumpingForce = 200f;

    public int maxAmountOfJumps = 2; // Number of max possible jumps mid air
    public int jumpCounter; // Increases every time the Player Jumps mid air


    // We marked this as "Fixed"Update because we
    // are using it to mess with physics
    void FixedUpdate ()
    {
        // Add a forward force
        // Multiplying the force by Time.deltaTime ensures
        // that we have the same force on every computer
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        // PLAYER MOVEMENT

        // Pressing "d" forces the Player to move right
        if ( Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        // Pressing "a" forces the Player to move left using negative x direction
        if (Input.GetKey("a"))
        {
            rb.AddForce (-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        // Jumping Mechanic on "space"

        // Single Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            
            // sets isFlying true as soon the max num of allowed mid air jumps is reached
      
        }

        // We keep track of the players y position to End the Game whenever he falls of the board
        if (rb.position.y <= -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    // Jump function
    void Jump()
    {
        if (FindObjectOfType<PlayerCollision>().GetIsOnGround() || maxAmountOfJumps > GetJumpCounter())
        {
            Debug.Log("I'm flying now");
            rb.AddForce(Vector3.up * Time.deltaTime * jumpingForce, ForceMode.Impulse);
           // gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,Time.deltaTime * jumpingForce, 0), ForceMode.Impulse);
            FindObjectOfType<PlayerCollision>().SetIsOnGround(false);
            IncreaseJumpCounter();
        }
        else
        {
            Debug.Log("I cannot jump anymore");
            return;
        }
    }
    // JumpCounter Functions
    public int GetJumpCounter()
    {
        return jumpCounter;
    }

    public void SetJumpCounter(int jumpCounter)
    {
        this.jumpCounter = jumpCounter;
    }

    public void IncreaseJumpCounter()
    {
        jumpCounter++;
    }

    //MaxAmountOfjumps function
    public int GetMaxAmountOfJumps()
    {
        return maxAmountOfJumps;
    }
}
