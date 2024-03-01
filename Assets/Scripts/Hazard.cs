using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            other.GetComponent<Player>().moveSpeed = 0.0f;
            Invoke("Reload", 0.25f);
        }
        else {
            Destroy(other.gameObject);
        }
    }
    void Reload(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
