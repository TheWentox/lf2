using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class AchievementHandler : MonoBehaviour
{
    public GameObject achievementUI;
    public AudioClip achievementSound;
    public AudioSource audioSource;

    public GameObject text;

    private List<string> completedAchievements;
    private float counter = 3.0f;

    void Start()
    {
        completedAchievements = new List<string>();
        string line;

        if (File.Exists($"{Path.GetTempPath()}\\achievements.txt"))
        {
            StreamReader file = new StreamReader($"{Path.GetTempPath()}\\achievements.txt");
            while ((line = file.ReadLine()) != null)
            {
                completedAchievements.Add(line);
            }
        }
    }

    void Update()
    {
        if (achievementUI.activeSelf)
        {
            if (counter <= 0.0f)
            {
                achievementUI.SetActive(false);
                counter = 3.0f;
            }

            counter -= Time.deltaTime;
        }
    }

    public void NewAchievement(string achievementName)
    {
        if (completedAchievements.Contains(achievementName))
        {
            Debug.Log("Achievement already completed");
            return;
        }

        completedAchievements.Add(achievementName);
        text.GetComponent<Text>().text = achievementName;
        achievementUI.SetActive(true);
        audioSource.PlayOneShot(achievementSound);
    }

    void OnDestroy()
    {
        File.WriteAllLines($"{Path.GetTempPath()}\\achievements.txt", completedAchievements);
    }
}
