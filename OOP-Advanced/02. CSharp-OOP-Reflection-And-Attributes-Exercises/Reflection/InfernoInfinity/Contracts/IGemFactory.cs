namespace InfernoInfinity.Contracts
{
    public interface IGemFactory
    {
        IGem CreateGem(string typeAsString, IClarity clarity);
    }
}
