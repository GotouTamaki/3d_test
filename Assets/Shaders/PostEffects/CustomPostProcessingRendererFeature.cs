using UnityEngine;
using UnityEngine.Rendering.Universal;

public sealed class CustomPostProcessingRendererFeature : ScriptableRendererFeature
{
    [field: SerializeField] public bool ReverseActive { get; set; } = false;
    [field: SerializeField] public bool GlitchActive { get; set; } = false;
    [field: SerializeField, Range(0, 1)] public float GlitchWeight { get; set; } = 1f;
    [field: SerializeField, Range(0, 1)] public float NoiseWeight { get; set; } = 1f;
    private ReverseColorRendererPass reverseColorPass = null;
    private GlitchEffectRendererPass glitchPass = null;

    [SerializeField] private Material reverseColorMaterial;

    // レンダーパスの作成を行う
    public override void Create()
    {
        reverseColorPass = reverseColorPass ?? new ReverseColorRendererPass();
        glitchPass = glitchPass ?? new GlitchEffectRendererPass();
    }

    // レンダーパスの追加を行う
    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        // 色反転 ポストエフェクトPass 追加
        reverseColorPass.SetRenderTarget(renderer.cameraColorTarget);
        reverseColorPass.Active = ReverseActive;
        renderer.EnqueuePass(reverseColorPass);

        // グリッチ ポストエフェクトPass 追加
        glitchPass.SetRenderTarget(renderer.cameraColorTarget);
        glitchPass.Active = GlitchActive;
        glitchPass.GlitchWeight = GlitchWeight;
        renderer.EnqueuePass(glitchPass);
    }
}