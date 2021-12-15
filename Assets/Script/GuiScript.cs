using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GuiScript : MonoBehaviour
{
    //Spell
    int fire;
    int ice;
    int runic;

    //Spell Price
    int firePrice;
    int icePrice;
    int runicPrice;

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

    // UI Spell Price
    public Text firePriceUI;
    public Text icePriceUI;
    public Text runicPriceUI;



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

        //spell Level
        fireLvl.text = "Lv. " + fire.ToString();
        iceLvl.text = "Lv. " + ice.ToString();
        runicLvl.text = "Lv. " + runic.ToString();

        //harga spell
        firePrice = fire * (10 * fire / 10);
        icePrice = ice * (20 * ice / 10);
        runicPrice = runic * (500 * runic / 10);

        //spell UI
        firePriceUI.text = "BUY\n$" + WordNotation(firePrice, "F2");
        icePriceUI.text = "BUY\n$" + WordNotation(icePrice, "F2");
        runicPriceUI.text = "BUY\n$" + WordNotation(runicPrice, "F2");
    }

    // Update is called once per frame
    void Update()
    {
        //masukin parameter ke UI
        moneyText.text = '$' + WordNotation(money, "F2");
        waveText.text = wave.ToString();
        dpsText.text = dps.ToString();
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

        //spell Level
        fireLvl.text = "Lv. " + fire.ToString();
        iceLvl.text = "Lv. " + ice.ToString();
        runicLvl.text = "Lv. " + runic.ToString();

        //harga spell
        firePrice = fire * (10 * fire / 10);
        icePrice = ice * (20 * ice / 10);
        runicPrice = runic * (500 * runic / 10);

        //spell UI
        firePriceUI.text = "BUY\n$" + WordNotation(firePrice, "F2");
        icePriceUI.text = "BUY\n$" + WordNotation(icePrice, "F2");
        runicPriceUI.text = "BUY\n$" + WordNotation(runicPrice, "F2");
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
        btnFire.onClick.AddListener(delegate { upgradeSpell("fire", firePrice); });

        Button btnIce = GameObject.Find("Buy Ice").GetComponent<Button>();
        btnIce.onClick.AddListener(delegate { upgradeSpell("ice", icePrice); });

        Button btnRunic = GameObject.Find("Buy Runic").GetComponent<Button>();
        btnRunic.onClick.AddListener(delegate { upgradeSpell("runic", runicPrice); });

        // Button btnMaxIce = GameObject.Find("BuyMax Fire").GetComponent<Button>();
        // btnRunic.onClick.AddListener(delegate { buyMaxSpell("fire"); });

        // Button btnMaxFire = GameObject.Find("BuyMax Ice").GetComponent<Button>();
        // btnRunic.onClick.AddListener(delegate { buyMaxSpell("ice"); });

        // Button btnMaxRunic = GameObject.Find("BuyMax Runic").GetComponent<Button>();
        // btnRunic.onClick.AddListener(delegate { buyMaxSpell("runic"); });
    }

    // void buyMaxSpell(String spell)
    // {

    //     int savedMoney = money;
    //     do
    //     {
    //         if (spell == "fire")
    //         {
    //             upgradeSpell(spell, firePrice);
    //         }
    //         else if (spell == "ice")
    //         {
    //             upgradeSpell(spell, icePrice);
    //         }
    //         else
    //         {
    //             upgradeSpell(spell, runicPrice);
    //         }
    //     } while (savedMoney != money);
    // }

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

    string WordNotation(int money, string digits)
    {
        int digitsTemp = Convert.ToInt32(Mathf.Floor(Mathf.Log10(money)));
        IDictionary<int, string> prefixes = new Dictionary<int, string>()
        {
            {3,"K"},
            {4,"K"},
            {5,"K"},
            {6,"M"},
            {7,"M"},
            {8,"M"},
            {9,"B"},
            {10,"B"},
            {11,"B"},
            {12,"T"},
            {13,"T"},
            {14,"T"},
            {15,"Qa"},
        };
        if (money >= 1000)
            return (money / Mathf.Pow(10, digitsTemp)).ToString(digits) + prefixes[digitsTemp];
        return money.ToString(digits);
    }
}

