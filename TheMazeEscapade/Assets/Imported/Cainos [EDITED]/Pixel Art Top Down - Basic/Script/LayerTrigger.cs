﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    //when object exit the trigger, put it to the assigned layer and sorting layers
    //used in the stair objects for player to travel between layers
    public class LayerTrigger : MonoBehaviour
    {
        public string layer;
        public string sortingLayer;

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.layer = LayerMask.NameToLayer(layer);

                List<SpriteRenderer> srs = other.gameObject.GetComponent<Player2DMovement>().spr;
                foreach (SpriteRenderer sr in srs)
                {
                    sr.sortingLayerName = sortingLayer;
                }
            }
            else if(other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.layer = LayerMask.NameToLayer(layer);

                SpriteRenderer srs = other.gameObject.GetComponent<EnemyAI>().spriteRenderer;
                srs.sortingLayerName = sortingLayer;
            }
        }

    }
}
