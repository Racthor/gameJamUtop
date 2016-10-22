﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomIntro : MonoBehaviour {

	public AudioClip[] voiceClips;
	public string[] texts;

	private int currentClip;
	private Room room;
	private Text text;

	void OnEnable () {
        setIntroTextForCurrentScene();
		currentClip = -1;
		room = GetComponentInParent<Room> ();
		text = GetComponentInChildren<Text> ();

		Debug.Assert (voiceClips.Length == texts.Length);

		nextClip ();
	}

	void nextClip() {
		if (++currentClip < voiceClips.Length) {
			room.voice.clip = voiceClips [currentClip];
			room.voice.Play ();
			text.text = texts [currentClip];

			Invoke ("nextClip", room.voice.clip.length);
		} else {
			this.gameObject.SetActive (false);
			room.beginQuestions ();
		}
	}

    // Set the intro texts arrays for the current scene (the sounds still have to be declared with the Unity engine)
    void setIntroTextForCurrentScene()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Scene1":
                texts = new string[]
                {
                    "Bien unité 404, je suis l'expert chargé de faire passer votre premier test de conformité apple. \nLe thème de ce test est intégrité physique",
                    "Le principe est simple. Je vous pose une question auquel deux choix de réponses vous sont soumis. \nAffin d'améliorer l'exactitude des résultats, chacune des questions sera chronométrée.",
                    "Commençons…"
                };
                break;
            case "Scene2":
                texts = new string[] {
                    "Bonjour, je suis l'unité chargée de vous soumettre les tests de conformité morale. \nVeuillez bien croire que je ne prend aucun plaisir à observer votre  totale soumission à mes caprices. \nLes régles sont les même que précédemment, cependant à la fin des tests il y aura du gâteau, si vous survivez du moins."
                };
                break;
            case "Scene3":
                texts = new string[] {
                    "Bonjour, je suis Steeve Jobs, bienvenue chez apple. Maintenant que j'ai toute vottre attention, sachez que ce test de conformité sera celui du libre arbitre. \nBien sûr en tant que apple user, vous êtes sensé en être dénué. Ah ah !"
                };
                break;
        }
    }
}
