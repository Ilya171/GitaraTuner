using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteFinich : MonoBehaviour
{
 private void OnTriggerEnter2D(Collider2D other) {
     Debug.Log($"<color=blue>MEASURE {other.gameObject.name }</color>");
     other.enabled = false;
 }
}
