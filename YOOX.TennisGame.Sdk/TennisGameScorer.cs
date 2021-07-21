using System;

namespace YOOX.TennisGame.Sdk
{
    public class TennisGameScorer
    {
        #region Properties

        private Match Match { get; set; }

        #endregion

        #region Constructor

        public TennisGameScorer(Match match)
        {
            if (match is null)
                throw new ArgumentNullException(nameof(match));
            Match = match;
        }

        #endregion

        #region Methods

        public string PrintScore()
        {
            if (Match.Status == MatchStatus.NotStarted)
                return "The match has not already started";
            if (Match.Status == MatchStatus.Finished)
                return $"The match is over. The winner is {Match.Winner}";
            if (Match.IsDeuce())
                return $"Deuce";
            if (Match.IsServerAdvantage())
                return $"Advantage {Match.ServerScore.Player}";
            if (Match.IsReceiverAdvantage())
                return $"Advantage {Match.ReceiverScore.Player}";           
            return $"{Match.ServerScore.Player} {MapTennisGameScore(Match.ServerScore)} - {MapTennisGameScore(Match.ReceiverScore)} {Match.ReceiverScore.Player}";
        }

        private int MapTennisGameScore(PlayerScore playerScore) => playerScore.Score switch
        {
            0 => 0,
            1 => 15,
            2 => 30,
            3 => 40,
            _ => -1 //not reachable
        };

        #endregion
    }
}
