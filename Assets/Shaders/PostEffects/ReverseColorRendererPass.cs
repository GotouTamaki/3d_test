using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public sealed class ReverseColorRendererPass : ScriptableRenderPass
{
    private const string Tag = nameof(ReverseColorRendererPass);

    private RenderTargetIdentifier currentTarget;

    public bool Active { get; set; }

    public ReverseColorRendererPass()
    {
        renderPassEvent = RenderPassEvent.AfterRenderingSkybox;
    }

    public void SetRenderTarget(RenderTargetIdentifier target)
    {
        currentTarget = target;
    }

    public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
    {
        if (!Active) { return; }

        var shader = Shader.Find("Custom/ReverseColor"); // 色を反転するシェーダー取得
        if (!shader) { return; }

        var material = new Material(shader);
        var commandBuffer = CommandBufferPool.Get(Tag);
        var renderTextureId = Shader.PropertyToID("_ReverseColorURPScriptableRenderer");
        var cameraData = renderingData.cameraData;
        var w = cameraData.camera.scaledPixelWidth;
        var h = cameraData.camera.scaledPixelHeight;
        int shaderPass = 0;

        commandBuffer.GetTemporaryRT(renderTextureId, w, h, 0, FilterMode.Point, RenderTextureFormat.Default);
        commandBuffer.Blit(currentTarget, renderTextureId);
        commandBuffer.Blit(renderTextureId, currentTarget, material, shaderPass);

        context.ExecuteCommandBuffer(commandBuffer);
        CommandBufferPool.Release(commandBuffer);
    }
}