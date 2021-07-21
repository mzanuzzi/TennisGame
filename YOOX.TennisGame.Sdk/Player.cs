namespace YOOX.TennisGame.Sdk
{
    public class Player
    {

        #region Properties

        public string Name { get; set; }
        public string Surname { get; set; }

        #endregion
        

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }

}
