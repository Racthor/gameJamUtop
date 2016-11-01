using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int jaugePaul;        // La jauge de Paul.
    public static int jaugeUman;        // La jauge U-Man.
	
	public static int[] jaugePerLevel_Paul = {0, 0, 0};	// stocke les résultats de Paul à la fin de chaque niveau
	public static int[] jaugePerLevel_Uman = {0, 0, 0};	// stocke les résultats de U-Man à la fin de chaque niveau

	private static int sceneIndex;
	private static int nextScene;

	private static ScoreManager instance;

	//Awake is called when the script instance is being loaded.
	void Awake () {
		// We want to have only 1 ScoreManager at a time
		if (!instance) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		}
		else
			Destroy (this.gameObject);
	}

	public void init() {
		Debug.Log ("Initializing ScoreManager");

		jaugePerLevel_Paul = new int[3] { 0, 0, 0 };
		jaugePerLevel_Uman = new int[3] { 0, 0, 0 };

		jaugePaul = 0;					// Initialisation des jauges à 0
		jaugeUman = 0;

		sceneIndex = 0;
	}

	public static void increasePaul(int amount) {
		jaugePerLevel_Paul [sceneIndex] += amount;
		jaugePaul += amount;
	}

	public static void increaseUman(int amount) {
		jaugePerLevel_Uman [sceneIndex] += amount;
		jaugeUman += amount;
	}

	public static void playOutro(Room currentRoom) {
		Scene currentScene = SceneManager.GetActiveScene();
		int next = currentScene.buildIndex + 1;				// index de la scène suivante

		// More scenes left
		if(next < 4){
			if(ScoreManager.jaugePaul >= 3 || ScoreManager.jaugeUman >= 3){
				currentRoom.outro.SetActive (true);
				nextScene = next;
				changeScene();
			}
			else {
				currentRoom.failure.SetActive (true);
				nextScene = 0; // To menu
			}
		}
		// Last scene
		else{
			nextScene = 0;
			int scorePaul = 0, scoreUman = 0;
			for(int i=0; i<3; ++i){
				scorePaul += ScoreManager.jaugePerLevel_Paul[i];
				scoreUman += ScoreManager.jaugePerLevel_Uman[i];
			}
			if(scoreUman < 10 && scorePaul < 10){
				if(ScoreManager.jaugePaul >= 3 || ScoreManager.jaugeUman >= 3){
					Debug.Log ("Fin MAJ");
					currentRoom.transform.FindChild ("FinMAJ").gameObject.SetActive (true);
					//nextScene = next; // Credits
				}
				else{
					currentRoom.failure.SetActive (true);
					//nextScene = 0;
				}
			}
			else if(scoreUman >= 10){
				Debug.Log ("Fin robot");
				currentRoom.transform.FindChild ("FinRobot").gameObject.SetActive (true);
				//nextScene = next; // Credits
			}
			else if(scorePaul >= 10){
				Debug.Log ("Paul de la compta ?! Mais que faites vous là ?");
				currentRoom.transform.FindChild ("FinPaul").gameObject.SetActive (true);
				//nextScene = next; // Credits
			}
		}

	}

	public static void changeScene () {
		sceneIndex = nextScene - 1;
		Debug.Log ("Loading scene " + nextScene);
		SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
	}

	public static int getSceneIndex () {
		return sceneIndex;
	}
}
