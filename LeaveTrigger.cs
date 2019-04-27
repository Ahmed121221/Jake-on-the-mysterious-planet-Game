using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LevelGenerator.instance.AddPiece();
            //LevelGenerator.instance.RemoveOldPiece();
        }
    }
}
