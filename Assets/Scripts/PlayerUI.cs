using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Cetz, Zulema
/// 11/4/24
/// Script for updating UI of Player's Health
/// </summary>
public class PlayerUI : MonoBehaviour
{
    public Player player;
    public TMP_Text hpText;
    public TMP_Text controls;
    public TMP_Text activeItems;
    public TMP_Text lvl4instructions;

    private void Update()
    {
        hpText.text = "HP: " + player.health; //shows player hp
        controls.text = "Move: WASD\nJump: Spacebar\nShoot: LShift"; // shows game controls
        if (player.HB) // shows whether if the player has the heavy bullet power up on
            activeItems.text = "Heavy Bullets: Active";
        else activeItems.text = " ";
        if (player.sceneIndex == 4) // shows instructions for the player for beating the fourth level when they are on it 
            lvl4instructions.text = "Must have:\r\n-Jump Pack\r\n-Heavy Bullets\r\nThen:\r\n-Shoot the Door";
        else lvl4instructions.text = " ";
    }
}
