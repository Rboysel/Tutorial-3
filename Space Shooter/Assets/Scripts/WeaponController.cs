using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;
    public AudioClip musicClipOne;
    public AudioSource musicSource;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", delay, fireRate); 
    }

    // Update is called once per frame
    void Fire ()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        musicSource.clip = musicClipOne;
        musicSource.Play();
    }
}
