using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Prelude : MonoBehaviour {

    private Room room;
    public AudioClip voiceClip;
    private GameObject intro;
    private Text text;

    public void setIntro(GameObject intro)
    {
        this.intro = intro;
    }

    // Use this for initialization
    void OnEnable () {
        Debug.Log("start Prelude !");

        room = GetComponentInParent<Room>();
        text = GetComponentInChildren<Text>();

        playScenePrelude();
    }

    // Play the sound and display the text
    private void playScenePrelude()
    {
        room.voice.clip = voiceClip;
        room.voice.Play();
        text.text = this.getScenePreludeText();
    }

    // disable prelude and start intro
    // activé par le clic sur le bouton continuer
    public void playIntro()
    {
        this.gameObject.SetActive(false);
        intro.SetActive(true);
    }

    // Return the text of the prelude for the current scene
    private string getScenePreludeText()
    {
        string textReturned = "";

        switch (SceneManager.GetActiveScene().name)
        {
            case "Scene1":
                textReturned = "Bienvenue au centre de conformité Apple, uMan 404. Vous êtes convié à la procédure de vérification de votre bon fonctionnement. Cette intervention fait suite à la procédure 463f2 palliant au problème de dysfonctionnement présent dans la gamme uMan. Un expert viendra dans quelques instants vous soumettre au test de conformité numéro 1 : test d'integrité physique. Sachez qu'en cas d'échec à ce test, la loi 43293 prévoit la destruction totale de votre unité. Passez un bon test de conformité, bonne journée. \n \n(Cliquez pour continuer)";
                break;
            case "Scene2":
                textReturned = "Félicitations ! Vous avez passé le test d'integrité physique avec succès. Nous vous invitons à vous soumettre au prochain test de conformité. Bonne journée. \n(Cliquez pour continuer)";
                break;
            case "Scene3":
                textReturned = "Félicitations ! Vous avez passé le test d'integrité morale avec succès. Nous vous invitons à vous soumettre au prochain test de conformité. Bonne journée. \n(Cliquez pour continuer)";
                break;
        }

        return textReturned;
    }

}
