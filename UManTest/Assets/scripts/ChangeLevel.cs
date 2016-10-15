using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeLevel : MonoBehaviour {

	private int sceneIndex;

	void Start () {
		sceneIndex = 0;
	}

	// Use this for initialization
	void changeScene () {
		sceneIndex++;
		Scene currentScene = SceneManager.GetActiveScene();
		int index = currentScene.buildIndex;				// index de la scène suivante
		
		if(index < 3){
			if(ScoreManager.jaugePaul >= 3 || ScoreManager.jaugeUman >= 3){
				ScoreManager.jaugePerLevel_Paul[index] = ScoreManager.jaugePaul;
				ScoreManager.jaugePerLevel_Uman[index] = ScoreManager.jaugeUman;
				SceneManager.LoadScene(index + 1, LoadSceneMode.Single);
			}
			else {
				// Mort horrible !
			}
		}
		else{
			int scorePaul = 0, scoreUman = 0;
			for(int i=0; i<3; ++i){
				scorePaul += ScoreManager.jaugePerLevel_Paul[i];
				scoreUman += ScoreManager.jaugePerLevel_Uman[i];
			}
			if(scoreUman < 10 && scorePaul < 10){
				if(ScoreManager.jaugePaul >= 3 || ScoreManager.jaugeUman >= 3){
					// Vous êtes lobotomiser
				}
				else{
					// Vous êtes détruit d'une horrible manière
				}
			}
			else if(scoreUman >= 10){
				// Vous n'avez pas besoin de mise à jour félicitations, vous allez être remis en service
			}
			else if(scorePaul >= 10){
				// Paul de la compta ?! Mais que faites vous là ?
			}
		}
	}

	int getSceneIndex () {
		return sceneIndex;
	}
}
