
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using SwinGameSDK;
using System.Windows.Forms;

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

			if (GameController.HumanPlayer.IsDestroyed) {
				MessageBox.Show ("It is ok, try next time!"+"\nPress (ok) to continue ","Try again");
				HighScoreController.ReadHighScore (GameController.HumanPlayer.Score);
				GameController.EndCurrentState ();
			} else {
				MessageBox.Show ("You win, woooohoooo!"+"\nPress (ok) to continue ","Congratulations!");
				GameController.EndCurrentState ();
				HighScoreController.ReadHighScore (GameController.HumanPlayer.Score);
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
		if (SwinGame.KeyTyped(KeyCode.vk_ESCAPE)||SwinGame.MouseClicked(MouseButton.LeftButton)) {
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
