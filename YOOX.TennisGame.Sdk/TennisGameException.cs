using System;

namespace YOOX.TennisGame.Sdk
{
    public class TennisGameException : Exception
    {

        #region Properties

        public Match Match { get; init; }

        public TennisGameError Error { get; init; }

        #endregion

        #region Constructor

        public TennisGameException(Match match, TennisGameError error) : base($"{match}: {error}")
        {
            Match = match;
            Error = error;
        }

        #endregion

    }
}
