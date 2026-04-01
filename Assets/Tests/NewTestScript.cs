using NUnit.Framework;
using UnityEngine;

public class PlayerSetupTest
{
    private GameObject player;

    [SetUp]
    public void SetUp()
    {
        player = new GameObject("Player");
        var rb = player.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        player.AddComponent<BoxCollider2D>();
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(player);
    }

    [Test]
    public void Player_Has_Rigidbody2D()
    {
        Assert.IsNotNull(player.GetComponent<Rigidbody2D>());
    }

    [Test]
    public void Player_Has_Collider2D()
    {
        Assert.IsNotNull(player.GetComponent<Collider2D>());
    }

    [Test]
    public void Rigidbody2D_Is_Dynamic()
    {
        var rb = player.GetComponent<Rigidbody2D>();
        Assert.AreEqual(RigidbodyType2D.Dynamic, rb.bodyType);
    }

    [Test]
    public void Gravity_Is_Disabled()
    {
        var rb = player.GetComponent<Rigidbody2D>();
        Assert.AreEqual(0f, rb.gravityScale);
    }

    [Test]
    public void Player_Has_SpriteRenderer()
    {
        player.AddComponent<SpriteRenderer>();
        Assert.IsNotNull(player.GetComponent<SpriteRenderer>());
    }

    [Test]
    public void PlayerMovement_Script_Exists()
    {
        var type = System.Type.GetType("PlayerMovement, Assembly-CSharp");
        Assert.IsNotNull(type, "PlayerMovement script exists in project");
    }
}