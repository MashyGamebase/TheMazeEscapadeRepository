using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMngr : MonoBehaviour
{
    public Collider2D blocker;
    public SpriteRenderer sprRenderer;
    public Sprite spr_close, spr_open;

    public void SetChestOpen(bool state)
    {
        if (state)
        {
            sprRenderer.sprite = spr_open;
            blocker.enabled = false;
        }
        else
        {
            sprRenderer.sprite = spr_close;
            blocker.enabled = true;
        }
    }
}
