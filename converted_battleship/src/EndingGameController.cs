
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using SwinGameSDK;

/// <summary>
/// The EndingGameController is responsible for managing the interactions at the end
/// of a game.
/// </summary>

static class EndingGameController
{

	/// <summary>
	/// Draw the end of the game screen, shows the win/lose state
	/// </summary>
	public static void DrawEndOfGame()
	{
		UtilityFunctions.DrawField(GameController.ComputerPlayer.PlayerGrid, GameController.ComputerPlayer, true);
		UtilityFunctions.DrawSmallField(GameController.HumanPlayer.PlayerGrid, GameController.HumanPlayer);

		if (UtilityFunctions.TurnWasted == true) {
				SwinGame.DrawTextLines ("TIMES UP! YOU LOSE!", Color.White, Color.Transparent, GameResources.GameFont ("ArialLarge"), FontAlignment.AlignCenter, 0, 250, SwinGame.ScreenWidth (), SwinGame.ScreenHeight ());
				SwinGame.DrawTextLines ("PRESS ESCAPE TO PROCEED", Color.White, Color.Transparent, GameResources.GameFont ("Courier"), FontAlignment.AlignCenter, 0, 350, SwinGame.ScreenWidth (), SwinGame.ScreenHeight ());
				GameResources.Mute ();//mute this so loser and winnner sound dont overlap with music - added by Jeremy Toh
				Audio.PlaySoundEffect (GameResources.GameSound ("Lose"));

		} else {

			if (GameController.ComputerPlayer.PlayerGrid.ShipsKilled == 4 || GameController.HumanPlayer.PlayerGrid.ShipsKilled == 4) {

				SwinGame.DrawTextLines ("You have only one ship left!", Color.White, Color.Transparent, GameResources.GameFont ("ArialLarge"), FontAlignment.AlignCenter, 0, 250, SwinGame.ScreenWidth (), SwinGame.ScreenHeight ());

			}

			if (GameController.HumanPlayer.IsDestroyed) {
				SwinGame.DrawTextLines ("YOU LOSE!", Color.White, Color.Transparent, GameResources.GameFont ("ArialLarge"), FontAlignment.AlignCenter, 0, 250, SwinGame.ScreenWidth (), SwinGame.ScreenHeight ());
				SwinGame.DrawTextLines ("PRESS ESCAPE TO PROCEED", Color.White, Color.Transparent, GameResources.GameFont ("Courier"), FontAlignment.AlignCenter, 0, 350, SwinGame.ScreenWidth (), SwinGame.ScreenHeight ());
			} else {
				SwinGame.DrawTextLines ("-- WINNER --", Color.White, Color.Transparent, GameResources.GameFont ("ArialLarge"), FontAlignment.AlignCenter, 0, 250, SwinGame.ScreenWidth (), SwinGame.ScreenHeight ());
				SwinGame.DrawTextLines ("PRESS ESCAPE TO PROCEED", Color.White, Color.Transparent, GameResources.GameFont ("Courier"), FontAlignment.AlignCenter, 0, 350, SwinGame.ScreenWidth (), SwinGame.ScreenHeight ());
			}
		}
	}

	/// <summary>
	/// Handle the input during the end of the game. Any interaction
	/// will result in it reading in the highsSwinGame.
	/// </summary>
	public static void HandleEndOfGameInput()
	{
		//press escape to continue instead of any key so that msg wont be skipped accidently by user - added by Jeremy Toh
		if (SwinGame.KeyTyped(KeyCode.vk_ESCAPE)) {
			GameResources.Unmute (); //resume music after loser/winner sound effect - added by Jeremy Toh
			HighScoreController.ReadHighScore(GameController.HumanPlayer.Score);
			GameController.EndCurrentState();
		}
	}

}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
