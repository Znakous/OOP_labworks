using Domain.Models.ValueObjects;

namespace Domain.Models;

public record ExecutedTransaction(string Name, DateTime ExecutedAt, Money BalanceBefore, Money BalanceAfter) { }
