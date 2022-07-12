using Games.Models;

namespace Games.BusinessLogic
{
	public interface IRockPaperScissorsService
	{
		const int TimeToWait = 3;
		GameState State { get; set; }
		Choice? PlayerChoice { get; set; }
		Choice? OpponentChoice { get; set; }
		int WinningPlayerId { get; set; }
		Task OnClickChoice(Choice choice, int TimeToWait);
		public void CalculateWinner();
		public void StartNewGame();


	}
}
