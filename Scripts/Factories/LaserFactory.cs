using Godot;

namespace RocketScroller.Scripts.Factories;

public static class LaserFactory
{
    /// <summary>
    /// Create a laser
    /// </summary>
    /// <param name="laserScene"></param>
    /// <param name="rotating"></param>
    /// <param name="positionX"></param>
    /// <param name="positionY"></param>
    /// <returns></returns>
    public static Laser CreateLaser(PackedScene laserScene, bool rotating, float positionX, float positionY)
    {
        Laser laser = (Laser)laserScene.Instantiate();
        laser.Position = new Vector2(positionX, positionY);
        laser.Rotating = rotating;
        return laser;
    }
}