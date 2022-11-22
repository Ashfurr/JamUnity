using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchLocation
{
    public int touchId;
    public Rigidbody projectil;

    public touchLocation(int newTouchId, Rigidbody newProjectil)
    {
        touchId = newTouchId;
        projectil = newProjectil;
    }
}
