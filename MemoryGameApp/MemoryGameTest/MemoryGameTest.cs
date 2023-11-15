using MemoryGameSystem;
using System.Drawing;

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
            Spots spot = new();
            game.Start();
            string msg = $"turn number = {game.TurnNumber.ToString()} score = {game.ScoreText.ToString()} message = {game.MessageText()} backcolor = {spot.SpotColor.ToString()} winner = ";
            Assert.IsTrue(game.GameStatus == Game.GameStatusEnum.NotStarted);
            TestContext.WriteLine(msg);
        }

        [Test]
        public void TestDoTurn()
        {
            Game game = new();
            Spots spot = new();
            game.Start();
            game.DoTurn(spot);
            string msg = $"score = {game.Score} turn number = {game.TurnNumber} cspot {spot.BackColor.ToString()}";
            Assert.IsTrue(spot.BackColor != Color.LightSteelBlue);
            TestContext.WriteLine(msg);
        }

        [Test]
        public void TestNextTurn()
        {
            Game game = new();
            Spots spot1 = new();
            Spots spot2 = new();
            game.Start();
            game.DoTurn(spot1);
            game.NextTurn(spot2);
            string msg = $"score = {game.Score} turn number = {game.TurnNumber} message = {game.Message} cspot1 {spot1.BackColor.ToString()} cspot2 {spot1.BackColor.ToString()}";
            Assert.IsTrue(spot1.BackColor != Color.LightSteelBlue);
            TestContext.WriteLine(msg);
        }
    }
}
