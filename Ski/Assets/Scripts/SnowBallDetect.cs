using UnityEngine;

public class SnowBallDetect : MonoBehaviour
{
    public string snowballTag;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(snowballTag))
        {
            Destroy(collision.gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
