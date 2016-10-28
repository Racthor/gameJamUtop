using System.Collections;
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

    private GameObject examiner;

    public void setExaminer(GameObject examiner)
    {
        this.examiner = examiner;
    }

	void OnEnable () {
        Debug.Log("Start Intro !");

        this.enableExaminer();

        setIntroTextForCurrentScene();
		currentClip = -1;
		room = GetComponentInParent<Room> ();
		text = GetComponentInChildren<Text> ();

        // if the two arrays lengths are not equals, Debug an exception
		Debug.Assert (voiceClips.Length == texts.Length);

		nextClip ();
	}

    // activé par le clic sur le bouton continuer
    public void nextClip() {
        Debug.Log("RoomIntro nextClip Start");

		if (++currentClip < voiceClips.Length) {
			room.voice.clip = voiceClips [currentClip];
			room.voice.Play ();
			text.text = texts [currentClip];
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
                    "Bien unité 404, je suis l'expert chargé de faire passer votre premier test de conformité Apple. Le thème de ce test est intégrité physique. \n(Cliquez pour continuer)",
                    "Le principe est simple. Je vous pose une question auquel deux choix de réponses vous sont soumis. Affin d'améliorer l'exactitude des résultats, chacune des questions sera chronométrée. \n(Cliquez pour continuer)",
                    "Commençons… \n(Cliquez pour continuer)"
                };
                break;
            case "Scene2":
                texts = new string[] {
                    "Bonjour, je suis l'unité chargée de vous soumettre les tests de conformité morale. \nVeuillez bien croire que je ne prends aucun plaisir à observer votre  totale soumission à mes caprices. Les régles sont les mêmes que précédemment, cependant à la fin des tests il y aura du gâteau, si vous survivez du moins. \n(Cliquez pour continuer)"
                };
                break;
            case "Scene3":
                texts = new string[] {
                    "Bonjour, je suis Steve Jobs, bienvenue chez Apple. Maintenant que j'ai toute votre attention, sachez que ce test de conformité sera celui du libre arbitre. Bien sûr, en tant que Apple user, vous êtes censé en être dénué. Ah ah ! \n(Cliquez pour continuer)"
                };
                break;
        }
    }

    // set active the scene examiner
    public void enableExaminer()
    {
        examiner.gameObject.SetActive(true);
    }
}
