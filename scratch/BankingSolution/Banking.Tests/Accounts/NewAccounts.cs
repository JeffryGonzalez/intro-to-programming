﻿


using NSubstitute;

namespace Banking.Tests.Accounts;
public class NewAccounts
{
    [Fact]
    public void NewAccountsHaveCorrectOpeningBalance()
    {
        // Given I have a brand new account
        Account account = new Account(Substitute.For<ICalculateBonuses>());
        // When I ask that account for the balance
        var currentBalance = account.GetBalance();
        // Then it should be the correct opening balance.

        Assert.Equal(7000, currentBalance.Balance);
    }
}
