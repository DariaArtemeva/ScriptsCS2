using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setactivetext : MonoBehaviour
{
    public Text helptxt;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            helptxt.gameObject.SetActive(true);
        }
    }
}
