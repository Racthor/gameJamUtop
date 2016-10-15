using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeLevel : MonoBehaviour {

	public GameObject[] backgrounds;

	// Use this for initialization
	void Start () {
		Scene currentScene = SceneManager.GetActiveScene();
		int next = currentScene.buildIndex + 1;				// index de la scène suivante
		
		if(next < 4){
			if(ScoreManager.jaugePaul >= 3 || ScoreManager.jaugeUman >= 3){
				SceneManager.LoadScene(next, LoadSceneMode.Single);
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
}
