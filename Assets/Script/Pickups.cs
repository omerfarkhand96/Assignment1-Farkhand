using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public GameObject gun;
    public GameObject grenade;
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Grenade")
        {
            grenade.SetActive(true);
            Destroy(other);
        }
        if (other.tag == "Gun")
        {
            gun.SetActive(true);
            Destroy(other);
            anim.SetBool("WeaponEquip", true);
        }
    }
}
