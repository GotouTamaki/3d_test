using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public sealed class GlitchEffectRendererPass : ScriptableRenderPass
{
    private const string Tag = nameof(GlitchEffectRendererPass);

    private RenderTargetIdentifier currentTarget;

    public bool Active { get; set; } 
    public float GlitchWeight { get; set; }
    public Material Material { get; set; }

    //private GlitchEffect glitchEffect = null;

    public GlitchEffectRendererPass()
    {
        renderPassEvent = RenderPassEvent.AfterRendering;
    }

    public void SetRenderTarget(RenderTargetIdentifier target)
    {
        currentTarget = target;
    }

    public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
    {
        if (!Active) { return; }

        // if (glitchEffect == null || glitchEffect.gameObject == null)
        // {
        //     glitchEffect = Camera.main.gameObject.GetComponent<GlitchEffect>();
        // }
        // //glitchEffect = glitchEffect ?? Camera.main.gameObject.GetComponent<GlitchEffect>();
        // if (glitchEffect == null) { return; }
        //
        // glitchEffect.Execute();
        // if (glitchEffect.Material == null) { return; }

        var commandBuffer = CommandBufferPool.Get(Tag);
        var renderTextureId = Shader.PropertyToID("_SampleLWRPScriptableRenderer");
        var cameraData = renderingData.cameraData;
        var w = cameraData.camera.scaledPixelWidth;
        var h = cameraData.camera.scaledPixelHeight;
        int shaderPass = 0;

        //glitchEffect.Material.SetFloat("_GlitchWeight", GlitchWeight);

        commandBuffer.GetTemporaryRT(renderTextureId, w, h, 0, FilterMode.Point, RenderTextureFormat.Default);
        commandBuffer.Blit(currentTarget, renderTextureId);
        //commandBuffer.Blit(renderTextureId, currentTarget, glitchEffect.Material, shaderPass);

        context.ExecuteCommandBuffer(commandBuffer);
        CommandBufferPool.Release(commandBuffer);
    }
}