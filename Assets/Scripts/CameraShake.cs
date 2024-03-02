using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraShake : MonoBehaviour
{
    private CinemachineImpulseSource impulseSource;
    Vector3 impulseDirection = new Vector3 (-1,0,0);

    // Start is called before the first frame update
    void Start()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();

    }

    public void ShakeCamera(){

        impulseSource.GenerateImpulse(impulseDirection);
    }
    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Player")){
            ShakeCamera();
            // Debug.Log("Bumped");
        }
    }
}
