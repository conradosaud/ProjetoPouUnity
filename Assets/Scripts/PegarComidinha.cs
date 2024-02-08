using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PegarComidinha : MonoBehaviour
{

    public int pontos = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Destroy(gameObject);

        // Eventos ao colidir com o jogador
        // Aumenta os pontos
        if( collision.gameObject.tag == "Player")
        {
            
            JogoComidinha.pontos += pontos;

            if (JogoComidinha.pontos < 0)
                JogoComidinha.pontos = 0;

            GameObject.Find("Pontos").transform.Find("Valor").GetComponent<TextMeshProUGUI>().text =
            JogoComidinha.pontos.ToString();

        }
        
        // Evento ao colidir com o chão
        // Aumenta o número de erros do jogador
        if (collision.gameObject.name == "ChaoColisao")
        {
            // Se for uma comidinha de valor negativo, ignora essa função
            if (pontos < 0) 
                return;

            JogoComidinha.erros++;
            GameObject.Find("Erros").transform.Find("Valor").GetComponent<TextMeshProUGUI>().text =
            JogoComidinha.erros.ToString();

            if (JogoComidinha.erros > 10)
            {
                SceneManager.LoadScene("Lobby");
            }

        }

    }

}
