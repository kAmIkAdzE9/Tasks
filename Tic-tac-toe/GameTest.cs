using Xunit;

namespace Tic_tac_toe
{
    public class GameTest
    {

        [Fact]
        public void GetEmptyGridTest()
        {
            // Arrange
            int size = 3;
            string emptyCell = "0";
            string zero = "1";
            string cross = "2";
            Game game = new Game(size, emptyCell, zero, cross);
            string[,] grid = {{emptyCell, emptyCell, emptyCell}, {emptyCell, emptyCell, emptyCell}, {emptyCell, emptyCell, emptyCell}};

            // Act
            string[,] output = game.getGrid();

            // Assert
            Assert.Equal(grid, output);
        }

        [Fact]
        public void IndexOutOfBoundsTest() {
            // Arrange
            int size = 3;
            string emptyCell = "0";
            string zero = "1";
            string cross = "2";
            Game game = new Game(size, emptyCell, zero, cross);
            int i = 4; 
            int j = 2;
            string str = "Some index is out of bounds.";

            // Act
            string output = game.makeMove(i,j);

            // Assert
            Assert.Equal(str, output);
        }

        [Fact]
        public void EndGameStatusTest() {
            // Arrange
            int size = 3;
            string emptyCell = "0";
            string zero = "1";
            string cross = "2";
            Game game = new Game(size, emptyCell, zero, cross);
            int[,] scenario = { { 0, 1 }, { 0, 2 }, { 1, 1 }, { 1, 2 }, { 2, 1 } };
            bool status = true;

            // Act
            for (int i = 0; i < scenario.GetLength(0); i++)
            {
                game.makeMove(scenario[i, 0], scenario[i, 1]);
            }

            // Assert
            Assert.Equal(status, game.IsGameEnd());
        }
    }
}