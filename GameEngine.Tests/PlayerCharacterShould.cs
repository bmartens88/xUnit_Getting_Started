using System;
using System.Collections.Generic;
using Xunit;

namespace GameEngine.Tests
{
  public class PlayerCharacterShould
  {
    [Fact]
    public void BeInexperiencedWhenNew()
    {
      PlayerCharacter sut = new();

      Assert.True(sut.IsNoob);
    }

    [Fact]
    public void CalculateFullName()
    {
      PlayerCharacter sut = new();

      sut.FirstName = "Sarah";
      sut.LastName = "Smith";

      Assert.Equal("Sarah Smith", sut.FullName);
    }

    [Fact]
    public void HaveFullNameStartingWithFirstName()
    {
      PlayerCharacter sut = new();

      sut.FirstName = "Sarah";
      sut.LastName = "Smith";

      Assert.StartsWith("Sarah", sut.FullName);
    }

    [Fact]
    public void HaveFullNameEndingWithLastName()
    {
      PlayerCharacter sut = new();

      sut.LastName = "Smith";

      Assert.EndsWith("Smith", sut.FullName);
    }

    [Fact]
    public void CalculateFullName_IgnoreCaseAssertExample()
    {
      PlayerCharacter sut = new();

      sut.FirstName = "SARAH";
      sut.LastName = "SMITH";

      Assert.Equal("Sarah Smith", sut.FullName, ignoreCase: true);
    }

    [Fact]
    public void CalculateFullName_SubstringAssertExample()
    {
      PlayerCharacter sut = new();

      sut.FirstName = "Sarah";
      sut.LastName = "Smith";

      Assert.Contains("ah Sm", sut.FullName);
    }

    [Fact]
    public void CalculateFullNameWithTitleCase()
    {
      PlayerCharacter sut = new();

      sut.FirstName = "Sarah";
      sut.LastName = "Smith";

      Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", sut.FullName);
    }

    [Fact]
    public void StartWithDefaultHealth()
    {
      PlayerCharacter sut = new();

      Assert.Equal(100, sut.Health);
    }

    [Fact]
    public void StartWithDefaultHealth_NotEqualExample()
    {
      PlayerCharacter sut = new();

      Assert.NotEqual(0, sut.Health);
    }

    [Fact]
    public void IncreaseHealthAfterSleeping()
    {
      PlayerCharacter sut = new();

      sut.Sleep(); // Expect increase between 1 and 100 inclusive

      // Assert.True(sut.Health >= 101 && sut.Health <= 200); <- does not provide a lot of helpfull information when failing test
      Assert.InRange(sut.Health, 101, 200);
    }

    [Fact]
    public void NotHaveNickNameByDefault()
    {
      PlayerCharacter sut = new();

      Assert.Null(sut.NickName);
    }

    [Fact]
    public void HaveALongBow()
    {
      PlayerCharacter sut = new();

      Assert.Contains("Long Bow", sut.Weapons);
    }

    [Fact]
    public void NotHaveAStaffOfWonder()
    {
      PlayerCharacter sut = new();

      Assert.DoesNotContain("Staff Of Wonder", sut.Weapons);
    }

    [Fact]
    public void HaveAtLeastOneKindOfSword()
    {
      PlayerCharacter sut = new();

      Assert.Contains(sut.Weapons, weapon => weapon.Contains("Sword"));
    }

    [Fact]
    public void HaveAllExpectedWeapons()
    {
      PlayerCharacter sut = new();

      var expectedWeapons = new[]
      {
        "Long Bow",
        "Short Bow",
        "Short Sword"
      };

      Assert.Equal(expectedWeapons, sut.Weapons);
    }

    [Fact]
    public void HaveNoEmptyDefaultWeapons()
    {
      PlayerCharacter sut = new();

      Assert.All(sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
    }

    [Fact]
    public void RaiseSleptEvent()
    {
      PlayerCharacter sut = new();

      Assert.Raises<EventArgs>(
        handler => sut.PlayerSlept += handler,
        handler => sut.PlayerSlept -= handler,
        () => sut.Sleep());
    }

    [Fact]
    public void RaisePropertyChangedEvent()
    {
      PlayerCharacter sut = new();

      Assert.PropertyChanged(sut, "Health", () => sut.TakeDamage(10));
    }
  }
}
