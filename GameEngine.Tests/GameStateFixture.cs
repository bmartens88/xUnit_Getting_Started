using System;

namespace GameEngine.Tests
{
    public class GameStateFixture : IDisposable
    {
        public GameState State { get; set; }

        public GameStateFixture()
        {
            State = new();
        }

        public void Dispose()
        {
            // Cleanup
        }
    }
}
