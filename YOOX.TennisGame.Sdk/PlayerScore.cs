namespace YOOX.TennisGame.Sdk
{
    public class PlayerScore
    {
        #region Properties

        public Player Player { get; init; }

        public int Score { get; private set; }

        #endregion

        #region Constructor

        public PlayerScore(Player player)
        {
            Player = player;
            Score = 0;
        }

        #endregion

        #region Methods

        public void Increase() => Score++;

        public bool IsWinningScore(PlayerScore opponentScore)
        {
            return Score > Constants.MimimumScoreToGoToDeuce 
                && Score - opponentScore.Score >= Constants.ScoreDifferenceToWinGameInAdvantagesSituation;
        }

        #endregion

    }

}
