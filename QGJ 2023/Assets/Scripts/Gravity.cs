using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    enum GravityDirection { Down, Left, Up, Right };
    GravityDirection m_GravityDirection;
    public float grav = -9.8f;

    void Start()
    {
        m_GravityDirection = GravityDirection.Down;
    }

    void FixedUpdate()
    {
        switch (m_GravityDirection)
        {
            case GravityDirection.Down:
                //Change the gravity to be in a downward direction (default)
                Physics2D.gravity = new Vector2(0, grav);
                break;

            case GravityDirection.Left:
                //Change the gravity to go to the left
                Physics2D.gravity = new Vector2(grav, 0);
                break;

            case GravityDirection.Up:
                //Change the gravity to be in a upward direction
                Physics2D.gravity = new Vector2(0, -grav);
                break;

            case GravityDirection.Right:
                //Change the gravity to go in the right direction
                Physics2D.gravity = new Vector2(-grav, 0);
                break;
        }
    }
}

