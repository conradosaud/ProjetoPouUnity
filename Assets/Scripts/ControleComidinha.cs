using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleComidinha : MonoBehaviour
{

    public float velocidade = 10f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");

        Vector2 posicaoAtual = transform.position;
        Vector2 novaPosicao = new Vector2( posicaoAtual.x + horizontal * velocidade * Time.deltaTime, posicaoAtual.y);
        rb.MovePosition( novaPosicao );

    }

}
