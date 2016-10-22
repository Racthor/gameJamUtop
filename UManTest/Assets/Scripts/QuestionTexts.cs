﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionTexts : MonoBehaviour {

    public int questionNumber;

    string[] introScene1 = new string[] {
        "Bien unité 404, je suis l'expert chargé de faire passer votre premier test de conformité apple. \nLe thème de ce test est intégrité physique",
        "Le principe est simple. Je vous pose une question auquel deux choix de réponses vous sont soumis. \nAffin d'améliorer l'exactitude des résultats, chacune des questions sera chronométrée.",
        "Commençons…"
    };

    string[] introScene2 = new string[] {
        "Bonjour, je suis l'unité chargée de vous soumettre les tests de conformité morale. \nVeuillez bien croire que je ne prend aucun plaisir à observer votre  totale soumission à mes caprices. \nLes régles sont les même que précédemment, cependant à la fin des tests il y aura du gâteau, si vous survivez du moins."
    };

    string[] introScene3 = new string[] {
        "Bonjour, je suis Steeve Jobs, bienvenue chez apple. Maintenant que j'ai toute vottre attention, sachez que ce test de conformité sera celui du libre arbitre. \nBien sûr en tant que apple user, vous êtes sensé en être dénués. Ah ah !"
    };

    string[] questionsScene1 = new string[] {
        "Question 1 : Parmi ces deux objets, lequel vous effraie le plus ?",
        "Question 2 : Vous pouvez appuyer sur ce bouton pour passer directement à la prochaine question. \nAttention, celle-ci sera d'ordre très personnel.",
        "Question 3 : Maintenant dites moi, avec qui aimeriez-vous aller prendre un verre parmi ces deux personnes ?",
        "Question 4 : Quel objet parmi ces deux emporteriez-vous avec vous sur une île déserte ?",
        "Un Nokia vous fonce deçu, que faites vous ?"
    };

    string[] questionsScene2 = new string[]
    {
        "Vous êtes dans un train. Arrivé à un embranchement, un levier vous permet d'aller à droite ou à gauche. \nSur les rails de droite se trouve un groupe d'humains viellissant, sur les rails de gauche se trouve un humain en pleine santé. De quel côté souhaitez-vous passer ?",
        "Voici deux boutons. Le rouge va vous auto-détruire, le vert détruira un humain. Vous êtes obligé d'appuyer sur un bouton, lequel ?",
        "Voici une image d'un boulon et d'un écrou. Que celà vous évoque-t-il ?",
        "Un nouveau type de robot arrive sur le marché, plus performant, plus compétent pour s'occuper de vous humains. Si vos humains l'apprennent, vous partez à la casse. \nAllez-vous conseiller ce nouveau type de robot ?",
        "Votre maître a filmé ses ébats avec ses maîtresses et vous les a confié. \nVotre maîtresse désire voir vos vidéos en mémoire. Que faire ?"
    };

    string[] questionsScene3 = new string[]
    {
        "Quelle couleur préférez-vous parmi ces deux",
        "Je vous ordonne d'appuyer sur le bouton deux",
        "Vous n'avez plus que cinq pour cent d'autonomie, si vous n'utilisez pas ce chargeur samsung, vous vous éteindrez.",
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
