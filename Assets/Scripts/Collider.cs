using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{
    public GameObject damageEffect, explosionEffect;
    public float backwardDist;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "weapon")
        {
            AudioManager.PlayDamageAudio();
            collision.gameObject.AddComponent<Rigidbody>();
            collision.gameObject.GetComponent<Rigidbody>().mass = 0;            
            collision.gameObject.GetComponent<AutoMovement>().speed = 0;
            collision.gameObject.GetComponent<MeshCollider>().isTrigger = true;
            gameObject.transform.position -= new Vector3(backwardDist, 0, 0);
            GameObject effect = Instantiate(damageEffect, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject, 0.2f);
            Destroy(effect, 0.5f);
            GameManager.AddScore(10);
        }
        if (collision.gameObject.tag == "DeadZone")
        {
            GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(explosion, 1.0f);
            Destroy(gameObject);
            collision.gameObject.GetComponent<MeshCollider>().enabled = false;
            AudioManager.PlayExplosionAudio();
            GameManager.SetState(GameManager.State.Clear);
            AudioManager.PlayClearAudio();
            GameManager.GotoMenu();
        }
        if (collision.gameObject.tag == "Player")
        {
            GameObject effect = Instantiate(damageEffect, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            collision.gameObject.GetComponent<Animator>().SetBool("isDead", true);
            GameManager.SetState(GameManager.State.Dead);
            AudioManager.PlayGameOverAudio();
            GameManager.GotoMenu();
        }
    }
}
