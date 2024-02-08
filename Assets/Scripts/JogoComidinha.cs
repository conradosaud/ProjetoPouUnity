using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogoComidinha : MonoBehaviour
{

    public Transform local;
    public float tempoMinimo = 1.5f;
    public float tempoMaximo = 3.5f;

    public List<Transform> objetos;

    float tempoDefinido = 0f; // Delay para come�ar a fase
    float tempoPercorrido = 0;

    void Update()
    {
        // Contabiliza o tempo que se passou no jogo
        tempoPercorrido += Time.deltaTime; 

        if( tempoPercorrido >= tempoDefinido)
        {
            // Define qual ser� o tempo para spawnar um novo objeto
            tempoPercorrido = 0;
            tempoDefinido = Random.Range( tempoMinimo, tempoMaximo );

            // Seleciona um objeto da lista
            Transform selecionado = objetos[Random.Range(0, objetos.Count)];
            // Cria ele na scene e guarda sua refer�ncia
            Transform criado = Instantiate(selecionado, local);
            // Diminui o tamanho dele, pois o objeto pai tem uma refer�ncia de tamanho muito maior
            criado.localScale = new Vector3( 1 / local.localScale.x , 1f, 1f);

            // Define as posi��es que o objeto pode nascer na scene, tudo dentro do tamanho do local
            float novaPosicao = Random.Range(0, local.localScale.x);
            // Divide o tamanho por 2, pois a Unity come�a a contar do centro, e n�o da esquerda
            novaPosicao = novaPosicao - local.localScale.x / 2;
            // Seta a posi��o na scene
            criado.position = new Vector2(novaPosicao, local.position.y );

        }
    }
}
