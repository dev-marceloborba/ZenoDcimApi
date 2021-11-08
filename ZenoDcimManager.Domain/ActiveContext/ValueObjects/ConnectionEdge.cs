using ZenoDcimManager.Shared.ValueObjects;
using Flunt.Validations;

namespace ZenoDcimManager.Domain.ActiveContext.ValueObjects
{
    public class ConnectionEdge : ValueObject
    {
        public string Edge { get; private set; }

        public ConnectionEdge(string edge)
        {
            Edge = edge;

            AddNotifications(new Contract()
                .Requires()
                .HasLen(Edge, 3, "Edge", "Edge must have 3 characters")
            );
        }

        private bool Validate()
        {
            // TODO: definir formato para identificacao do switch e porta
            // TODO : aplicar REGEX do formato definido
            return false;
        }
    }
}