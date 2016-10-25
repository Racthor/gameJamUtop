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

        // playIntro after the voice clip ends (with a blanc of 0.2 sec)
        Invoke("playIntro", room.voice.clip.length + 0.2f);
    }

    // Play the sound and display the text
    private void playScenePrelude()
    {
        room.voice.clip = voiceClip;
        room.voice.Play();
        text.text = this.getScenePreludeText();
    }

    // disable prelude and start intro
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
                textReturned = "Bienvenue au centre de conformité apple uMan 404. Vous êtes convié à la procédure de vérification de votre bon fonctionnement. Cette intervention fait suite à la procédure 463f2 paliant au problème de disfonctionnement présent dans la gamme uMan. Un expert viendra dans quelques instants vous soumetre aux test de conformité numéro 1 : test d'integrité physique. Sachez qu'en cas d'échec à ce test, la loi 43293 prévoi la destruction totale de votre unité. Passez un bon test de conformité, bonne journée. \\n";
                break;
            case "Scene2":
                textReturned = "Bonjour, je suis l'unité chargée de vous soumettre les tests de conformité morale. \nVeuillez bien croire que je ne prend aucun plaisir à observer votre  totale soumission à mes caprices. Les régles sont les même que précédemment, cependant à la fin des tests il y aura du gâteau, si vous survivez du moins.";
                break;
            case "Scene3":
                textReturned = "Bonjour, je suis Steeve Jobs, bienvenue chez apple. Maintenant que j'ai toute votre attention, sachez que ce test de conformité sera celui du libre arbitre. Bien sûr en tant que apple user, vous êtes sensé en être dénué. Ah ah !";
                break;
        }

        return textReturned;
    }

}
