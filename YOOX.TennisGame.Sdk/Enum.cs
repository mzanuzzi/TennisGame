using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOOX.TennisGame.Sdk
{
    public enum MatchStatus
    {
        NotStarted,
        Running,
        Finished
    }

    public enum TennisGameError
    {
        MatchNotStarted,
        MatchAlreadyFinished
    }
}
