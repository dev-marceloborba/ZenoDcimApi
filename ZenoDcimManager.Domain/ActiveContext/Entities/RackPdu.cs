namespace ZenoDcimManager.Domain.ActiveContext.Entities
{
    public class RackPdu
    {
        public RackPdu(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}