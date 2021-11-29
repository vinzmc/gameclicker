using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GuiScript : MonoBehaviour
{
    //Spell
    int fire;
    int ice;
    int runic;

    //Variable, (jangan di atur di inspector)

    public int money;
    public int wave;
    public int dps;

    //UI
    public TextMeshProUGUI moneyUi;
    public TextMeshProUGUI waveUI;
    public TextMeshProUGUI dpsUi;

    //contoh
    // int intToSave;
    // float floatToSave;
    // string stringToSave = "";
    // Start is called before the first frame update
    void Start()
    {
        //starting game
        LoadGame();

        //fungsi untuk auto save game perdetik [time]
        float time = 60f;
        InvokeRepeating("SaveGame", time, time);
    }

    // Update is called once per frame
    void Update()
    {
        //masukin parameter ke UI
        moneyUi.text = '$'+money.ToString();
        waveUI.text = wave.ToString();
        dpsUi.text = dps.ToString();
        
    }


    void OnGUI()
    {
        // if (GUI.Button(new Rect(0, 0, 125, 50), "Raise Integer"))
        //     intToSave++;
        // if (GUI.Button(new Rect(0, 100, 125, 50), "Raise Float"))
        //     floatToSave += 0.1f;
        // stringToSave = GUI.TextField(new Rect(0, 200, 125, 25),
        //            stringToSave, 15);
        // GUI.Label(new Rect(375, 0, 125, 50), "Integer value is "
        //            + intToSave);
        // GUI.Label(new Rect(375, 100, 125, 50), "Float value is "
        //            + floatToSave.ToString("F1"));
        // GUI.Label(new Rect(375, 200, 125, 50), "String value is "
        //           + stringToSave);
        // if (GUI.Button(new Rect(750, 0, 125, 50), "Save Your Game"))
        //     SaveGame();
        // if (GUI.Button(new Rect(750, 100, 125, 50),
        //             "Load Your Game"))
        //     LoadGame();
    }

    void SaveGame()
    {
        //Contoh
        // PlayerPrefs.SetInt("SavedInteger", intToSave);
        // PlayerPrefs.SetFloat("SavedFloat", floatToSave);
        // PlayerPrefs.SetString("SavedString", stringToSave);

        // Base Parameter
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("wave", wave);
        PlayerPrefs.SetInt("dps", dps);

        //Spell

        //save game
        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }


    void LoadGame()
    {
        if (PlayerPrefs.HasKey("money"))
        {
            // contoh
            // intToSave = PlayerPrefs.GetInt("SavedInteger");
            // floatToSave = PlayerPrefs.GetFloat("SavedFloat");
            // stringToSave = PlayerPrefs.GetString("SavedString");

            money = PlayerPrefs.GetInt("money");
            wave = PlayerPrefs.GetInt("wave");
            dps = PlayerPrefs.GetInt("dps");
            Debug.Log("Game data loaded!");
        }
        else
        {
            Debug.Log("no save data");
            initialValue();
            SaveGame();
        }
    }

    void initialValue()
    {
        money = 0;
        wave = 1;
        dps = 10;
    }

    void exitGame()
    {
        SaveGame();
        Application.Quit();
    }

    // void ResetData()
    // {
    //     PlayerPrefs.DeleteAll();
    //     intToSave = 0;
    //     floatToSave = 0.0f;
    //     stringToSave = "";
    //     Debug.Log("Data reset complete");
    // }
}
