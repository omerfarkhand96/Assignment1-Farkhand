using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour { 

    public AudioSource fire;
    public AudioSource walk;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if (anim.GetFloat("Forward") >= 0.5)
        {
            //walk.Play();
        } else
        {

        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetBool("Grenade", true);
        }
        else
        {
            anim.SetBool("Grenade", false);
        }
        if(GameObject.Find("Ak-47").active == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetBool("Fire", true);
                fire.Play();
            }
            if (Input.GetButtonUp("Fire1"))
            {
                anim.SetBool("Fire", false);
            }

            if (Input.GetKeyUp(KeyCode.R))
            {
                anim.SetBool("Reload", true);
            }
            if (Input.GetKeyUp(KeyCode.R))
            {
                anim.SetBool("Reload", false);
            }
        }
        
        
    }
}
