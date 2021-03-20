using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static bool legendaryMode = false;

    public void NormalTutorialClicked()
    {
        Game.level = -3;
        Game game = new Game();
        game.WinBattle();
    }

    public void NormalNoTutorialClicked()
    {
        Game.level = 0;
        Game game = new Game();
        game.WinBattle();
    }

    public void LegendaryModeClicked()
    {
        Game.level = 0;
        legendaryMode = true;
        Game game = new Game();
        game.WinBattle();
    }
}
