using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Vector3 rotateSpeed; // the rotate speed of the coin in each axis
    Score score;
    public AudioClip coinCollectSound;

    public GameObject floatingText;
    private Quaternion coinRotation;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindObjectOfType<Score>();
        score.maxCoins++;
        coinRotation = transform.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(coinCollectSound, transform.position);
            score.currentCoins++;
            ShowFloatingText();
            Destroy(gameObject);
            // gameObject.SetActive(false);
        }
    }
    void ShowFloatingText()
    {
        GameObject floatingTextObject = Instantiate(floatingText, transform.position + new Vector3(0,2,0), Quaternion.identity);

        // Calculate the direction from the floating text to the camera
        Vector3 directionToCamera = -(Camera.main.transform.position - floatingTextObject.transform.position);

        // Set the floating text's rotation to face the camera
        floatingTextObject.transform.rotation = Quaternion.LookRotation(directionToCamera, Vector3.up);

        // Ensure that the local scale is positive to avoid mirroring
        floatingTextObject.transform.localScale = new Vector3(
            Mathf.Abs(floatingTextObject.transform.localScale.x),
            Mathf.Abs(floatingTextObject.transform.localScale.y),
            Mathf.Abs(floatingTextObject.transform.localScale.z)
        );
    }
}