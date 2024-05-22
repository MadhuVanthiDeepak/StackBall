using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private Vector3 camfollow;
    private Transform ball, Win;
    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Ball>().transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (Win == null)
            Win = GameObject.Find("Win(Clone)").GetComponent<Transform>();

        if (transform.position.y > ball.transform.position.y && transform.position.y > Win.position.y + 4f)
            camfollow = new Vector3(transform.position.x, ball.position.y, transform.position.z);
        transform.position = new Vector3(transform.position.x, camfollow.y, -5);
    }
}
