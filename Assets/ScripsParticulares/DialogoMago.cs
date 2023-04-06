    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogoMago : MonoBehaviour
{
    
    public TextMeshProUGUI texto;
    private string[] dialogos;
    private float velicidad = 0.04f;
    private int index = 0;
    private string dialogoMago1 ="Yo: ¡Vaya! ¿Eres un mago?*Mago: Sí, soy un mago y necesito tu ayuda. Hay una tarea que solo alguien como tú puede realizar.*Yo: ¿Qué tipo de tarea?*Mago: Necesito que encuentres tres artefactos en diferentes mundos a través de los portales para activar los totems. Si lo haces, serás recompensado con un gran poder.  *Yo: Suena interesante, pero ¿por qué necesitas mi ayuda? ¿No puedes hacerlo tú mismo?  *Mago: Desafortunadamente, no puedo hacerlo yo mismo. Los portales solo pueden ser atravesados por alguien que no sea un mago. Y solo alguien que sea lo suficientemente valiente y astuto como para completar la tarea podrá encontrar los artefactos.  *Yo: Entiendo. ¿Qué artefactos necesito encontrar?  *Mago: Necesitas encontrar la piedra del conocimiento  en el mundo que se llama La mina, la piedra del alma en el Jardin de Nigella y el la piedra del destino en el mundo de los Antiguos. Una vez que tengas los tres artefactos, tráelos de vuelta aquí y los usaremos para activar los totems.  *Yo: ¿Cómo sé cómo llegar a estos mundos?  *Mago: Solo tienes que atravesar los portales que se encuentran al final de cada camino de piedra que encontrarás al final de este camino.  *Yo: Entiendo. Pero, ¿cómo sé qué hacer cuando llegue a cada mundo?  *Mago: Cada mundo tiene sus propios desafíos y peligros. *Yo: Bien, lo intentaré. ¿Qué pasa si no puedo completar la tarea?  *Mago: Si no puedes completar la tarea, el mundo estará en grave peligro. Los totems son la única defensa que tenemos contra la oscuridad. Pero confío en ti. Sé que puedes hacerlo.  *Yo: Lo intentaré. Gracias por confiar en mí.  *Mago: Buena suerte, mi amigo. El destino del mundo está en tus manos.";
    private string dialogoMago2 ="Mago: Todavía no tienes todas los rocas! apurate, el fin del mundo está muy cerca, lo puedo sentir.";
    private string dialogoMago3 ="Mago: ¡Por fin has llegado! ¿Tienes los objetos que te pedí?*Yo: Sí, aquí están.*Mago: He estado investigando y parece que una antigua profecía se está cumpliendo. Solo tenemos una oportunidad de evitar la destrucción total. *Yo: Entiendo. Espero que estos objetos ayuden.  *Mago: Definitivamente lo harán, solo necesito encantar las piedras para unirlas.   *Yo: ¿Cómo funciona eso?  *Mago: Las piedras tienen ciertas propiedades mágicas, pero al unirlas con este hechizo, podemos combinar y amplificar esas propiedades. Así, poder activar los totems.*(El mago se arrodilla y empieza a gritar una frase en una lengua desconocida)*(Empieza a salir una luz tan intensa pero a la vez tan hermosa como nunca se había visto)*Mago: Listo, aquí está, la piedra que salvará al mundo*Mago: Agarrla y ponla en alguno de los totems para poner fin a esta profecía";
    private string dialogoMago4 ="Mago: Pon la roca en alguno de los totems, ¡Apurate!";
    private string dialogoMago5 ="Mago: Siiiii!! eso debe de bastar en 3...*Mago:2...*Mago:1...";
    private int estadoDialogo = 0;
    public bool pasaAlaSiguienteFase = true;
    public InspeccionarMago inspeccionarMago;
    public GameObject finDelJuego;
    public void dialogosController(){
        estadoDialogo = PlayerPrefs.GetInt("dialogoMagoNivel0");
        // PlayerPrefs.SetInt("dialogoMagoNivel0", 1);
        // estadoDialogo = 1;
        if(index==0){
            texto.text = string.Empty;
            gameObject.SetActive(true);
            switch(estadoDialogo){
                case 0:dialogos = dialogoMago1.Split('*');
                pasaAlaSiguienteFase = true;
                mostrarDialogo();
                break;
                case 1:dialogos = dialogoMago2.Split('*');
                mostrarDialogo();
                break;
                case 2:dialogos = dialogoMago3.Split('*');
                mostrarDialogo();
                break;
                case 3:dialogos = dialogoMago4.Split('*');
                mostrarDialogo();
                break;
                case 4:dialogos = dialogoMago5.Split('*');
                mostrarDialogo();
                break;
            }
        }
    }
    void Update() {
        if(Input.GetMouseButtonDown(0)){
            if(texto.text == dialogos[index]){
                NextLine();
            }else{
                StopAllCoroutines();
                texto.text = dialogos[index];
            }
        }
    }

    void mostrarDialogo(){
        StartCoroutine(LoadYourAsyncScene());
    }
    IEnumerator LoadYourAsyncScene(){
        foreach(char c in dialogos[index].ToCharArray()){
            texto.text  += c;
            yield return new WaitForSeconds(velicidad);
        }
    }
    void NextLine(){
        if(index < dialogos.Length - 1){
            index++;
            texto.text = string.Empty;
            StartCoroutine(LoadYourAsyncScene());
        }else{
            if(estadoDialogo==0 && pasaAlaSiguienteFase){
                estadoDialogo = 1;
            }else if(estadoDialogo==1 && pasaAlaSiguienteFase){
                estadoDialogo = 2;
            }else if(estadoDialogo==2 && pasaAlaSiguienteFase){
                inspeccionarMago.soltarObjectoPrincipal();
                estadoDialogo = 3;
            }else if(estadoDialogo==3 && pasaAlaSiguienteFase){
                // estadoDialogo = 4;
            }else if(estadoDialogo==4 && pasaAlaSiguienteFase){
                finDelJuego.SetActive(true);
            }else if(estadoDialogo==5 && pasaAlaSiguienteFase){
                
            }
            
            PlayerPrefs.SetInt("dialogoMagoNivel0", estadoDialogo);
            PlayerPrefs.Save();
            index = 0;
            gameObject.SetActive(false);
            StopAllCoroutines();
        }
    }
}




