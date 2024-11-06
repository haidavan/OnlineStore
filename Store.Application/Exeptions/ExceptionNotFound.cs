

namespace Store.Application.Exeptions;

public class ExceptionNotFound(string name, object key):Exception($"Entity {name} ({key} not found)")
{
}
