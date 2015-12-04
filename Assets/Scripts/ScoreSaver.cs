using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour
{
	public string name { get; set; }
	public int level { get; set; }
}

public class ScoreSaver : MonoBehaviour
{
	static string path = @"save.txt";
    public static int score;
    Text[] nameArray;
    Text[] levelArray;

    public static void Write(string name, int level)
	{
		if (!File.Exists (path)) {
			using (StreamWriter sw = File.CreateText(path)) {
				sw.WriteLine ("{0}, {1}", name, level);
			}
		} else {
			List<Score> readscores = Read ();
			lock (readscores) {
				readscores.Add (new Score () { name = name, level = level });
				var result = from score in readscores
					orderby score.level descending
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
				Scarray.Add (new Score(){name = items[0], level = Convert.ToInt32 (items [1])});
			}
		}
		return Scarray;
	}

	public static void Clear()
	{
		// Clear if file exists
		if (File.Exists(path)) 
		{
			System.IO.File.WriteAllText(path,string.Empty);	
		}

	}

    void Awake()
    {
        List<Score> thisScarray = Read();
        for (int i = 0; i < 5; i++)
        {
            nameArray[i] = GetComponent<Text>();
            nameArray[i].text = thisScarray[i].name;
            
            levelArray[i] = GetComponent<Text>();
            levelArray[i].text = thisScarray[i].level.ToString();

        }
    }
}