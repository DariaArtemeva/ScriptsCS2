using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPooling: MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    private List<GameObject> bullets;
    private int maxBullets = 10;
    [SerializeField]
    private AudioSource volume;
    public AudioClip shoot;
    public Text helptext;
    void Start()
    {
        bullets = new List<GameObject>();
        for (int i = 0; i < maxBullets; i++)
        {
            GameObject bullett = Instantiate(bullet, transform.position, transform.rotation);
            bullett.SetActive(false);
            bullets.Add(bullett);
        }
    }


    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            helptext.gameObject.SetActive(false);
            volume.PlayOneShot(shoot);
            foreach (GameObject bullett in bullets)
            {
                if (!bullett.activeInHierarchy)
                {
                    bullett.SetActive(true);
                    bullett.transform.position = transform.position;
                    break;
                }
            }
        }
    }
}
