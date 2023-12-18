//#region README （#regionがなぜか反応しなかった　要検証）
// HLSLのテンプレート（試作中、UnityのURPを想定）
// hlslファイルで書くことでコードエディタの補助を受けることができる
//
// 参考URL
// https://redhologerbera.hatenablog.com/entry/2022/03/08/215227
// https://redhologerbera.hatenablog.com/entry/2022/11/08/090356
// https://tips.hecomi.com/entry/2019/10/27/152520
//
// （Visual Studioの場合）拡張機能 HLSL Tools for Visual Studio があると書きやすい
// ただし、
// https://tips.hecomi.com/entry/2020/12/20/000908
// https://tips.hecomi.com/entry/2023/02/25/163637
// で書かれているようにUnityに対応するための処置が必要
// （まだしていないため要検証）
//
// 使う際はShaderファイル内で
// #include  "TemplateHLSL.hlsl"
// と書く
//#endregion

// Shaderエントリーポイント
#pragma vertex vert		// vert	は任意の名前に変更可能
#pragma  fragment frag	// flag	は任意の名前に変更可能

// インクルード（一部のみ）
// ShaderLabの方に必要なもののみ書いて機能を使い分けたほうが良い
#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/SurfaceInput.hlsl"
#include "Packages/com.unity.render-pipelines.universal/Shaders/UnlitInput.hlsl"
#include "Packages/com.unity.render-pipelines.universal/Shaders/LitInput.hlsl"
#include "Packages/com.unity.render-pipelines.universal/Shaders/DepthOnlyPass.hlsl"
#include "Packages/com.unity.render-pipelines.universal/Shaders/ShadowCasterPass.hlsl"

// 頂点シェーダー
struct appdata
{
	//3Dモデルから受け取る情報（頂点座標やuv等）を格納・宣言
};
v2f vert(appdata v)//モデルの頂点に関する処理 Unity座標への変換等
{
	v2f o;
	//処理
	return o;
}

// フラグメントシェーダー
struct v2f
{
	//頂点シェーダーでの処理結果を格納する
	//一般的にVertex to Fragment でv2f
};
float4 frag(v2f i) :SV_Target
{
	//コンピュータの１ピクセルごとの色を処理する
}