using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToeDestroyer : MonoBehaviour
{
    [SerializeField] private Toes _toes = null;
    void OnTriggerStay(Collider2D collider)
    {
        if(_toes.eating == true && collider.tag == "ToeDestroyer")
        {
            Destroy(gameObject);
        }

    }
}
