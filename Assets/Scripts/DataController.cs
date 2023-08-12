using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class DataController : MonoBehaviour
{
    [SerializeField] LevelConfigData data;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(this.data.gold);
        PlayerPrefs.SetInt("HighScore",10);

        if (PlayerPrefs.HasKey("HighScore"))
        {
            int highScore = PlayerPrefs.GetInt("HighScore"); //10
        }

        PlayerPrefs.GetInt("HighScore",-1);

        PlayerPrefs.SetInt("Sound",0);

        PlayerPrefs.SetInt("Music",1);

        if(PlayerPrefs.GetInt("Music") == 1) {
            //music on
        }
        else {
            //music off
        }

        string data = PlayerPrefs.GetString("UserData");

        var playerData = JSON.Parse(data);

        Debug.Log(playerData["age"].AsInt);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            string data = PlayerPrefs.GetString("UserData");
            UserData player = JsonUtility.FromJson<UserData>(data);

            player.maxHP += 40.5f;

            data = JsonUtility.ToJson(player);

            PlayerPrefs.SetString("UserData", data);
        }
    }
}


public class UserData {
    public string name;
    public int age;
    public float maxHP;
    public PetData pet;

}

public class PetData {
    public string nickName;
    public string kind;
    public int age;
}