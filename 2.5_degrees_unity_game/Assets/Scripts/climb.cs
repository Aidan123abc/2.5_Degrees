using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClimbing : MonoBehaviour
{
    public float climbSpeed = 5f;
    public float distanceToWall = 0.5f;
    public KeyCode climbKey = KeyCode.C;
    public LayerMask climbsLayer;

    private bool isClimbing = false;
    private Transform currentWall;

    private void Update()
    {
        if (Input.GetKeyDown(climbKey) && !isClimbing)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, distanceToWall, climbsLayer))
            {
                StartClimbing(hit.transform);
            }
        }

        if (isClimbing && Input.GetKey(climbKey))
        {
            Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f).normalized;
            transform.Translate(moveDirection * climbSpeed * Time.deltaTime);
        }
        else if (isClimbing)
        {
            StopClimbing();
        }
    }

    private void StartClimbing(Transform wall)
    {
        isClimbing = true;
        currentWall = wall;
    }

    private void StopClimbing()
    {
        isClimbing = false;
        currentWall = null;
    }
}
