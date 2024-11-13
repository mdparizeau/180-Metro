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

    private void Update()
    {
        hpText.text = "HP: " + player.health;
        controls.text = "Move: WASD\nJump: Spacebar\nShoot: LShift";
        activeItems.text = "Active Items: ";// + 
    }
}
