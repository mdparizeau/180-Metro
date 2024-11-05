using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayeUI : MonoBehaviour
{
    public Player player;
    public TMP_Text hpText;

    private void Update()
    {
        hpText.text = "HP: " + player.health;
    }
}
