﻿using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 1f;
    public float range = 5f;
    public AudioClip disparo;

    AudioSource audioS;

    public Camera fpsCam;

    private void Start()
    {
        audioS = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }

    void Shoot()
    {

        audioS.PlayOneShot(disparo);
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            Debug.Log(hit.transform.name);


        Target tg = hit.transform.GetComponent<Target>();
        if(tg != null)
        {
            tg.takeDamage(damage);
        }

    }

    

}
