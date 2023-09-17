public interface IPlayerController
{
    /// <summary>
    /// Called during controller setup, this generates a new
    /// PlayerActions struct so the controller can listen to
    /// the appropriate actions during play 
    /// </summary>
    /// <param name="PlayerIndex"></param> <summary>
    /// 
    /// </summary>
    /// <param name="PlayerIndex"></param>
    void PrepareInputs(int playerIndex);


    InputInstruction GetInput();
}