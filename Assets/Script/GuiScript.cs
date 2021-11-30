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
    public int idleDps;

    //UI
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI dpsText;

    // UI Spell
    public TextMeshProUGUI fireLvl;
    public TextMeshProUGUI iceLvl;
    public TextMeshProUGUI runicLvl;



    // public Button fireButon;
    // public Button iceButton;
    // public Button runicButton;

    //contoh
    // int intToSave;
    // float floatToSave;
    // string stringToSave = "";
    // Start is called before the first frame update
    void Start()
    {
        //starting game
        LoadGame();
        assignOnClick();

        //fungsi untuk auto save game perdetik [time]
        float time = 5f;
        InvokeRepeating("SaveGame", time, time);
    }

    // Update is called once per frame
    void Update()
    {
        //masukin parameter ke UI
        moneyText.text = '$' + money.ToString();
        waveText.text = wave.ToString();
        dpsText.text = dps.ToString();

        fireLvl.text = "Lv. " + fire.ToString();
        iceLvl.text = "Lv. " + ice.ToString();
        runicLvl.text = "Lv. " + runic.ToString();
    }

    //update Spell 
    void upgradeSpell(string spellName, int upgradePrice)
    {
        if (money >= upgradePrice)
        {
            money -= upgradePrice;
            if (spellName == "fire")
            {
                fire += 1;
                dps += 100;
            }
            else if (spellName == "ice")
            {
                ice += 1;
                idleDps += 10;
            }
            else if (spellName == "runic")
            {
                runic += 1;
                dps += 200;
            }
        }
        else
        {
            Debug.Log("uang ga cukup dek!");
        }
    }

    void initialValue()
    {
        //spell parameter
        fire = 1;
        ice = 1;
        runic = 1;

        //base parameter
        money = 0;
        wave = 1;
        dps = (fire * 100) + (runic * 200);
        idleDps = ice * 10;
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
        PlayerPrefs.SetInt("idleDps", idleDps);

        //Spell
        PlayerPrefs.SetInt("fire", fire);
        PlayerPrefs.SetInt("ice", ice);
        PlayerPrefs.SetInt("runic", runic);

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

            //base parameter
            money = PlayerPrefs.GetInt("money");
            wave = PlayerPrefs.GetInt("wave");
            dps = PlayerPrefs.GetInt("dps");
            idleDps = PlayerPrefs.GetInt("idleDps");

            //spell
            fire = PlayerPrefs.GetInt("fire");
            ice = PlayerPrefs.GetInt("ice");
            runic = PlayerPrefs.GetInt("runic");

            Debug.Log("Game data loaded!");
        }
        else
        {
            Debug.Log("no save data");
            initialValue();
            SaveGame();
        }
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

    void assignOnClick()
    {
        //button assign
        Button btnFire = GameObject.Find("Buy Fire").GetComponent<Button>();
        btnFire.onClick.AddListener(delegate { upgradeSpell("fire", 10); });

        Button btnIce = GameObject.Find("Buy Ice").GetComponent<Button>();
        btnIce.onClick.AddListener(delegate { upgradeSpell("ice", 15); });

        Button btnRunic = GameObject.Find("Buy Runic").GetComponent<Button>();
        btnRunic.onClick.AddListener(delegate { upgradeSpell("runic", 25); });
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
}

