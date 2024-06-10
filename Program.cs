bool hitTarget = false; // to update the player score
int userRange; // input from user 
int cityHealth = 15;
int manticoreHealth = 10;
Console.Write("Enter the desired range From 0 to 100: ");
int enemyRange = int.Parse(Console.ReadLine());
{
    CheckForCorrectRange();
}
Console.Clear();
Console.WriteLine("Player 2 its Your turn..");

for (int i = 1; manticoreHealth > 0 && cityHealth > 0; i++)
{
    int fire = i, electric = i;
    if (fire % 3 == 0 && electric % 5 == 0) // for every 15 iteration
    {
        Repetation();
        Console.Write($"""
         Cannon is expected to hit 10 damage
         Enter the Desired Cannon range: 
         """);
        ChangeUserValue();
        ShipAttackLogic();
        if (hitTarget)
        {
            manticoreHealth -= 10;
            hitTarget = false;
        }
    }

    else if (fire % 3 == 0 || electric % 5 == 0) // Every 5 and 3 iteration
    {
        Repetation();
        Console.Write($"""
         Cannon is expected to hit 3 damage
         Enter the Desired Cannon range: 
         """);
        ChangeUserValue();
        ShipAttackLogic();
        if (hitTarget)
        {
            manticoreHealth -= 3;
            hitTarget = false;
        }
    }
    else
    {
        Repetation();   // FIRST to call
        Console.Write($"""
         Cannon is expected to hit 1 damage
         Enter the Desired Cannon range: 
         """);
        ChangeUserValue();
        ShipAttackLogic();
        if (hitTarget)
        {
            manticoreHealth -= 1;
            hitTarget = false;
        }
    }
    void Repetation()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"""
        --------------------------------------------------
        STATUS: Round {i} City: {cityHealth}/15 Maticore: {manticoreHealth}/10
        """);
        NutralizeColor();
    }
}
if (manticoreHealth <= 0)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Consolas Won!");
    NutralizeColor();
}
else
{
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine("Uncoded Won!");
    NutralizeColor();
}
//Methods.........
void CheckForCorrectRange()
{
    for (; ; )
        if (enemyRange > 100 || enemyRange < 0)
        {
            Console.Write("Enter the desired range From 0 to 100 ONLY!");
            enemyRange = int.Parse(Console.ReadLine());
        }
        else
        {
            break;
        }
}
void ShipAttackLogic() //4th line 
{
    cityHealth--;
    if (userRange != enemyRange)
    {
        for (int i = 0; i <= 15; i++) // Check if the Number lies in a range (+-)15 
        {
            if ((userRange + i) == enemyRange || (userRange - i) == enemyRange)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                NutralizeColor();
                Console.WriteLine("That round FELL SHORT of the target");
                return;
            }
        }
        Console.WriteLine("That round OVERSHOT the target");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Direct Hit");
        NutralizeColor();
        hitTarget = true;
    }
}
void ChangeUserValue()
{
    userRange = int.Parse(Console.ReadLine());
}
void NutralizeColor()
{
    Console.ForegroundColor = ConsoleColor.White;
}
