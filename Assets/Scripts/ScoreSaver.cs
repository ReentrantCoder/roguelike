using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score
{
	public string name { get; set; }
	public string level { get; set; }
}

public class ScoreSaver : MonoBehaviour
{
	static string path = @"save.txt";
    public static int score;
    public Text[] nameArray;
    public Text[] levelArray;
    private GameObject scoreCanvas;

    public static void Write(string name, string levelString)
	{
        int level =  Int32.Parse(levelString);
        if (!File.Exists (path)) {
			using (StreamWriter sw = File.CreateText(path)) {
				sw.WriteLine ("{0}, {1}", name, level);
			}
		} else {
			List<Score> readscores = Read ();
			lock (readscores) {
				readscores.Add (new Score () { name = name, level = levelString });
				var result = from score in readscores
					orderby Int32.Parse(score.level) descending
						select score;

				//Adds only the top 5 scores
				using (StreamWriter sw = File.CreateText(path)) {
					int i = 0;
					foreach (Score score in result) {
						if (i < 5) {
							sw.WriteLine ("{0}, {1}", score.name, score.level);
							i++;
						}
					}
				}
			}
		}
	}

	public static List<Score> Read()
	{
		List<Score> Scarray = new List<Score>();

		// Open the file to read from.
		using (StreamReader sr = File.OpenText(path)) 
		{
			string s = "";
			while ((s = sr.ReadLine()) != null) 
			{
				string[] items = s.Split(',');
				Scarray.Add (new Score(){name = items[0], level = items [1]});
			}
		}
		return Scarray;
	}

	public void Clear()
	{
        //Debug.Log("Clear called");
		// Clear if file exists
		if (File.Exists(path)) 
		{
			System.IO.File.WriteAllText(path,string.Empty);
        }
        //List<Score> thisScarray = Read();
        //for (int i = 0; i < 5; i++)
        //{

        //    nameArray[i].text = "";
        //    nameArray[i] = GetComponent<Text>();

        //    levelArray[i].text = "";
        //    levelArray[i] = GetComponent<Text>();
        //}
        //scoreCanvas = GameObject.Find("ScoreCanvas");
        //scoreCanvas.SetActive(false);
        //scoreCanvas.SetActive(true);

        UpdateScores();
    }

    void Awake()
    {
        //Debug.Log("Awake called");
        UpdateScores();
    }

    void UpdateScores()
    {
        List<Score> thisScarray = Read();
        //Debug.Log("count = " + thisScarray.Count);
        for (int i = 0; i < 5; i++)
        {
            //Debug.Log("i = " + i);
            nameArray[i].text = (i < thisScarray.Count) ? thisScarray[i].name : "";
            //Debug.Log(nameArray[i].text);
            //nameArray[i] = GetComponent<Text>(); 
            
            levelArray[i].text = (i < thisScarray.Count) ? thisScarray[i].level : "";
            //levelArray[i] = GetComponent<Text>();
        }

    }
}