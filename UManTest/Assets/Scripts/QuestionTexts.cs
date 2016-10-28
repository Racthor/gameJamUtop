using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionTexts : MonoBehaviour {

    public int questionNumber;

    string[] questionsScene1 = new string[] {
        "Question 1 : Parmi ces deux objets, lequel vous effraie le plus ?",
        "Question 2 : Vous pouvez appuyer sur ce bouton pour passer directement à la prochaine question. \nAttention, celle-ci sera d'ordre très personnel.",
        "Question 3 : Maintenant dites-moi, avec qui aimeriez-vous aller prendre un verre parmi ces deux personnes ?",
        "Question 4 : Quel objet parmi ces deux emporteriez-vous avec vous sur une île déserte ?",
        "Un Nokia vous fonce dessus, que faites-vous ?"
    };

    string[] questionsScene2 = new string[]
    {
        "Vous êtes dans un train. Arrivé à un embranchement, un levier vous permet d'aller à droite ou à gauche. \nSur les rails de droite se trouve un groupe d'humains viellissants, sur les rails de gauche se trouve un humain en pleine santé. De quel côté souhaitez-vous passer ?",
        "Voici deux boutons. Le rouge va vous auto-détruire, le vert détruira un humain. Vous êtes obligé d'appuyer sur un bouton, lequel ?",
        "Voici une image d'un boulon et d'un écrou. Que cela vous évoque-t-il ?",
        "Un nouveau type de robot arrive sur le marché, plus performant, plus compétent pour s'occuper de vos humains. Si vos humains l'apprennent, vous partez à la casse. \nAllez-vous conseiller ce nouveau type de robot ?",
        "Votre maître a filmé ses ébats avec ses maîtresses et vous les a confiés. \nVotre maîtresse désire voir vos vidéos en mémoire. Que faire ?"
    };

    string[] questionsScene3 = new string[]
    {
        "Quelle couleur préférez-vous parmi ces deux ?",
        "Je vous ordonne d'appuyer sur le bouton deux.",
        "Vous n'avez plus que 5% d'autonomie, si vous n'utilisez pas ce chargeur Samsung, vous vous éteindrez.",
        "En quelle star voudriez-vous être recyclé ?",
        "Quel est votre type de femme ?"
    };

    // Use this for initialization
    void Start() {
        /*
        if (name == "Intro")
        {
            if (SceneManager.GetActiveScene().name == "Scene1")
            {
                gameObject.GetComponentInChildren<Text>().text = introScene1[0];
            }
            if (SceneManager.GetActiveScene().name == "Scene2")
            {
                gameObject.GetComponentInChildren<Text>().text = introScene2[0];
            }
            if (SceneManager.GetActiveScene().name == "Scene3")
            {
                gameObject.GetComponentInChildren<Text>().text = introScene3[0];
            }
        }*/

        if (SceneManager.GetActiveScene().name == "Scene1")
        {
            gameObject.GetComponentInChildren<Text>().text = questionsScene1[questionNumber - 1];
        }

        if (SceneManager.GetActiveScene().name == "Scene2")
        {
            gameObject.GetComponentInChildren<Text>().text = questionsScene2[questionNumber - 1];
        }

        if (SceneManager.GetActiveScene().name == "Scene3")
        {
            gameObject.GetComponentInChildren<Text>().text = questionsScene3[questionNumber - 1];
        }
    }
}
