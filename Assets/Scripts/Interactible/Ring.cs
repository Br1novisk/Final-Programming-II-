using System;
using UnityEngine;

public class Ring : Collectable
{
    [SerializeField] private AudioClip ringAudio;

    public float RotationSpeed = 30f;
    private bool _isCollected = false;



    private void Update()
    {
        if (!_isCollected)
        {
            transform.Rotate(new Vector3(0, 0, RotationSpeed * Time.deltaTime));
        }
    }
    
    protected override void Collect()
        {
            _isCollected = true; // Define _isCollected como true quando o anel é coletado
            SoundFXManager.Instance.PlaySoundFXClip(ringAudio, transform, 0.5f);
            Debug.Log("plim");
            base.Collect(); // Chama o método base.Collect() para executar a funcionalidade de coleta
        }
}
