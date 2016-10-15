using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int jaugePaul;        // La jauge de Paul.
    public static int jaugeUman;        // La jauge U-Man.
	
	public static int[] jaugePerLevel_Paul;	// stocke les résultats de Paul à la fin de chaque niveau
	public static int[] jaugePerLevel_Uman;	// stocke les résultats de U-Man à la fin de chaque niveau

	//Awake is called when the script instance is being loaded.
	void Awake () {
		jaugePerLevel_Paul = new int[3] {0,0,0};
		jaugePerLevel_Uman = new int[3] {0,0,0};
		
		jaugePaul = 0;					// Initialisation des jauges à 0
		jaugeUman = 0;
	}
	
	
}