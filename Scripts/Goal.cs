using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    Score score;
    public Vector3 rotateSpeed; // the rotate speed of the coin in each axis

    public AudioClip coinCollectSound;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindObjectOfType<Score>();    
    }
    void Update()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            if(score != null){
                if(score.currentCoins >= score.maxCoins){
                    AudioSource.PlayClipAtPoint(coinCollectSound, transform.position);
                    Invoke("Reload", 0.25f);
                }

            }
        }
    }
    void Reload(){
        SceneManager.LoadScene(0);
    }
}
