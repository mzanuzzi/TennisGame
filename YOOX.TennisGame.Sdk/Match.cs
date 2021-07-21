namespace YOOX.TennisGame.Sdk
{
    public class Match
    {

        #region Constructor

        public Match(Player playerOne, Player playerTwo)
        {
            ServerScore = new PlayerScore(playerOne);
            ReceiverScore = new PlayerScore(playerTwo);
        }

        #endregion

        #region Properties

        public Player Winner { get; private set; }
        public PlayerScore ServerScore { get; init; }
        public PlayerScore ReceiverScore { get; init; }
        public MatchStatus Status { get; private set; }

        #endregion

        #region Methods

        public void Start()
        {
            if (Status == MatchStatus.NotStarted)
                Status = MatchStatus.Running;
        }

        public void ServerScoresPoint()
        {
            HandlePoint(ServerScore, ReceiverScore);
        }

        public void ReceiverScoresPoint()
        {
            HandlePoint(ReceiverScore, ServerScore);
        }          

        public bool IsDeuce() => ServerScore.Score == ReceiverScore.Score 
            && ServerScore.Score >= Constants.MimimumScoreToGoToDeuce;

        public bool IsServerAdvantage() => IsPlayerAdvantage(ServerScore, ReceiverScore);

        public bool IsReceiverAdvantage() => IsPlayerAdvantage(ReceiverScore, ServerScore);

        public override string ToString() => $"{ServerScore?.Player} vs {ReceiverScore?.Player}";
        
        #region Private

        private bool IsPlayerAdvantage(PlayerScore scorer, PlayerScore opponent) => scorer.Score >= Constants.MinimumScoreToGoToAdvantages
            && scorer.Score > opponent.Score
            && scorer.Score - opponent.Score < Constants.ScoreDifferenceToWinGameInAdvantagesSituation;

        private void HandleGamePlayAvailability()
        {
            if (Status == MatchStatus.NotStarted)
                throw new TennisGameException(this, TennisGameError.MatchNotStarted);
            if (Status == MatchStatus.Finished)
                throw new TennisGameException(this, TennisGameError.MatchAlreadyFinished);
        }

        private void HandlePoint(PlayerScore scorer, PlayerScore opponent)
        {
            HandleGamePlayAvailability();
            scorer.Increase();
            if (scorer.IsWinningScore(opponent))
            {
                Status = MatchStatus.Finished;
                Winner = scorer.Player;
            }
        }

        #endregion

        #endregion

    }

}
