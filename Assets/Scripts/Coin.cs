using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Vector3 rotateSpeed; // the rotate speed of the coin in each axis
    Score score;
    public AudioClip coinCollectSound;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindObjectOfType<Score>();
        score.maxCoins++;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(coinCollectSound, transform.position);
            score.currentCoins++;
            Destroy(gameObject);
        }
    }
}