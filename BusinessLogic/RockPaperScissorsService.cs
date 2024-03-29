﻿using Games.Models;

namespace Games.BusinessLogic
{
	public class RockPaperScissorsService : IRockPaperScissorsService
	{

		public GameState State { get; set; } = GameState.MakeChoice;

		public Choice? PlayerChoice { get; set; }
		public Choice? OpponentChoice { get; set; }
		public int WinningPlayerId { get; set; }
		private Random r = new Random();

		public async Task OnClickChoice(Choice choice, int TimeToWait)
		{
			PlayerChoice = choice;
			OpponentChoice = (Choice)r.Next(0, 3);

			State = GameState.WaitForResult;
			await Task.Delay(TimeToWait * 800 - 200);

			CalculateWinner();
			State = GameState.Result;
		}

		public void CalculateWinner()
		{
			if (PlayerChoice == OpponentChoice) WinningPlayerId = 0;
			else if (PlayerChoice == Choice.Paper && OpponentChoice == Choice.Rock) WinningPlayerId = 1;
			else if (OpponentChoice == Choice.Paper && PlayerChoice == Choice.Rock) WinningPlayerId = 2;
			else if (PlayerChoice == Choice.Rock && OpponentChoice == Choice.Scissors) WinningPlayerId = 1;
			else if (OpponentChoice == Choice.Rock && PlayerChoice == Choice.Scissors) WinningPlayerId = 2;
			else if (PlayerChoice == Choice.Scissors && OpponentChoice == Choice.Paper) WinningPlayerId = 1;
			else if (OpponentChoice == Choice.Scissors && PlayerChoice == Choice.Paper) WinningPlayerId = 2;
		}


		public void StartNewGame()
		{
			State = GameState.MakeChoice;
			PlayerChoice = null;
			OpponentChoice = null;
		}

	}
}
