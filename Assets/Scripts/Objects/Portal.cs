using UnityEngine;

public class Portal : Game
{
    private void Start()
    {
        app.portal = gameObject.GetComponent<Portal>();
        app.components.portalPS = gameObject.GetComponent<ParticleSystem>();
        app.components.portalCol1 = gameObject.GetComponent<CircleCollider2D>();
        app.components.portalCol2 = gameObject.AddComponent<CircleCollider2D>();
        app.components.portalPE = gameObject.GetComponent<PointEffector2D>();

        app.components.portalCol2.radius = 2f;
        app.components.portalCol2.isTrigger = true;
        app.components.portalCol2.usedByEffector = true;
        app.components.portalPE.enabled = false;
        app.components.portalPS.Stop();
        var sl = app.components.portalPS.sizeOverLifetime;
        sl.enabled = true;
        AnimationCurve curve = new AnimationCurve();
        curve.AddKey(0f, 1f);
        curve.AddKey(1f, 0f);
        sl.size = new ParticleSystem.MinMaxCurve(1.5f, curve);
    }
}
