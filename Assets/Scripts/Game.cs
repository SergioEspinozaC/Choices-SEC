using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public TextMeshProUGUI enunciado;
    public TextMeshProUGUI[] opciones;
    public Opcion bancoOpciones;
    public Opcion opcionActual;
    public GameObject[] btnRespuesta;
    public GameObject btnGane;
    public GameObject btnPerdida;
    public Image bgImage;

    // Start is called before the first frame update
    void Start()
    {
        cargarOpciones();
        opcionActual = bancoOpciones;
        setEnunciado();
    }

    // Update is called once per frame
    void Update()
    {
        if(opcionActual.enunciado.Equals("Te han dado la habitacion 237 y te advierten que por nada del mundo debes salir de tu habitacion entre la medianoche y las 3a.m. Tambien que alguien podria entrar en la habitacion, pero no debes verlo."))
        {
            bgImage.sprite = Resources.Load<Sprite>("Sprites/hotel");
        }
        
        if (opcionActual.enunciado.Equals("Ha sido una mala decision ya que podrias perderte! Te has encontrado con unos lobos."))
        {
            bgImage.sprite = Resources.Load<Sprite>("Sprites/forest");
        }
        
        if(opcionActual.enunciado.Equals("Te encuentras con una cabanna con las luces encendidas, te acercas a pedir ayuda y sale una anciana que te ofrece hospedarte."))
        {
            bgImage.sprite = Resources.Load<Sprite>("Sprites/hut");
        }
    }

    public void setEnunciado()
    {
        enunciado.text = opcionActual.enunciado;


        for (int i = 0; i < opciones.Length; i++)
        {
            opciones[i].text = opcionActual.opciones[i].textoOpciones;
        }
    }

    public void cargarOpciones()
    {
        try
        {
            bancoOpciones =
                JsonConvert
                    .DeserializeObject<Opcion>(File
                        .ReadAllText(Application.streamingAssetsPath +
                        "/ChoicesBank.json"));

        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.Message);
            enunciado.text = ex.Message;
        }
    }

    public void evaluarOpcion(int respuestaJugador)
    {
        opcionActual = opcionActual.opciones[respuestaJugador];
        if (opcionActual.esFinal)
        {
            enunciado.text = opcionActual.enunciado;
            for (int i = 0; i < btnRespuesta.Length; i++)
            {
                btnRespuesta[i].SetActive(false);
            }
            
            if (opcionActual.enunciado.Equals("Despues de correr 50 mts, al fin llegas a la carretera y ahora estas en el lugar donde empezo todo, volteas a ver atras y ves que la cabanna ya no esta, tambien notas que el hotel del que huiste tampoco esta, al mismo tiempo, comienza a salir el sol. Felicidades! Has sobrevivido la noche.") ||
                opcionActual.enunciado.Equals("Felicidades, has escapado pacificamente del hotel y has conseguido irte a casa. Los fantasmas no podian tocarte fisicamente, asi que solo podian atraparte con una de sus trampas o si les faltabas el respeto."))
            {
                btnGane.SetActive(true);
            }
            else
            {
                btnPerdida.SetActive(true);
            }
        }
        else
        {
            setEnunciado();
        }

    }

}
