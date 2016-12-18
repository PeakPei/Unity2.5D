using UnityEngine;
using System.Collections;
using System.Text;
using System.IO; 
using UnityEngine.UI;
 
public class ReadHighScores : MonoBehaviour {
    public static int topAmount = 10;
    public Text highscoreText;
    public Highscores[] scores = new Highscores[topAmount];

    public class Highscores
    {
        public string date;
        public int score;
        public Highscores(string d, int s)
        {
            date = d;
            score = s;
        }
    }

    
    public void StartReading()
    {
        InitializeHighScores();
        Load("Assets/Textfiles/highscores.txt");
        highscoreText.text = CreateString();
        
    }
 
     private bool Load(string fileName){
             string line;
             int linenumber = 0;
             StreamReader theReader = new StreamReader(fileName, Encoding.Default);
             using (theReader)
             {
                 do
                 {
                     line = theReader.ReadLine();
                     
                     if (line != null)
                     {
                         string[] entries = line.Split(',');
                         if (entries.Length > 0){
                             if (linenumber < 10)
                             {
                                 scores[linenumber] = new Highscores(entries[0], int.Parse(entries[1]));
                                 linenumber++;
                             }
                             else
                             {
                                 Sort();
                                 scores[9] = new Highscores(entries[0], int.Parse(entries[1]));
                             }
                         }
                         
                     }
                 }
                 while (line != null);
                 theReader.Close();
                 return true;
            }
    }

     public void InitializeHighScores()
     {
         for (int i = 0; i < topAmount; i++)
         {
             Highscores test = new Highscores("Never", 0);
             scores[i] = test;
         }
     }

     public string CreateString()
     {
         Sort();
         string text = "";
         for (int i = 0; i < topAmount; i++)
         {
             text += i+1 + ". " + scores[i].date + " " + scores[i].score + ".\n";
         }
         return text;
     }

     public void Sort()
     {
         bool flag = true;
         for (int i = 1; (i <= (topAmount - 1)) && flag; i++)
         {
             flag = false;
             for (int j = 0; j < (topAmount - 1); j++)
             {
                 if (scores[j + 1].score > scores[j].score)
                 {
                     Highscores temp = scores[j];
                     scores[j] = scores[j+1];
                     scores[j+1] = temp;
                     flag = true;
                 }
             }
         }
        
     }
}
