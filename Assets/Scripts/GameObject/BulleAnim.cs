using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulleAnim : MonoBehaviour
{
    public GameObject deathParticle;

    // Start is called before the first frame update
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BorderBullet" || collision.gameObject.tag == "Enemy")
        {

            Instantiate(deathParticle, transform.position, transform.rotation);




        }
    }
    }
