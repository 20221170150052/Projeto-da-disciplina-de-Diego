using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float speed;
    public float moveTime;
    public float perdeuTime;

    private bool dirRight = true;
    private float time;

    // Update is called once per frame
    void Update()
    {
        if(dirRight)
        {   // Se verdadeiro a serra vai para direita
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {   // Se falso a serra vai para esquerda
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        time += Time.deltaTime;
        if (time >= moveTime)
        {
            dirRight = !dirRight;
            time = 0f;
        }
    }

}
