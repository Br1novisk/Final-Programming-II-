using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equippable : Collectable
{
    [SerializeField] GameObject EquippablePrefab;
    [SerializeField] Transform SpawnPoint; // Ref the instantiation point

    [SerializeField] float RotationSpeed = 35f;

    [SerializeField] bool _isCollected = false;
    protected bool _canShoot = false;

    void Update()
    {
        if (_isCollected)
        {
            _canShoot = true; 
            //I tried changing the _canShoot here and down below, but neither worked. Sorry at the moment this is too much to test, test, try and fix it
            return;
        }
        transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);
    }

    protected override void Collect()
    {
        transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
        transform.position = SpawnPoint.position;
        transform.rotation = SpawnPoint.rotation;

        _isCollected = true;
        //enabled = false; 
        //_canShoot = true;
    }
}