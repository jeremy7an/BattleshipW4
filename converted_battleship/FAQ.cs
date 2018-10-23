
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using SwinGameSDK;

/// <summary>
/// Controls displaying and collecting high score data.
/// </summary>
/// <remarks>
/// Data is saved to a file.
/// </remarks>
static class FAQ
{
	
	/// <summary>
	/// Draws the high scores to the screen.
	/// </summary>
	public static void DrawFAQ ()
	{
		const int SCORES_HEADING = 0;
		const int SCORES_LEFT = 330;
		SwinGame.DrawText ("Instructions:", Color.Green, GameResources.GameFont ("Courier"), SCORES_LEFT, SCORES_HEADING);
		SwinGame.DrawText ("Each of the player will get an empty grid that must be filled with the provided ship figures.", Color.White, GameResources.GameFont ("Courier"), 0, 30);
		SwinGame.DrawText ("The ships should be allocated accordingly the provided space(10x10),each ship has its own size.", Color.White, GameResources.GameFont ("Courier"), 0, 50);
		SwinGame.DrawText ("Five ships are: ", Color.White, GameResources.GameFont ("Courier"), 0, 70);
		SwinGame.DrawText ("Carrier(5 holes) Battleship(4 holes)  Cruiser(3 holes)  Submarine(2 holes) Destroyer(1 hole)", Color.White, GameResources.GameFont ("Courier"), 0, 90);
		SwinGame.DrawText ("Basic gameplay:", Color.Red, GameResources.GameFont ("Courier"), 0, 120);
		SwinGame.DrawText ("Players take turns firing shots (by calling out a grid coordinate) to attack enemy ships.", Color.White, GameResources.GameFont ("Courier"), 0, 140);
		SwinGame.DrawText ("The player for whom the right to move is, should select the empty box to shot", Color.White, GameResources.GameFont ("Courier"), 0, 160);
		SwinGame.DrawText ("If the guess was correct the (hit) sound and the selected box will become red.", Color.White, GameResources.GameFont ("Courier"), 0, 180);
		SwinGame.DrawText ("If the guess was incorrect the (miss) sound will appear and the box will become blue.", Color.White, GameResources.GameFont ("Courier"), 0, 200);
		SwinGame.DrawText ("If the shot was correct the player will continue his turn until he will miss", Color.White, GameResources.GameFont ("Courier"), 0, 220);
		SwinGame.DrawText ("The game will continue until one of opponents ships got fully eliminated", Color.White, GameResources.GameFont ("Courier"), 0, 240);
		SwinGame.DrawText ("Rules: ", Color.Red, GameResources.GameFont ("Courier"), 0, 300);
		SwinGame.DrawText ("The shot can not be repeated in the same place ,(error) sound will appear", Color.White, GameResources.GameFont ("Courier"), 0, 320);
		SwinGame.DrawText ("No cheating is allowed", Color.White, GameResources.GameFont ("Courier"), 0, 340);
		SwinGame.DrawText ("Features: ", Color.Red, GameResources.GameFont ("Courier"), 0, 400);
		SwinGame.DrawText ("Press (ESC) in roder to go back to menu, or to pause the game", Color.White, GameResources.GameFont ("Courier"), 0, 420);
		SwinGame.DrawText ("You can select the difficulty level in the main menu", Color.White, GameResources.GameFont ("Courier"), 0, 440);
		SwinGame.DrawText ("You can use the shuffle button that will allocate you ships randomly, to save the time", Color.White, GameResources.GameFont ("Courier"), 0, 460);
		SwinGame.DrawText ("Press (Scores) in the main menu in order to check the highest scores and compare yours with them", Color.White, GameResources.GameFont ("Courier"), 0, 480);
		SwinGame.DrawText ("Press (Surrender) button in order to finish the current game", Color.White, GameResources.GameFont ("Courier"), 0, 500);
		SwinGame.DrawText ("Press (Quit) button in order to quit the game", Color.White, GameResources.GameFont ("Courier"), 0, 520);
		SwinGame.DrawText ("Click anywhere to go back to the menu", Color.Yellow, GameResources.GameFont ("Courier"), 0, 540);

	}


	public static void HandleFAQ ()
	{
		if (SwinGame.MouseClicked (MouseButton.LeftButton) || SwinGame.KeyTyped (KeyCode.vk_ESCAPE) || SwinGame.KeyTyped (KeyCode.vk_RETURN)) {
			GameController.EndCurrentState ();
		}
	}
}



//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
