using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JogoComidinha : MonoBehaviour
{

    // Level controller
    public static int pontos = 0;
    public static int erros = 0;
    public TextMeshProUGUI textoTempoPartida;
    public TextMeshProUGUI textoNivel;
    float tempoPartida = 0;
    int nivel = 1;

    // Configura��o de apari��o das comidinhas
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

    private void FixedUpdate()
    {
        // Guarda o tempo da partida e mostra na tela de forma arredondada
        tempoPartida += Time.deltaTime;
        textoTempoPartida.text = Mathf.RoundToInt(tempoPartida).ToString();

        // Verifica se atingiu o novo n�vel do jogo e aumenta o desafio de tempo das comidinhas
        float tempoCadaNivel = 15f;
        if( tempoPartida % tempoCadaNivel < 0.01f)
        {
            nivel++;
            tempoMinimo -= tempoMinimo * (nivel * 10) / 100;
            tempoMaximo -= tempoMaximo * (nivel * 10) / 100;
            textoNivel.text = nivel.ToString();
        }
 

    }
}
