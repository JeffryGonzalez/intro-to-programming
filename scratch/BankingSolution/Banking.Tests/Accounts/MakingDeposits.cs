

namespace Banking.Tests.Accounts;
public class MakingDeposits
{
    [Theory]
    [InlineData(100.25)]
    [InlineData(2.48)]
    public void DepositingIncreasesBalance(decimal amountToDeposit)
    {
        // Given
        var account = new Account();
        var openingBalance = account.GetBalance();

        // When

        account.Deposit(amountToDeposit);

        // Then
        var newBalance = account.GetBalance();

        Assert.Equal(openingBalance + amountToDeposit,
            newBalance);


    }
}
