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

    // Configuração de aparição das comidinhas
    public Transform local;
    public float tempoMinimo = 1.5f;
    public float tempoMaximo = 3.5f;

    public List<Transform> objetos;

    float tempoDefinido = 0f; // Delay para começar a fase
    float tempoPercorrido = 0;

    void Update()
    {
        // Contabiliza o tempo que se passou no jogo
        tempoPercorrido += Time.deltaTime; 

        if( tempoPercorrido >= tempoDefinido)
        {

            // Define qual será o tempo para spawnar um novo objeto
            tempoPercorrido = 0;
            tempoDefinido = Random.Range( tempoMinimo, tempoMaximo );

            // Seleciona um objeto da lista
            Transform selecionado = objetos[Random.Range(0, objetos.Count)];
            // Cria ele na scene e guarda sua referência
            Transform criado = Instantiate(selecionado, local);
            // Diminui o tamanho dele, pois o objeto pai tem uma referência de tamanho muito maior
            criado.localScale = new Vector3( 1 / local.localScale.x , 1f, 1f);

            // Define as posições que o objeto pode nascer na scene, tudo dentro do tamanho do local
            float novaPosicao = Random.Range(0, local.localScale.x);
            // Divide o tamanho por 2, pois a Unity começa a contar do centro, e não da esquerda
            novaPosicao = novaPosicao - local.localScale.x / 2;
            // Seta a posição na scene
            criado.position = new Vector2(novaPosicao, local.position.y );

        }
    }

    private void FixedUpdate()
    {
        // Guarda o tempo da partida e mostra na tela de forma arredondada
        tempoPartida += Time.deltaTime;
        textoTempoPartida.text = Mathf.RoundToInt(tempoPartida).ToString();

        // Verifica se atingiu o novo nível do jogo e aumenta o desafio de tempo das comidinhas
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
