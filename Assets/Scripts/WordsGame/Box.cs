using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    public Text content;

    public int index;


    private Rigidbody2D myBody;

    private Vector2 pointStart;
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        pointStart = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        myBody.velocity = new Vector2(-4, 0);
        content.transform.position = Camera.main.WorldToScreenPoint(transform.position);
    }

    public void SetString(string str, int i)
    {
        content.text = str;
        index = i;
    }

    public void Restart()
    {
        transform.position = pointStart;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            WordsGamePlay.instance.Check(index);
        }
    }
}
