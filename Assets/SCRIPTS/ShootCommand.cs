using UnityEngine;
using MyGame;
public class ShootCommand : ICommand
{
    private GameplayFactory factory;
    private Transform firePoint;

    public ShootCommand(GameplayFactory f, Transform fp)
    {
        factory = f;
        firePoint = fp;
    }

    public void Execute()
    {
        factory.SpawnBullet(firePoint.position, firePoint.rotation);
    }
}