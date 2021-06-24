using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    CameraShake CameraShake;
    [SerializeField]
    private GameObject Boom;
    void Start()
    {
        CameraShake = FindObjectOfType<CameraShake>();
    }
    void Update()
    {
        transform.right = GetComponent<Rigidbody2D>().velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.tag == "BackGround")
        {
            Vector2 pos = gameObject.transform.position;
            Instantiate(Boom, pos, collision.gameObject.transform.rotation);
            CameraShake.shake = 0.5f;
        }
        else
        {
            Instantiate(Boom, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            CameraShake.shake = 0.5f;
        }

    }

}
