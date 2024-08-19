using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : Equippable
{
    [SerializeField] Transform bullet;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] float bulletSpeed;

    [SerializeField] private AudioClip shootAudio;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Transform bulletTrans = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        Rigidbody bulletRB = bulletTrans.GetComponent<Rigidbody>();
        bulletRB.AddRelativeForce(Vector3.forward * bulletSpeed);

        SoundFXManager.Instance.PlaySoundFXClip(shootAudio, transform, 0.2f);
        Debug.Log("pew");
    }    
}
