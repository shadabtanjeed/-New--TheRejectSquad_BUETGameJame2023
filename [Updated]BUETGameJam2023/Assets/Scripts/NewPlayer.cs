using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : PhysicsObject
{
    [SerializeField] private float maxSpeed = 1;
    [SerializeField] private float jumpPower = 10;
    private float speedIncreaseInterval = 8f;  // Interval for speed increase
    private float speedIncreaseAmount = 0.5f;  // Amount to increase speed by

    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine for increasing maxSpeed
        StartCoroutine(IncreaseMaxSpeedRoutine());
    }

    // Coroutine for increasing maxSpeed
    IEnumerator IncreaseMaxSpeedRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(speedIncreaseInterval);
            maxSpeed += speedIncreaseAmount;
        }
    }

    // Update is called once per frame
    void Update()
    {
        targetVelocity = new Vector2(Input.GetAxis("Horizontal") * maxSpeed, 0);

        // If the player presses "Jump" and we're grounded, set the velocity to a jump power value
        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpPower;
        }
    }
}
