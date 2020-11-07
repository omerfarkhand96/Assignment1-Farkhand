using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Effects;

public class Shooting : MonoBehaviour
{

    public GameObject bullet;
    public Transform gun;
    ExplosionPhysicsForce explosionPhysics;
    public Vector3 BulletForce = new Vector3(0, 100, 50000);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
           StartCoroutine(FireBullet());
        }
    }

    IEnumerator FireBullet()
    {
        // Wait for five seconds
        yield return new WaitForSeconds(0.1f);

        GameObject clone = Instantiate(bullet, gun.position, gun.rotation) as GameObject;

        // name the bullet as 'bullet'
        clone.name = "bullet";

        // make bullet a child of the character's hand
        clone.transform.parent = gun;

        // Vector3 variable for getting the character's transform rotation
        Vector3 dir = gun.rotation.eulerAngles;

        // set bullet's transform rotation equal to 'dir' (character's rotation plus Y-Axis compensation)
        clone.transform.rotation = Quaternion.Euler(dir);

        // Dettach bullet from the gun, making it an independent object
        clone.transform.parent = null;

        // Add force to prop, throwing it
        clone.GetComponent<Rigidbody>().AddRelativeForce(BulletForce);


    }

    private void OnCollisionEnter(Collision collision)
    {
        //explosion.SetActive(true);
        explosionPhysics.Explode();
        Destroy(bullet);
    }
}
