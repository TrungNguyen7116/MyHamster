using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamster : MonoBehaviour
{
    public HamsterData data;

    private Rigidbody2D myBody;

    private float scale;
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        StartCoroutine(Action());
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<SpriteRenderer>().sortingOrder = 5000 - (int)(transform.position.y * 1000);
        Scale();
    }

    public void SetData(HamsterData data)
    {
        this.data = data;
        this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Player/" + data.sprite);
    }

    IEnumerator Action()
    {
        Moverment();
        yield return new WaitForSeconds(Random.Range(2.5f, 6f));
        StartCoroutine(Action());
    }

    void Moverment()
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        Vector2 direction = new Vector2(x, y);
        myBody.velocity = direction.normalized * 0.6f;
    }
    void Scale()
    {
        if (data.level >= 10)
        {
            scale = 1.5f;
        }
        else
        {
            scale = 1f;
        }
        if (myBody.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 0) *  scale;
        }
        else if (myBody.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 0) * scale;
        }
    }
}
