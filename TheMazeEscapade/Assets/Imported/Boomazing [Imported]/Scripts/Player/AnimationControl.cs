using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    public Player2DMovement movement;

    public void PlayFootstep()
    {
        movement.PlayOneShotFootstep();
    }
}
