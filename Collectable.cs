using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    bool isCollected = false;




    void Show()
    {//0
        this.GetComponent<SpriteRenderer>().enabled = true;
        this.GetComponent<CircleCollider2D>().enabled = true;
        isCollected = false;

    }
    void Hide()
    {//0
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<CircleCollider2D>().enabled = false;



    }
    void Collect()
    {//0
        isCollected = true;
        Hide();
        GameManager.instance.CollectedCoin();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Collect();

            Destroy(this.gameObject);
            Debug.Log("from collectableclass");


        }
    }


}
