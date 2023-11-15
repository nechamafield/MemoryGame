using MemoryGameSystem;

namespace MemoryGameTest
{
    public class MemoryGameTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestStartGame()
        {
            Game game = new();
            game.Start();
            string msg = $"turn number = {game.TurnNumber.ToString()} score = {game.ScoreText.ToString()} message = {game.MessageText()} backcolor = {game.SpotNotClicked.ToString()}";
            Assert.IsTrue(game.GameStatus == Game.GameStatusEnum.NotStarted);
            TestContext.WriteLine(msg);
        }


    }
}
