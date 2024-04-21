using QuickOut.Common.Contracts;

namespace QuickOut.Common;

public abstract class AggregateRoot : Entity
{
    protected static Result CheckRules(params IBusinessRule[] rules)
    {
        List<string> validationErrors = new List<string>();

        foreach (IBusinessRule? rule in rules)
        {
            if (rule.IsBroken())
            {
                validationErrors.Add(rule.Message);
            }
        }

        if (validationErrors.Count > 0)
        {
            return Result.Fail(validationErrors);
        }

        return Result.Success();
    }
}
