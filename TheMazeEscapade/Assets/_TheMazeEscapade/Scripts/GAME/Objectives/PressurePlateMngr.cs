using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlateMngr : MonoBehaviour
{
      public TriggerGroup triggerGroup;
      public int triggerIndex;
      public bool keepPlateDown = true;
      public float pressDuration = 1.0f;
      public bool isPressed;
      public SpriteRenderer spriteRenderer;
      public Sprite spr_def, spr_pressed;

      public UnityEvent OnPressedDownEvents = new UnityEvent();
      public UnityEvent OnPressedEvents = new UnityEvent();
      public UnityEvent OnPressedUpEvents = new UnityEvent();

      private float _timePressed;
      private bool _pressed;

      private void Update() {
            if (_pressed) {
                  OnPressedEvents.Invoke();
                  //Debug.Log("Pressure plate being pressed!");
                  // press forever until reset
                  if (!keepPlateDown) {
                        // reset pressure plate if not permanent
                        _timePressed += Time.deltaTime;
                        if (_timePressed >= pressDuration) {
                              OnPressedUpEvents.Invoke();
                              TogglePlate(false);
                              _timePressed = 0;
                              _pressed = false;
                        }
                  }
            }
      }

      private void OnValidate() {
            if (spriteRenderer == null)
                  GetComponent<SpriteRenderer>();
            if (spriteRenderer != null) 
                  spr_def = spriteRenderer.sprite;
            
      }

      public void PressPlate() {
            _pressed = true;
            isPressed = true;
            OnPressedDownEvents.Invoke();
            if (triggerGroup != null) {
                  triggerGroup.triggerStates[triggerIndex] = true;
                  triggerGroup.CheckStates();
            }
            TogglePlate(true);
      }

      public void TogglePlate(bool state) {
            if (spriteRenderer == null)
                  return;

            if (state) {
                  spriteRenderer.sprite = spr_pressed;
                  //Debug.Log("Pressure plate down!");
            } else {
                  spriteRenderer.sprite = spr_def;
                  //Debug.Log("Pressure plate up!");
            }
      }

      public void ResetPlate() {
            TogglePlate(false);
            _pressed = false;
            _timePressed = 0;
            Debug.Log("Plate reset!");
      }

      private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.CompareTag("Player")) {
                  PressPlate();
            }
      }
}
