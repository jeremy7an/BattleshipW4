
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
	private const int NAME_WIDTH = 3;

	private const int SCORES_LEFT = 490;
	/// <summary>
	/// The score structure is used to keep the name and
	/// score of the top players together.
	/// </summary>
	private struct Score : IComparable
	{
		public string Name;

		public int Value;
		/// <summary>
		/// Allows scores to be compared to facilitate sorting
		/// </summary>
		/// <param name="obj">the object to compare to</param>
		/// <returns>a value that indicates the sort order</returns>
		public int CompareTo (object obj)
		{
			if (obj is Score) {
				Score other = (Score)obj;

				return other.Value - this.Value;
			} else {
				return 0;
			}
		}
	}


	private static List<Score> _Scores = new List<Score> ();
	/// <summary>
	/// Loads the scores from the highscores text file.
	/// </summary>
	/// <remarks>
	/// The format is
	/// # of scores
	/// NNNSSS
	/// 
	/// Where NNN is the name and SSS is the score
	/// </remarks>
	private static void LoadScores ()
	{
		string filename = null;
		filename = SwinGame.PathToResource ("FAQ.txt");

		StreamReader input = default (StreamReader);
		input = new StreamReader (filename);

		//Read in the # of scores
		int numScores = 0;
		numScores = Convert.ToInt32 (input.ReadLine ());

		_Scores.Clear ();

		int i = 0;

		for (i = 1; i <= numScores; i++) {
			Score s = default (Score);
			string line = null;

			line = input.ReadLine ();

			s.Name = line.Substring (0, NAME_WIDTH);
			s.Value = Convert.ToInt32 (line.Substring (NAME_WIDTH));
			_Scores.Add (s);
		}
		input.Close ();
	}


	/// <summary>
	/// Draws the high scores to the screen.
	/// </summary>
	public static void DrawFAQ ()
	{
		const int SCORES_HEADING = 0;
		const int SCORES_LEFT = 0;
		SwinGame.DrawText ("Instructions:", Color.White, GameResources.GameFont ("Courier"), SCORES_LEFT, SCORES_HEADING);
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
